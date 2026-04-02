namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the Has Conflict Output Port.
    /// </summary>
    public interface IOutputPortHasConflict
    {
        /// <summary>
        /// Informs that there is a conflict preventing the operation.
        /// </summary>
        /// <param name="message">Text description.</param>
        void HasConflictHandle(string message);
    }
}
