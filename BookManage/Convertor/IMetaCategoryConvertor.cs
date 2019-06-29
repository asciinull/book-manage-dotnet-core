using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Convertor
{
    public interface IMetaCategoryConvertor
    {

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        MetaCategoryVo toVo(MetaCategoryEntity entity);

        /// <summary>
        /// 获取所有的选项
        /// </summary>
        List<MetaCategoryVo> toVoList(List<MetaCategoryEntity> entityList);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        MetaCategoryVo toVo(List<MetaCategoryEntity> entityList, string key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<MetaCategoryVo> toVoList(List<MetaCategoryEntity> entityList, List<string> keys);
    }
}
