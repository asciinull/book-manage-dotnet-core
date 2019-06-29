using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Repository.Entity
{
    public class TheBookEntity
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryIds { get; set; }

        public string ColorId { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
