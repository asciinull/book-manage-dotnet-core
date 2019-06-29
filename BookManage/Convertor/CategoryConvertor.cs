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
    public class CategoryConvertor : ICategoryConvertor
    {

        public CategoryEntity toEntity(CategoryCreateRequest request)
        {
            CategoryEntity entity = new CategoryEntity();

            var item = request.Item;

            entity.Name = item.Name;
            entity.Description = item.Description;
            entity.DataStatus = 1;
            entity.CreateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        public CategoryEntity toEntity(CategoryUpdateRequest request, CategoryEntity oldEntity)
        {
            CategoryEntity entity = new CategoryEntity();

            var item = request.Item;

            entity.Id = request.Id;
            entity.Name = item.Name;
            entity.Description = item.Description;
            entity.DataStatus = oldEntity.DataStatus;
            entity.CreateTime =  oldEntity.CreateTime;
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public CategoryBasicVo toBasicVo(CategoryEntity entity)
        {
            CategoryBasicVo vo = new CategoryBasicVo();

            CopyToVo(vo, entity);


            return vo;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public CategoryExtendedVo toExtendedVo(CategoryEntity entity)
        {
            CategoryExtendedVo vo = new CategoryExtendedVo();

            CopyToVo(vo, entity);

            return vo;
        }

        public List<CategoryBasicVo> toBasicVoList(List<CategoryEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<CategoryBasicVo> voList = new List<CategoryBasicVo>();
            foreach (CategoryEntity entity in entityList)
            {
                CategoryBasicVo vo = toBasicVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<CategoryExtendedVo> toExtendedVoList(List<CategoryEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<CategoryExtendedVo> voList = new List<CategoryExtendedVo>();
            foreach (CategoryEntity entity in entityList)
            {
                CategoryExtendedVo vo = toExtendedVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private void CopyToVo(CategoryVo vo,CategoryEntity entity)
        {
            vo.Id = entity.Id;
            vo.Name = entity.Name;
            vo.Description = entity.Description;
            vo.DataStatus = entity.DataStatus;
            vo.CreateTime = entity.CreateTime;
            vo.LastUpdateTime = entity.LastUpdateTime;
        }
    }
}
