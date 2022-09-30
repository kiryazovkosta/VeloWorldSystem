namespace VeloWorldSystem.Models.Entities.Identity
{
    using System;

    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// ApplicationRole.
    /// </summary>
    public class ApplicationRole : IdentityRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
        /// </summary>
        public ApplicationRole()
            : this(null!)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        public ApplicationRole(string name)
            : base(name)
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
