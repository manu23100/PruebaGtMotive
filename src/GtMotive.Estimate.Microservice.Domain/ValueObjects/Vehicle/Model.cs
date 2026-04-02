using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle
{
    /// <summary>
    /// Vehicle model value object.
    /// </summary>
    public readonly struct Model
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> struct.
        /// </summary>
        /// <param name="vehicleModel">Model of the vehicle.</param>
        public Model(string vehicleModel)
        {
            if (string.IsNullOrEmpty(vehicleModel))
            {
                throw new ModelNotValidException();
            }

            VehicleModel = vehicleModel;
        }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string VehicleModel { get; }
    }
}
