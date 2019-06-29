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
    public class MetaCategoryProvider : IMetaCategoryProvider
    {
        private IMetaCategoryRepository metaCategoryRepository;
        private IMetaCategoryConvertor metaCategoryConvertor;

        private Dictionary<string, MetaCategoryVo> map = new Dictionary<string, MetaCategoryVo>();

        public MetaCategoryProvider(IMetaCategoryRepository metaCategoryRepository, IMetaCategoryConvertor metaCategoryConvertor)
        {
            this.metaCategoryRepository = metaCategoryRepository;
            this.metaCategoryConvertor = metaCategoryConvertor;
        }

        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        public List<MetaCategoryVo> GetMetadataList()
        {
            return map.Values.ToList();
        }

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        public MetaCategoryVo ToMetadata(string key)
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
        public List<MetaCategoryVo> ToMetadataList(List<string> keys)
        {
            if (keys == null)
            {
                return null;
            }

            List<MetaCategoryVo> voList = new List<MetaCategoryVo>();
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
        public Dictionary<string, MetaCategoryVo> ToMetadataMap(List<string> keys)
        {
            if (keys == null)
            {
                return null;
            }

            Dictionary<string, MetaCategoryVo> returnValue = new Dictionary<string, MetaCategoryVo>();
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
            var entityList = metaCategoryRepository.GetEntityList();
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            var voList = metaCategoryConvertor.toVoList(entityList);
            if (voList == null || voList.Count == 0)
            {
                return;
            }

            foreach (var vo in voList)
            {
                map.Add(vo.Name, vo);
            }
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        public void Reload()
        {
            var entityList = metaCategoryRepository.GetEntityList();
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            var voList = metaCategoryConvertor.toVoList(entityList);
            if (voList == null || voList.Count == 0)
            {
                return;
            }

            var newMap = new Dictionary<string, MetaCategoryVo>();
            foreach (var vo in voList)
            {
                newMap.Add(vo.Name, vo);
            }

            map = newMap;
        }
    }
}
