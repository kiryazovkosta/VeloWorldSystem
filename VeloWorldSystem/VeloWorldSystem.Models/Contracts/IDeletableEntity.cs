namespace VeloWorldSystem.Models.Contracts
{
    /// <summary>
    /// IDeletableEntity.
    /// </summary>
    public interface IDeletableEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether isDeleted.
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets deletedAt.
        /// </summary>
        DateTime? DeletedAt { get; set; }
    }
}