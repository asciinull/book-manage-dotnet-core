using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using BookManage.Vo;

namespace BookManage.Controllers.Request
{
    public class TheBookCreateRequest
    {

        [JsonProperty("item")]
        public TheBookBasicVo Item { get; set; }
    }
}
