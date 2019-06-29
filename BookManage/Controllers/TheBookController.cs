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

namespace BookManage.Controllers
{
    [Route("api/the-book")]
    public class TheBookController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private ITheBookRepository theBookRepository;

        private ITheBookConvertor theBookConvertor;

        public TheBookController(
            ITheBookRepository theBookRepository,
            ITheBookConvertor theBookConvertor)
        {
            this.theBookRepository = theBookRepository;
            this.theBookConvertor = theBookConvertor;
        }

        [HttpPost]
        [Route("items")]
        public TheBookItemsResponse Items([FromBody]TheBookItemsRequest request)
        {
            TheBookItemsResponse response = new TheBookItemsResponse();

            List<TheBookEntity> entityList = theBookRepository.GetPagedEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = theBookConvertor.toExtendedVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public TheBookCountResponse Count([FromBody]TheBookCountRequest request)
        {
            TheBookCountResponse response = new TheBookCountResponse();

            int count = theBookRepository.GetTotalCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public TheBookItemResponse Item([FromBody]TheBookItemRequest request)
        {
            TheBookItemResponse response = new TheBookItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            TheBookEntity entity = theBookRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = theBookConvertor.toExtendedVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public TheBookCreateResponse Create([FromBody]TheBookCreateRequest request)
        {
            TheBookCreateResponse response = new TheBookCreateResponse();

            theBookRepository.Create(theBookConvertor.toEntity(request));

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("basic")]
        public TheBookBasicResponse Basic([FromBody]TheBookBasicRequest request)
        {

            TheBookBasicResponse response = new TheBookBasicResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            TheBookEntity entity = theBookRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = theBookConvertor.toBasicVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public TheBookUpdateResponse Update([FromBody]TheBookUpdateRequest request)
        {

            TheBookUpdateResponse response = new TheBookUpdateResponse();

            if (request.Id == 0 || request.Id < 0)
            {
                response.Status = -1;
                return response;
            }

            TheBookEntity entity = theBookRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            theBookRepository.Update(theBookConvertor.toEntity(request, entity));

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("enable")]
        public TheBookEnableResponse Enable([FromBody]TheBookEnableRequest request)
        {
            TheBookEnableResponse response = new TheBookEnableResponse();

            theBookRepository.Enable(request.Id);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("disable")]
        public TheBookDisableResponse Disable([FromBody]TheBookDisableRequest request)
        {
            TheBookDisableResponse response = new TheBookDisableResponse();

            theBookRepository.Disable(request.Id);

            response.Status = 1;
            return response;
        }
    }
}
