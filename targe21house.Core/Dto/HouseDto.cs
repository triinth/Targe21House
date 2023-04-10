
namespace targe21house.Core.Dto
{
    public class HouseDto
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public int RoomCount { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public DateTime BuiltDate { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}