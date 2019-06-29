using BookManage.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Controllers.Response
{
    public class MetaCategoryItemsResponse : BaseResponse
    {
        [JsonProperty("items")]
        public List<MetaCategoryVo> Items { get; set; }
    }
}
