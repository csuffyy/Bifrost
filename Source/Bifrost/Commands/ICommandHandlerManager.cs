﻿#region License
//
// Copyright (c) 2008-2015, Dolittle (http://www.dolittle.com)
//
// Licensed under the MIT License (http://opensource.org/licenses/MIT)
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://github.com/dolittle/Bifrost/blob/master/MIT-LICENSE.txt
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
namespace Bifrost.Commands
{
	/// <summary>
	/// Defines the functionality for a manager that handles commands
	/// 
	/// Handles a <see cref="ICommand">command</see> by calling any
	/// command handlers that can handle the specific command
	/// </summary>
	public interface ICommandHandlerManager
	{
		/// <summary>
		/// Handle a command
		/// </summary>
		/// <param name="command"><see cref="ICommand">Command</see> to handle</param>
		void Handle(ICommand command);
	}
}