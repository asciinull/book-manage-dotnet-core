using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Vo
{
    public class TheBookExtendedVo : TheBookVo
    {

        [JsonProperty("categoryIds")]
        public List<MetaCategoryVo> CategoryIds { get; set; }

        [JsonProperty("colorId")]
        public MetaColorVo ColorId { get; set; }
    }
}
