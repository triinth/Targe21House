using Microsoft.AspNetCore.Mvc;

namespace Targe21House.Models.House
{
    public class HouseIndexViewModel : Controller
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
