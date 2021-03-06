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
#if(!SILVERLIGHT)
using System.Runtime.InteropServices;
#else
using _Assembly = System.Reflection.Assembly;
#endif
using Bifrost.Specifications;

namespace Bifrost.Configuration.Assemblies
{
    /// <summary>
    /// Represents the configuration for Assemblies
    /// </summary>
    public class AssembliesConfiguration
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AssembliesConfiguration"/>
        /// </summary>
        /// <param name="specification"></param>
        public AssembliesConfiguration(Specification<string> specification)
        {
            Specification = specification;
        }

        /// <summary>
        /// Gets the specification used to specifying which assemblies to include
        /// </summary>
        public Specification<string> Specification { get; private set; }
    }
}
