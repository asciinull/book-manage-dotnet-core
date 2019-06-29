using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookManage.Metadata;
using BookManage.Controllers.Request;
using BookManage.Repository.Entity;
using BookManage.Vo;
using BookManage.Utility;

namespace BookManage.Convertor
{
    public class TheBookConvertor : ITheBookConvertor
    {

        private IMetaCategoryProvider metaCategoryProvider;

        private IMetaColorProvider metaColorProvider;

        public TheBookConvertor(
            IMetaCategoryProvider metaCategoryProvider,
            IMetaColorProvider metaColorProvider
        )
        {
            this.metaCategoryProvider = metaCategoryProvider;
            this.metaColorProvider = metaColorProvider;
        }

        public TheBookEntity toEntity(TheBookCreateRequest request)
        {
            TheBookEntity entity = new TheBookEntity();

            var item = request.Item;

            entity.Title = item.Title;
            entity.CategoryIds = item.CategoryIds != null ? string.Join(";", item.CategoryIds) : null;
            entity.ColorId = item.ColorId;
            entity.DataStatus = 1;
            entity.CreateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        public TheBookEntity toEntity(TheBookUpdateRequest request, TheBookEntity oldEntity)
        {
            TheBookEntity entity = new TheBookEntity();

            var item = request.Item;

            entity.Id = request.Id;
            entity.Title = item.Title;
            entity.CategoryIds = item.CategoryIds != null ? string.Join(";", item.CategoryIds) : null;
            entity.ColorId = item.ColorId;
            entity.DataStatus = oldEntity.DataStatus;
            entity.CreateTime =  oldEntity.CreateTime;
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public TheBookBasicVo toBasicVo(TheBookEntity entity)
        {
            TheBookBasicVo vo = new TheBookBasicVo();

            CopyToVo(vo, entity);

            if (!string.IsNullOrEmpty(entity.CategoryIds))
            {
                vo.CategoryIds = entity.CategoryIds.Split(";").ToList();
            }
            vo.ColorId = entity.ColorId;

            return vo;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public TheBookExtendedVo toExtendedVo(TheBookEntity entity)
        {
            TheBookExtendedVo vo = new TheBookExtendedVo();

            CopyToVo(vo, entity);
            if (!string.IsNullOrEmpty(entity.CategoryIds))
            {
                var items = entity.CategoryIds.Split(";").ToList();
                vo.CategoryIds = metaCategoryProvider.ToMetadataList(items);
            }
            vo.ColorId = metaColorProvider.ToMetadata(entity.ColorId);

            return vo;
        }

        public List<TheBookBasicVo> toBasicVoList(List<TheBookEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<TheBookBasicVo> voList = new List<TheBookBasicVo>();
            foreach (TheBookEntity entity in entityList)
            {
                TheBookBasicVo vo = toBasicVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<TheBookExtendedVo> toExtendedVoList(List<TheBookEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<TheBookExtendedVo> voList = new List<TheBookExtendedVo>();
            foreach (TheBookEntity entity in entityList)
            {
                TheBookExtendedVo vo = toExtendedVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private void CopyToVo(TheBookVo vo,TheBookEntity entity)
        {
            vo.Id = entity.Id;
            vo.Title = entity.Title;
            vo.DataStatus = entity.DataStatus;
            vo.CreateTime = entity.CreateTime;
            vo.LastUpdateTime = entity.LastUpdateTime;
        }
    }
}
