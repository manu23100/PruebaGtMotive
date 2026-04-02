using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// SQL Server implementation of the Unit of Work pattern using Entity Framework Core.
    /// </summary>
    public sealed class SqlServerUnitOfWork(SqlDbContext context) : IUnitOfWork
    {
        /// <inheritdoc/>
        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}
