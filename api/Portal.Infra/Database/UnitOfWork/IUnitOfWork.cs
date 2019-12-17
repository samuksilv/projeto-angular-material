using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Portal.Infra.Database.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit(IDbContextTransaction transaction);
        void Rollback(IDbContextTransaction transaction);
    }
}