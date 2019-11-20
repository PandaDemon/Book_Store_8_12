using Dapper.Contrib.Extensions;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrintStore.DataAccess.Repositories.Base
{
    public class BaseDapperRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        private readonly string _connectionString;

        public BaseDapperRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
            _connectionString = _connectionStringProvider.GetConnectionString();
        }

        protected IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (IDbConnection db = Connection)
            {
                return await db.GetAllAsync<TEntity>();
            }
        }

        public async Task Delete(int id)
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            entity = await Get(id);

            using (IDbConnection db = Connection)
            {
                await db.DeleteAsync<TEntity>(entity);
            }
        }

        public async Task<TEntity> Get(int id)
        {
            using (IDbConnection db = Connection)
            {
                TEntity result = await db.GetAsync<TEntity>(id);

                return result;
            }
        }

        public async Task Create(TEntity item)
        {
            using (IDbConnection db = Connection)
            {
                await db.InsertAsync(item);
            }
        }

        public async Task Update(TEntity item)
        {
            using (IDbConnection db = Connection)
            {
                await db.UpdateAsync(item);
            }
        }
    }
}
