using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class BaseDapperRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IConfiguration _config;
        private readonly string _tableName;

        public BaseDapperRepository(IConfiguration config, string tableName)
        {
            _config = config;
            _tableName = tableName;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        internal virtual dynamic Mapping(TEntity item)
        {
            return item;
        }

        public virtual TEntity FindByID(Guid id)
        {
            TEntity item = default(TEntity);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                item = cn.Query<TEntity>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
            }

            return item;
        }

        public virtual void Create(TEntity item)
        {
            using (IDbConnection conn = Connection)
            {
                var parameters = (object)Mapping(item);

                item = conn.Insert<Guid>(_tableName, parameters);
            }
        }

        public virtual void Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Execute("DELETE FROM " + _tableName + " WHERE ID=@ID", new { ID = id });
            }
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity item)
        {
            using (IDbConnection conn = Connection)
            {
                var parameters = (object)Mapping(item);

                conn.Update(_tableName, parameters);
            }
        }
    }
}
