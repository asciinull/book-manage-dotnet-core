using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Convertor
{
    public interface ITheBookConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        TheBookEntity toEntity(TheBookCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        TheBookEntity toEntity(TheBookUpdateRequest request, TheBookEntity oldEntity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        TheBookBasicVo toBasicVo(TheBookEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<TheBookBasicVo> toBasicVoList(List<TheBookEntity> entityList);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        TheBookExtendedVo toExtendedVo(TheBookEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<TheBookExtendedVo> toExtendedVoList(List<TheBookEntity> entityList);
    }
}
