using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targe21house.Core.Domain
{
    public class House
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public string RoomCount { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public DateTime BuiltDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
