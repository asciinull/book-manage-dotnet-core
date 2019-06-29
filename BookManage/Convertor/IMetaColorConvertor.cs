using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Convertor
{
    public interface IMetaColorConvertor
    {

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        MetaColorVo toVo(MetaColorEntity entity);

        /// <summary>
        /// 获取所有的选项
        /// </summary>
        List<MetaColorVo> toVoList(List<MetaColorEntity> entityList);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        MetaColorVo toVo(List<MetaColorEntity> entityList, int key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<MetaColorVo> toVoList(List<MetaColorEntity> entityList, List<int> keys);
    }
}
