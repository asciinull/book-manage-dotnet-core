using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using BookManage.Vo;

namespace BookManage.Controllers.Response
{
    public class TheBookBasicResponse : BaseResponse
    {
        [JsonProperty("item")]
        public TheBookBasicVo Item { get; set; }
    }
}
