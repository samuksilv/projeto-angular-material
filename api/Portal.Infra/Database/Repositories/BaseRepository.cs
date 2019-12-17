using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Portal.Domain.Contracts.Repositories;
using Portal.Domain.Models;
using Portal.Infra.Database.Contexts;
using Portal.Infra.Database.UnitOfWork;

namespace Portal.Infra.Database.Repositories {
    public abstract class BaseRepository<T> : IUnitOfWork, IBaseRepository<T> where T : BaseModel {

        protected readonly AppDbContext _dbContext;

        public BaseRepository (AppDbContext dbContext) {
            this._dbContext = dbContext;
        }

        public async virtual Task<T> SaveAsync (T model) {

            model.CreatedAt = DateTime.UtcNow;
            model.UpdatedAt = null;

            await _dbContext.AddAsync (model);

            return model;
        }

        public async virtual Task<T> UpdateAsync (T model) {

            return await Task.Run (() => {
                model.UpdatedAt = DateTime.UtcNow;

                _dbContext.Update (model);

                return model;
            });

        }

        public async virtual Task DeleteAsync (T model) {

            await Task.Run (() => {
                _dbContext.Remove (model);

            });
        }

        public abstract Task<T> GetByIdAsync (Guid id);

        public async Task<int> SaveChangesAsync () {
            return await _dbContext.SaveChangesAsync ();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await this._dbContext.Database.BeginTransactionAsync();
        }

        public void Commit(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();           
        }
    }
}