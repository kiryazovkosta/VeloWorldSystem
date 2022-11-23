using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloWorldSystem.Common.Exceptions
{
    public class CloudinaryUploadException : Exception
    {
        public CloudinaryUploadException(string message)
            : base(message) { }
    }
}
