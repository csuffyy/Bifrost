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
using System.IO;

namespace Bifrost.CodeGeneration
{
    /// <summary>
    /// Represents an implementation of <see cref="ICodeWriter"/>
    /// </summary>
    public class CodeWriter : ICodeWriter
    {
        int _indentLevel;
        TextWriter _actualWriter;

#pragma warning disable 1591
        public CodeWriter(TextWriter writer)
        {
            _actualWriter = writer;
        }

        public void Indent()
        {
            _indentLevel++;
        }

        public void Unindent()
        {
            _indentLevel--;
        }

        public void WriteWithIndentation(string format, params object[] args)
        {
            for (var i = 0; i < _indentLevel; i++) _actualWriter.Write("\t");
            Write(format, args);
        }

        public void Write(string format, params object[] args)
        {
            _actualWriter.Write(format, args);
        }

        public void Newline()
        {
            _actualWriter.Write("\n");
        }
#pragma warning restore 1591
    }
}
