using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class BaseDapperRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IConfiguration _config;

        public BaseDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        protected IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public virtual void Create(TEntity item)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Insert(item);
            }
        }

        public virtual void Update(TEntity item)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Update(item);
            }
        }

        public virtual void Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Delete(new { id });
            }
        }

        public TEntity Get(int id)
        {
            TEntity item = default;

            using (IDbConnection conn = Connection)
            {
                item = conn.Get<TEntity>(new { id });
            }

            return item;
        }

        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> items = null;

            using (IDbConnection conn = Connection)
            {
                items = conn.GetAll<TEntity>().AsEnumerable();
            }

            return items;
        }
    }
}
