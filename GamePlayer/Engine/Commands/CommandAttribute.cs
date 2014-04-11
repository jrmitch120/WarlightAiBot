using System;

namespace GamePlayer.Engine.Commands
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CommandAttribute : Attribute
    {
        public readonly string CommandName;

        public string Description { get; set; }
        
        public CommandAttribute(string commandName, string description)
        {
            CommandName = commandName;
            Description = description;
        }
    }
}
