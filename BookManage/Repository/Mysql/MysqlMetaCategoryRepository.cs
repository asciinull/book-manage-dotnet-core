using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using BookManage.Repository.Entity;

namespace BookManage.Repository.Mysql
{
    public class MysqlMetaCategoryRepository : IMetaCategoryRepository
    {

        private MysqlConnectionProvider connectionProvider;

        public MysqlMetaCategoryRepository(MysqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public MetaCategoryEntity GetById(int id)
        {
            string sql = "select name as Name, description as Description from category where Id = ?";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<MetaCategoryEntity>(sql, new { Id = id });
            }
        }

        public List<MetaCategoryEntity> GetEntityList()
        {
            string sql = "select name as Name, description as Description from category";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<MetaCategoryEntity>(sql).ToList();
            }
        }
    }
}
