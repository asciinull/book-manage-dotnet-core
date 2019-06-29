using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManage.Repository.Entity
{
    public class ColorEntity
    {

        public int Id { get; set; }

        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
