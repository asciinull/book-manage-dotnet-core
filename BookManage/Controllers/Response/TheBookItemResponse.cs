using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookManage.Vo;

namespace BookManage.Controllers.Response
{
    public class TheBookItemResponse : BaseResponse
    {
        [JsonProperty("item")]
        public TheBookExtendedVo Item { get; set; }
    }
}
