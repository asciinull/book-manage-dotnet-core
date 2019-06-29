using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using BookManage.Repository.Entity;

namespace BookManage.Repository.Mysql
{
    public class MysqlColorRepository : IColorRepository
    {

        private MysqlConnectionProvider connectionProvider;

        public MysqlColorRepository(MysqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>实体</returns>
        public ColorEntity GetById(int id)
        {
            string sql = @"
select
  id as Id,
  color_id as ColorId,
  color_name as ColorName,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from color
where
  id = ?
  and data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<ColorEntity>(sql, new { id = id });
            }
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体列表</returns>
        public List<ColorEntity> GetEntityList()
        {
            string sql = @"
select
  id as Id,
  color_id as ColorId,
  color_name as ColorName,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from color
where
  data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<ColorEntity>(sql).ToList();
            }
        }

        /// <summary>
        /// 分页获取实体列表
        /// </summary>
        /// <param name="pageIndex">页码，从1开始</param>
        /// <param name="pageSize">每页个数</param>
        /// <returns>实体列表</returns>
        public List<ColorEntity> GetPagedEntityList(int pageIndex, int pageSize)
        {
            string sql = @"
select
  id as Id,
  color_id as ColorId,
  color_name as ColorName,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from color
where
  data_status = 1
limit @Start, @Count";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<ColorEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        /// <summary>
        /// 获取实体总个数
        /// </summary>
        public int GetTotalCount()
        {
            string sql = @"select count(1) from color";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QuerySingle<int>(sql);
            }
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        public void Create(ColorEntity entity)
        {
            string sql = @"
insert into color(color_id, color_name, data_status, create_time, last_update_time)
values(@ColorId, @ColorName, @DataStatus, @CreateTime, @LastUpdateTime);";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        public void Update(ColorEntity entity)
        {
            string sql = @"
update color
set 
  color_id = @ColorId,
  color_name = @ColorName,
  data_status = @DataStatus,
  create_time = @CreateTime,
  last_update_time = @LastUpdateTime,
  id = id
where
  id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 启用实体
        /// </summary>
        public void Enable(int id)
        {
            string sql = @"update color set data_status = 1 where id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, new { Id = id });
            }
        }

        /// <summary>
        /// 禁用实体
        /// </summary>
        public void Disable(int id)
        {
            string sql = @"update color set data_status = 2 where id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, new { Id = id });
            }
        }
    }
}
