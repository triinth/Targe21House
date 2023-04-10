using Microsoft.EntityFrameworkCore;
using targe21house.Core.Domain;
using targe21house.Core.Dto;
using targe21house.Core.ServiceInterface;
using targe21house.Data;

namespace targe21house.ApplicationServices.Services
{
    public class HousesServices : IHousesServices
    {
        private readonly targe21houseContext _context;

        public HousesServices
            (
                targe21houseContext context

            )
        {
            _context = context;

        }

        public async Task<House> Create(HouseDto dto)
        {
            House house = new House();

            house.Id = Guid.NewGuid();
            house.Address = dto.Address;
            house.RoomCount = dto.RoomCount;
            house.Size = dto.Size;
            house.Price = dto.Price;
            house.BuiltDate = dto.BuiltDate;
            house.Country = dto.Country;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<House> Update(HouseDto dto)
        {
            House house = new();

            house.Address = dto.Address;
            house.RoomCount = dto.RoomCount;
            house.Size = dto.Size;
            house.Price = dto.Price;
            house.BuiltDate = dto.BuiltDate;
            house.Country = dto.Country;
            house.CreatedAt = dto.CreatedAt;
            house.ModifiedAt = DateTime.Now;

            _context.Houses.Update(house);
            await _context.SaveChangesAsync();

            return house;
        }


        public async Task<House> Delete(Guid? id)
        {
            var houseId = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);


            _context.Houses.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }

        public async Task<House> GetAsync(Guid? id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
