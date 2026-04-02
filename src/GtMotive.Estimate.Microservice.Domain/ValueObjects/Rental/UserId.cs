using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental
{
    /// <summary>
    /// User id value object.
    /// </summary>
    public readonly struct UserId : IEquatable<UserId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserId"/> struct.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <exception cref="ArgumentException">Throws if the user id is invalid.</exception>
        public UserId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("The user id can't be null.");
            }

            Id = id;
        }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>Equality.</returns>
        public static bool operator ==(UserId left, UserId right)
        {
            return left.Id == right.Id;
        }

        /// <summary>
        /// Inequiality operator.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>Inequality.</returns>
        public static bool operator !=(UserId left, UserId right)
        {
            return left.Id != right.Id;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is UserId id && Equals(id);
        }

        /// <inheritdoc/>
        public bool Equals(UserId other) => Id == other.Id;

        /// <inheritdoc/>
        public override int GetHashCode() => Id.GetHashCode(StringComparison.Ordinal);
    }
}
