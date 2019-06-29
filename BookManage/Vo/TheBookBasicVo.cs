using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Vo
{
    public class TheBookBasicVo : TheBookVo
    {

        [JsonProperty("categoryIds")]
        public List<string> CategoryIds { get; set; }

        [JsonProperty("colorId")]
        public int ColorId { get; set; }
    }
}
