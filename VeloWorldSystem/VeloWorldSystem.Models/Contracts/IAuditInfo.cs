namespace VeloWorldSystem.Models.Contracts
{
    /// <summary>
    /// IAuditInfo.
    /// </summary>
    public interface IAuditInfo
    {
        /// <summary>
        /// Gets or sets CreatedAt.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets LastModifiedAt.
        /// </summary>
        DateTime? ModifiedAt { get; set; }
    }
}