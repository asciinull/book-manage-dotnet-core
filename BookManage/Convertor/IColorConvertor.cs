using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Convertor
{
    public interface IColorConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        ColorEntity toEntity(ColorCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        ColorEntity toEntity(ColorUpdateRequest request, ColorEntity oldEntity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        ColorBasicVo toBasicVo(ColorEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<ColorBasicVo> toBasicVoList(List<ColorEntity> entityList);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        ColorExtendedVo toExtendedVo(ColorEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<ColorExtendedVo> toExtendedVoList(List<ColorEntity> entityList);
    }
}
