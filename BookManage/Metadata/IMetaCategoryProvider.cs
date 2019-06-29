using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookManage.Repository.Entity;
using BookManage.Vo;

namespace BookManage.Metadata
{
    public interface IMetaCategoryProvider
    {
        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        List<MetaCategoryVo> GetMetadataList();

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        MetaCategoryVo ToMetadata(string key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<MetaCategoryVo> ToMetadataList(List<string> keys);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        Dictionary<string, MetaCategoryVo> ToMetadataMap(List<string> keys);

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