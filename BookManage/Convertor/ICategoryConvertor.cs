using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Convertor
{
    public interface ICategoryConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        CategoryEntity toEntity(CategoryCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        CategoryEntity toEntity(CategoryUpdateRequest request, CategoryEntity oldEntity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        CategoryBasicVo toBasicVo(CategoryEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<CategoryBasicVo> toBasicVoList(List<CategoryEntity> entityList);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        CategoryExtendedVo toExtendedVo(CategoryEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<CategoryExtendedVo> toExtendedVoList(List<CategoryEntity> entityList);
    }
}
