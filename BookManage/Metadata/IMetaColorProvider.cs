using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookManage.Repository.Entity;
using BookManage.Vo;

namespace BookManage.Metadata
{
    public interface IMetaColorProvider
    {
        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        List<MetaColorVo> GetMetadataList();

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        MetaColorVo ToMetadata(int key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<MetaColorVo> ToMetadataList(List<int> keys);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        Dictionary<int, MetaColorVo> ToMetadataMap(List<int> keys);

        /// <summary>
        /// 加载缓存
        /// </summary>
        void Load();

        /// <summary>
        /// 刷新缓存
        /// </summary>
        void Reload();
    }
}