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
    [Route("api/category")]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private ICategoryRepository categoryRepository;

        private ICategoryConvertor categoryConvertor;

        private IMetaCategoryProvider metaCategoryProvider;

        public CategoryController(
            IMetaCategoryProvider metaCategoryProvider,
            ICategoryRepository categoryRepository,
            ICategoryConvertor categoryConvertor)
        {
            this.categoryRepository = categoryRepository;
            this.categoryConvertor = categoryConvertor;
            this.metaCategoryProvider = metaCategoryProvider;
        }

        [HttpPost]
        [Route("items")]
        public CategoryItemsResponse Items([FromBody]CategoryItemsRequest request)
        {
            CategoryItemsResponse response = new CategoryItemsResponse();

            List<CategoryEntity> entityList = categoryRepository.GetPagedEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = categoryConvertor.toExtendedVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public CategoryCountResponse Count([FromBody]CategoryCountRequest request)
        {
            CategoryCountResponse response = new CategoryCountResponse();

            int count = categoryRepository.GetTotalCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public CategoryItemResponse Item([FromBody]CategoryItemRequest request)
        {
            CategoryItemResponse response = new CategoryItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            CategoryEntity entity = categoryRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = categoryConvertor.toExtendedVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public CategoryCreateResponse Create([FromBody]CategoryCreateRequest request)
        {
            CategoryCreateResponse response = new CategoryCreateResponse();

            categoryRepository.Create(categoryConvertor.toEntity(request));

            metaCategoryProvider.Reload();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("basic")]
        public CategoryBasicResponse Basic([FromBody]CategoryBasicRequest request)
        {

            CategoryBasicResponse response = new CategoryBasicResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            CategoryEntity entity = categoryRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = categoryConvertor.toBasicVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public CategoryUpdateResponse Update([FromBody]CategoryUpdateRequest request)
        {

            CategoryUpdateResponse response = new CategoryUpdateResponse();

            if (request.Id == 0 || request.Id < 0)
            {
                response.Status = -1;
                return response;
            }

            CategoryEntity entity = categoryRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            categoryRepository.Update(categoryConvertor.toEntity(request, entity));

            metaCategoryProvider.Reload();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("enable")]
        public CategoryEnableResponse Enable([FromBody]CategoryEnableRequest request)
        {
            CategoryEnableResponse response = new CategoryEnableResponse();

            categoryRepository.Enable(request.Id);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("disable")]
        public CategoryDisableResponse Disable([FromBody]CategoryDisableRequest request)
        {
            CategoryDisableResponse response = new CategoryDisableResponse();

            categoryRepository.Disable(request.Id);

            response.Status = 1;
            return response;
        }
    }
}
