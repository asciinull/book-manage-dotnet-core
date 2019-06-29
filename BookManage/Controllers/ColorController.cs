using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BookManage.Controllers.Request;
using BookManage.Controllers.Response;
using BookManage.Convertor;
using BookManage.Repository;
using BookManage.Repository.Entity;
using BookManage.Metadata;

namespace BookManage.Controllers
{
    [Route("api/color")]
    public class ColorController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private IColorRepository colorRepository;

        private IColorConvertor colorConvertor;

        private IMetaColorProvider metaColorProvider;

        public ColorController(
            IMetaColorProvider metaColorProvider,
            IColorRepository colorRepository,
            IColorConvertor colorConvertor)
        {
            this.colorRepository = colorRepository;
            this.colorConvertor = colorConvertor;
            this.metaColorProvider = metaColorProvider;
        }

        [HttpPost]
        [Route("items")]
        public ColorItemsResponse Items([FromBody]ColorItemsRequest request)
        {
            ColorItemsResponse response = new ColorItemsResponse();

            List<ColorEntity> entityList = colorRepository.GetPagedEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = colorConvertor.toExtendedVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public ColorCountResponse Count([FromBody]ColorCountRequest request)
        {
            ColorCountResponse response = new ColorCountResponse();

            int count = colorRepository.GetTotalCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public ColorItemResponse Item([FromBody]ColorItemRequest request)
        {
            ColorItemResponse response = new ColorItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            ColorEntity entity = colorRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = colorConvertor.toExtendedVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public ColorCreateResponse Create([FromBody]ColorCreateRequest request)
        {
            ColorCreateResponse response = new ColorCreateResponse();

            colorRepository.Create(colorConvertor.toEntity(request));

            metaColorProvider.Reload();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("basic")]
        public ColorBasicResponse Basic([FromBody]ColorBasicRequest request)
        {

            ColorBasicResponse response = new ColorBasicResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            ColorEntity entity = colorRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = colorConvertor.toBasicVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public ColorUpdateResponse Update([FromBody]ColorUpdateRequest request)
        {

            ColorUpdateResponse response = new ColorUpdateResponse();

            if (request.Id == 0 || request.Id < 0)
            {
                response.Status = -1;
                return response;
            }

            ColorEntity entity = colorRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            colorRepository.Update(colorConvertor.toEntity(request, entity));

            metaColorProvider.Reload();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("enable")]
        public ColorEnableResponse Enable([FromBody]ColorEnableRequest request)
        {
            ColorEnableResponse response = new ColorEnableResponse();

            colorRepository.Enable(request.Id);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("disable")]
        public ColorDisableResponse Disable([FromBody]ColorDisableRequest request)
        {
            ColorDisableResponse response = new ColorDisableResponse();

            colorRepository.Disable(request.Id);

            response.Status = 1;
            return response;
        }
    }
}
