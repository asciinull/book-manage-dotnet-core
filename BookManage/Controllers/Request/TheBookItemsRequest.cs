using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Controllers.Request
{
    public class TheBookItemsRequest : TheBookCountRequest
    {
        public int PageIndex { get; set; }
    }
}
