using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using BookManage.Utility;

namespace BookManage.Convertor
{
    public class ColorConvertor : IColorConvertor
    {

        public ColorEntity toEntity(ColorCreateRequest request)
        {
            ColorEntity entity = new ColorEntity();

            var item = request.Item;

            entity.ColorId = item.ColorId;
            entity.ColorName = item.ColorName;
            entity.DataStatus = 1;
            entity.CreateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        public ColorEntity toEntity(ColorUpdateRequest request, ColorEntity oldEntity)
        {
            ColorEntity entity = new ColorEntity();

            var item = request.Item;

            entity.Id = request.Id;
            entity.ColorId = item.ColorId;
            entity.ColorName = item.ColorName;
            entity.DataStatus = oldEntity.DataStatus;
            entity.CreateTime =  oldEntity.CreateTime;
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public ColorBasicVo toBasicVo(ColorEntity entity)
        {
            ColorBasicVo vo = new ColorBasicVo();

            CopyToVo(vo, entity);


            return vo;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public ColorExtendedVo toExtendedVo(ColorEntity entity)
        {
            ColorExtendedVo vo = new ColorExtendedVo();

            CopyToVo(vo, entity);

            return vo;
        }

        public List<ColorBasicVo> toBasicVoList(List<ColorEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<ColorBasicVo> voList = new List<ColorBasicVo>();
            foreach (ColorEntity entity in entityList)
            {
                ColorBasicVo vo = toBasicVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<ColorExtendedVo> toExtendedVoList(List<ColorEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<ColorExtendedVo> voList = new List<ColorExtendedVo>();
            foreach (ColorEntity entity in entityList)
            {
                ColorExtendedVo vo = toExtendedVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private void CopyToVo(ColorVo vo,ColorEntity entity)
        {
            vo.Id = entity.Id;
            vo.ColorId = entity.ColorId;
            vo.ColorName = entity.ColorName;
            vo.DataStatus = entity.DataStatus;
            vo.CreateTime = entity.CreateTime;
            vo.LastUpdateTime = entity.LastUpdateTime;
        }
    }
}
