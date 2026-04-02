namespace GtMotive.Estimate.Microservice.Domain.Entities.Base
{
    /// <summary>
    /// Base class for domain entities.
    /// </summary>
    /// <typeparam name="TId">Type of the entity id.</typeparam>
    public abstract class Entity<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
        /// </summary>
        /// <param name="id">Entity id.</param>
        protected Entity(TId id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
        /// </summary>
        protected Entity()
        {
        }

        /// <summary>
        /// Gets or inits de entity id.
        /// </summary>
        public TId Id { get; init; }
    }
}
