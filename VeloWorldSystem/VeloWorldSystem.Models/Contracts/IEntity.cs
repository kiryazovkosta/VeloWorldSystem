namespace VeloWorldSystem.Models.Contracts
{
    /// <summary>
    /// IEntity.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public interface IEntity<T>
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        T Id { get; set; }
    }
}