namespace VeloWorldSystem.Common.Exceptions
{
    using System;

    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" {key} was not found!")
        {
            this.Key = key;
        }

        public object Key { get; }
    }
}
