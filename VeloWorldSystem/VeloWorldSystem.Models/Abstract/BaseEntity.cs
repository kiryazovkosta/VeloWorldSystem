namespace VeloWorldSystem.Models.Abstract
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Models.Contracts;

    /// <summary>
    /// AuditInfo.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public abstract class BaseEntity<T> : IEntity<T>, IAuditInfo
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [Key]
        public T Id { get; set; } = default!;

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
