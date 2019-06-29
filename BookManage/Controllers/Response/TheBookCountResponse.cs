using BookManage.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Controllers.Response
{
    public class TheBookCountResponse : BaseResponse
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
