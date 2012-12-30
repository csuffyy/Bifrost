﻿#region License
//
// Copyright (c) 2008-2012, DoLittle Studios AS and Komplett ASA
//
// Licensed under the Microsoft Permissive License (Ms-PL), Version 1.1 (the "License")
// With one exception :
//   Commercial libraries that is based partly or fully on Bifrost and is sold commercially, 
//   must obtain a commercial license.
//
// You may not use file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://bifrost.codeplex.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bifrost.Execution;
using Bifrost.Extensions;

namespace Bifrost.Tasks
{
    /// <summary>
    /// Represents a <see cref="ITaskManager"/>
    /// </summary>
    public class TaskManager : ITaskManager
    {
        ITaskRepository _taskRepository;
        ITaskScheduler _taskExecutor;
        IContainer _container;
        IEnumerable<ITaskStatusReporter> _reporters;


        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManager"/>
        /// </summary>
        /// <param name="taskRepository">A <see cref="ITaskRepository"/> to load / save <see cref="Task">tasks</see></param>
        /// <param name="taskExecutor">A <see cref="ITaskScheduler"/> for executing tasks and their operations</param>
        /// <param name="typeImporter">A <see cref="ITypeImporter"/> used for importing <see cref="ITaskStatusReporter"/></param>
        /// <param name="container">A <see cref="IContainer"/> to use for getting instances</param>
        public TaskManager(ITaskRepository taskRepository, ITaskScheduler taskExecutor, ITypeImporter typeImporter, IContainer container)
        {
            _taskRepository = taskRepository;
            _taskExecutor = taskExecutor;
            _container = container;
            _reporters = typeImporter.ImportMany<ITaskStatusReporter>();
        }

#pragma warning disable 1591 // Xml Comments
        public T Start<T>() where T : Task
        {
            var task = _container.Get<T>();
            task.CurrentOperation = 0;
            task.Begin();
            _taskExecutor.Start(task);
            Report(t => t.Started(task));

            return task;
        }

        public T Resume<T>(TaskId taskId) where T : Task
        {
            var task = _taskRepository.Load(taskId) as T;
            task.Begin();
            _taskExecutor.Start(task);
            Report(t => t.Resumed(task));
            return task;
        }

        public void Stop(TaskId taskId)
        {
            var task = _taskRepository.Load(taskId);
            task.End();
            _taskRepository.Delete(task);
            Report(t => t.Stopped(task));
        }

        public void Pause(TaskId taskId)
        {
            var task = _taskRepository.Load(taskId);
            _taskExecutor.Stop(task);
            Report(t => t.Paused(task));
        }
#pragma warning restore 1591 // Xml Comments

        void Report(Expression<Action<ITaskStatusReporter>> expression)
        {
            var method = expression.GetMethodInfo();
            var arguments = expression.GetMethodArguments();

            foreach (var reporter in _reporters)
                method.Invoke(reporter, arguments);
        }
    }
}