namespace VeloWorldSystem.Models.Abstract
{
    using VeloWorldSystem.Models.Contracts;

    /// <summary>
    /// BaseDeletableEntity.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public class BaseDeletableEntity<T> : BaseEntity<T>, IDeletableEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether isDeleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets deletedAt.
        /// </summary>
        public DateTime? DeletedAt { get; set; }
    }
}
