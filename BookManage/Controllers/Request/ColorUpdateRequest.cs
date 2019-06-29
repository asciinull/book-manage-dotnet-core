using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using BookManage.Vo;

namespace BookManage.Controllers.Request
{
    public class ColorUpdateRequest
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("item")]
        public ColorBasicVo Item { get; set; }
    }
}
