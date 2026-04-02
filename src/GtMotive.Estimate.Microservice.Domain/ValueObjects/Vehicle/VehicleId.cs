using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle
{
    /// <summary>
    /// Vehicle value object.
    /// </summary>
    public readonly struct VehicleId : IEquatable<VehicleId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleId"/> struct.
        /// </summary>
        /// <param name="id">Vehicle id.</param>
        public VehicleId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new ArgumentException("Vehicle id can not be empty", nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Gets the vehicle id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>Equality.</returns>
        public static bool operator ==(VehicleId left, VehicleId right)
        {
            return left.Id == right.Id;
        }

        /// <summary>
        /// Inequiality operator.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>Inequality.</returns>
        public static bool operator !=(VehicleId left, VehicleId right)
        {
            return left.Id != right.Id;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => Id.GetHashCode();

        /// <inheritdoc/>
        public bool Equals(VehicleId obj)
        {
            return Id == obj.Id;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is VehicleId id && Equals(id);
        }
    }
}
