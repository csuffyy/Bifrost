using System;
using Bifrost.Commands;

namespace Bifrost.Testing.Fakes.Commands
{
    public class AnotherSimpleCommand : ICommand
    {
        public AnotherSimpleCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public string SomeString { get; set; }

        public int SomeInt { get; set; }
    }
}