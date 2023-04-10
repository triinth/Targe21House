using targe21house.Core.Domain;
using targe21house.Core.Dto;

namespace targe21house.Core.ServiceInterface
{
    public interface IHousesServices
    {
        Task<House> Create(HouseDto dto);
        Task<House> Update(HouseDto dto);
        Task<House> Delete(Guid? id);
        Task<House> GetAsync(Guid? id);

    }
}
