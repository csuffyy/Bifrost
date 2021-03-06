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

namespace Bifrost.Mapping
{
    /// <summary>
    /// Defines the strategy for mapping properties
    /// </summary>
    public interface IPropertyMappingStrategy
    {
        /// <summary>
        /// Performs the mapping
        /// </summary>
        /// <param name="mappingTarget">Mapping target to use</param>
        /// <param name="target">Target in which to map to</param>
        /// <param name="value">Value from to set</param>
        void Perform(IMappingTarget mappingTarget, object target, object value);
    }
}
