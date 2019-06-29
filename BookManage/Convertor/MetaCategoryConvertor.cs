using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Convertor
{
    public class MetaCategoryConvertor : IMetaCategoryConvertor
    {
        public MetaCategoryVo toVo(MetaCategoryEntity entity)
        {
            MetaCategoryVo vo = new MetaCategoryVo();

            vo.Name = entity.Name;
            vo.Description = entity.Description;

            return vo;
        }

        public List<MetaCategoryVo> toVoList(List<MetaCategoryEntity> entityList)
        {
            if (entityList == null) {
                return null;
            }

            List<MetaCategoryVo> voList = new List<MetaCategoryVo>();
            foreach (MetaCategoryEntity entity in entityList)
            {

                MetaCategoryVo vo = toVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public MetaCategoryVo toVo(List<MetaCategoryEntity> entityList, string key)
        {
            if (entityList == null) {
                return null;
            }

            foreach (MetaCategoryEntity entity in entityList)
            {
                if (entity.Name == key)
                {
                    return toVo(entity);
                }
            }

            return null;
        }

        public List<MetaCategoryVo> toVoList(List<MetaCategoryEntity> entityList, List<string> keys)
        {
            if (entityList == null)
            {
                return null;
            }

            List<MetaCategoryVo> voList = new List<MetaCategoryVo>();
            foreach (MetaCategoryEntity entity in entityList)
            {
                if (!keys.Contains(entity.Name))
                {
                    continue;
                }

                MetaCategoryVo vo = toVo(entity);
                voList.Add(vo);

                if(voList.Count == keys.Count)
                {
                    break;
                }
            }

            return voList;
        }
    }
}
