using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// Unit of work for Mongo persistence.
    /// </summary>
    public sealed class MongoUnitOfWork : IUnitOfWork
    {
        /// <inheritdoc />
        public Task<int> Save()
        {
            return Task.FromResult(1);
        }
    }
}
