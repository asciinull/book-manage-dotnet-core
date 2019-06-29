using BookManage.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Controllers.Response
{
    public class TheBookItemsResponse : BaseResponse
    {
        [JsonProperty("items")]
        public List<TheBookExtendedVo> Items { get; set; }
    }
}
