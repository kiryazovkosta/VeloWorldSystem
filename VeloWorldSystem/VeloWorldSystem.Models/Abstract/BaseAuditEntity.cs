using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Models.Contracts;

namespace VeloWorldSystem.Models.Abstract
{
    public class BaseAuditEntity : IAuditInfo
    {
        /// <summary>
        /// Gets or sets createdAt.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets modifiedAt.
        /// </summary>
        public DateTime? ModifiedAt { get; set; }
    }
}
