using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Convertor
{
    public class MetaColorConvertor : IMetaColorConvertor
    {
        public MetaColorVo toVo(MetaColorEntity entity)
        {
            MetaColorVo vo = new MetaColorVo();

            vo.ColorId = entity.ColorId;
            vo.ColorName = entity.ColorName;

            return vo;
        }

        public List<MetaColorVo> toVoList(List<MetaColorEntity> entityList)
        {
            if (entityList == null) {
                return null;
            }

            List<MetaColorVo> voList = new List<MetaColorVo>();
            foreach (MetaColorEntity entity in entityList)
            {

                MetaColorVo vo = toVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public MetaColorVo toVo(List<MetaColorEntity> entityList, int key)
        {
            if (entityList == null) {
                return null;
            }

            foreach (MetaColorEntity entity in entityList)
            {
                if (entity.ColorId == key)
                {
                    return toVo(entity);
                }
            }

            return null;
        }

        public List<MetaColorVo> toVoList(List<MetaColorEntity> entityList, List<int> keys)
        {
            if (entityList == null)
            {
                return null;
            }

            List<MetaColorVo> voList = new List<MetaColorVo>();
            foreach (MetaColorEntity entity in entityList)
            {
                if (!keys.Contains(entity.ColorId))
                {
                    continue;
                }

                MetaColorVo vo = toVo(entity);
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
