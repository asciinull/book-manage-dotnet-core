using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Vo
{
    public class MetaColorVo
    {
        [JsonProperty("colorId")]
        public int ColorId { get; set; }

        [JsonProperty("colorName")]
        public string ColorName { get; set; }
    }
}
