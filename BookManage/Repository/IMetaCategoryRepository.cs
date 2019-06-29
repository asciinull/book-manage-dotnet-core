using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookManage.Repository.Entity;

namespace BookManage.Repository
{
    public interface IMetaCategoryRepository
    {
        /// <summary>
        /// 获取所有实体
        /// </summary>
        List<MetaCategoryEntity> GetEntityList();

        /// <summary>
        /// 获取单个实体
        /// </summary>
        MetaCategoryEntity GetById(int id);
    }
}
