using BookManage.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Controllers.Response
{
    public class MetaColorSelectedItemResponse : BaseResponse
    {
        [JsonProperty("item")]
        public MetaColorVo Item { get; set; }
    }
}
