using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloWorldSystem.Common.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string name, object key)
            : base($"Does not have permissions for Entity \"{name}\" {key}!")
        {
                this.Key = key;
        }

        public object Key { get; }
    }
}
