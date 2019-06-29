using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Controllers.Request
{
    public class ColorItemsRequest : ColorCountRequest
    {
        public int PageIndex { get; set; }
    }
}
