using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BookManage.Controllers.Request;
using BookManage.Controllers.Response;
using BookManage.Metadata;

namespace BookManage.Controllers
{
    [Route("api/meta-category")]
    public class MetaCategoryController : BaseController
    {
        private IMetaCategoryProvider metaCategoryProvider;

        public MetaCategoryController(IMetaCategoryProvider metaCategoryProvider)
        {
            this.metaCategoryProvider = metaCategoryProvider;
        }

        [HttpPost]
        [Route("items")]
        public MetaCategoryItemsResponse Items([FromBody]MetaCategoryItemsRequest request)
        {
            MetaCategoryItemsResponse response = new MetaCategoryItemsResponse();

            response.Items = metaCategoryProvider.GetMetadataList();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("selected-item")]
        public MetaCategorySelectedItemResponse SelectedItem([FromBody]MetaCategorySelectedItemRequest request)
        {
            MetaCategorySelectedItemResponse response = new MetaCategorySelectedItemResponse();

            if (request == null)
            {
                response.Status = 1;
                return response;
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                response.Status = 1;
                return response;
            }

            response.Item = metaCategoryProvider.ToMetadata(request.Name);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("selected-items")]
        public MetaCategorySelectedItemsResponse SelectedItems([FromBody]MetaCategorySelectedItemsRequest request)
        {
            MetaCategorySelectedItemsResponse response = new MetaCategorySelectedItemsResponse();

            if (request == null)
            {
                response.Status = 1;
                return response;
            }

            if (request.Name == null || request.Name.Count == 0)
            {
                response.Status = 1;
                return response;
            }

            response.Items = metaCategoryProvider.ToMetadataList(request.Name);

            response.Status = 1;
            return response;
        }
    }
}
