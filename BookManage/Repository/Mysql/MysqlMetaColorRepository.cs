using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using BookManage.Repository.Entity;

namespace BookManage.Repository.Mysql
{
    public class MysqlMetaColorRepository : IMetaColorRepository
    {

        private MysqlConnectionProvider connectionProvider;

        public MysqlMetaColorRepository(MysqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public MetaColorEntity GetById(int id)
        {
            string sql = "select color_id as ColorId, color_name as ColorName from color where Id = ?";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<MetaColorEntity>(sql, new { Id = id });
            }
        }

        public List<MetaColorEntity> GetEntityList()
        {
            string sql = "select color_id as ColorId, color_name as ColorName from color";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<MetaColorEntity>(sql).ToList();
            }
        }
    }
}
