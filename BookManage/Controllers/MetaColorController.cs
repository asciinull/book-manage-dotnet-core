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
    [Route("api/meta-color")]
    public class MetaColorController : BaseController
    {
        private IMetaColorProvider metaColorProvider;

        public MetaColorController(IMetaColorProvider metaColorProvider)
        {
            this.metaColorProvider = metaColorProvider;
        }

        [HttpPost]
        [Route("items")]
        public MetaColorItemsResponse Items([FromBody]MetaColorItemsRequest request)
        {
            MetaColorItemsResponse response = new MetaColorItemsResponse();

            response.Items = metaColorProvider.GetMetadataList();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("selected-item")]
        public MetaColorSelectedItemResponse SelectedItem([FromBody]MetaColorSelectedItemRequest request)
        {
            MetaColorSelectedItemResponse response = new MetaColorSelectedItemResponse();

            if (request == null)
            {
                response.Status = 1;
                return response;
            }

            if (request.ColorId <= 0)
            {
                response.Status = 1;
                return response;
            }

            response.Item = metaColorProvider.ToMetadata(request.ColorId);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("selected-items")]
        public MetaColorSelectedItemsResponse SelectedItems([FromBody]MetaColorSelectedItemsRequest request)
        {
            MetaColorSelectedItemsResponse response = new MetaColorSelectedItemsResponse();

            if (request == null)
            {
                response.Status = 1;
                return response;
            }

            if (request.ColorId == null || request.ColorId.Count == 0)
            {
                response.Status = 1;
                return response;
            }

            response.Items = metaColorProvider.ToMetadataList(request.ColorId);

            response.Status = 1;
            return response;
        }
    }
}
