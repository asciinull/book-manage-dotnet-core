using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using BookManage.Repository.Entity;

namespace BookManage.Repository.Mysql
{
    public class MysqlCategoryRepository : ICategoryRepository
    {

        private MysqlConnectionProvider connectionProvider;

        public MysqlCategoryRepository(MysqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>实体</returns>
        public CategoryEntity GetById(int id)
        {
            string sql = @"
select
  id as Id,
  name as Name,
  description as Description,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from category
where
  id = ?
  and data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<CategoryEntity>(sql, new { id = id });
            }
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体列表</returns>
        public List<CategoryEntity> GetEntityList()
        {
            string sql = @"
select
  id as Id,
  name as Name,
  description as Description,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from category
where
  data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<CategoryEntity>(sql).ToList();
            }
        }

        /// <summary>
        /// 分页获取实体列表
        /// </summary>
        /// <param name="pageIndex">页码，从1开始</param>
        /// <param name="pageSize">每页个数</param>
        /// <returns>实体列表</returns>
        public List<CategoryEntity> GetPagedEntityList(int pageIndex, int pageSize)
        {
            string sql = @"
select
  id as Id,
  name as Name,
  description as Description,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from category
where
  data_status = 1
limit @Start, @Count";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<CategoryEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        /// <summary>
        /// 获取实体总个数
        /// </summary>
        public int GetTotalCount()
        {
            string sql = @"select count(1) from category";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QuerySingle<int>(sql);
            }
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        public void Create(CategoryEntity entity)
        {
            string sql = @"
insert into category(name, description, data_status, create_time, last_update_time)
values(@Name, @Description, @DataStatus, @CreateTime, @LastUpdateTime);";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        public void Update(CategoryEntity entity)
        {
            string sql = @"
update category
set 
  name = @Name,
  description = @Description,
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
            string sql = @"update category set data_status = 1 where id = @Id;";

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
            string sql = @"update category set data_status = 2 where id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, new { Id = id });
            }
        }
    }
}
