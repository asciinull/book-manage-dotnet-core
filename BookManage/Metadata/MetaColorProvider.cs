using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookManage.Convertor;
using BookManage.Repository;
using BookManage.Repository.Entity;
using BookManage.Vo;

namespace BookManage.Metadata
{
    public class MetaColorProvider : IMetaColorProvider
    {
        private IMetaColorRepository metaColorRepository;
        private IMetaColorConvertor metaColorConvertor;

        private Dictionary<int, MetaColorVo> map = new Dictionary<int, MetaColorVo>();

        public MetaColorProvider(IMetaColorRepository metaColorRepository, IMetaColorConvertor metaColorConvertor)
        {
            this.metaColorRepository = metaColorRepository;
            this.metaColorConvertor = metaColorConvertor;
        }

        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        public List<MetaColorVo> GetMetadataList()
        {
            return map.Values.ToList();
        }

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        public MetaColorVo ToMetadata(int key)
        {
            if (!map.ContainsKey(key))
            {
                return null;
            }

            return map[key];
        }

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        public List<MetaColorVo> ToMetadataList(List<int> keys)
        {
            if (keys == null)
            {
                return null;
            }

            List<MetaColorVo> voList = new List<MetaColorVo>();
            foreach (var key in keys)
            {
                if (!map.ContainsKey(key))
                {
                    continue;
                }

                voList.Add(map[key]);
            }

            return voList;
        }

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        public Dictionary<int, MetaColorVo> ToMetadataMap(List<int> keys)
        {
            if (keys == null)
            {
                return null;
            }

            Dictionary<int, MetaColorVo> returnValue = new Dictionary<int, MetaColorVo>();
            foreach (var key in keys)
            {
                if (returnValue.ContainsKey(key))
                {
                    continue;
                }

                if (!map.ContainsKey(key))
                {
                    continue;
                }

                returnValue.Add(key, map[key]);
            }

            return returnValue;
        }

        /// <summary>
        /// 加载缓存
        /// </summary>
        public void Load()
        {
            var entityList = metaColorRepository.GetEntityList();
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            var voList = metaColorConvertor.toVoList(entityList);
            if (voList == null || voList.Count == 0)
            {
                return;
            }

            foreach (var vo in voList)
            {
                map.Add(vo.ColorId, vo);
            }
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        public void Reload()
        {
            var entityList = metaColorRepository.GetEntityList();
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            var voList = metaColorConvertor.toVoList(entityList);
            if (voList == null || voList.Count == 0)
            {
                return;
            }

            var newMap = new Dictionary<int, MetaColorVo>();
            foreach (var vo in voList)
            {
                newMap.Add(vo.ColorId, vo);
            }

            map = newMap;
        }
    }
}
