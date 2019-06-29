using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Vo
{
    public abstract class CategoryVo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dataStatus")]
        public int DataStatus { get; set; }

        [JsonProperty("createTime")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("lastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }
    }
}
