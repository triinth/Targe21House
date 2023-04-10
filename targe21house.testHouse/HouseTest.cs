using targe21house.Core.Domain;
using targe21house.Core.Dto;
using targe21house.Core.ServiceInterface;
using Xunit;

namespace targe21house.testHouse
{
    public class testHouse : TestBase
    {

        [Fact]
        public async Task Create_ValidHouse_ShouldBeCreated()
        {
            DateTime testStart = DateTime.Now;
           HouseDto houseDto = CreateValidHouse();     

            var result = await Svc<IHousesServices>().Create(houseDto);
            AssertHouseFields(houseDto, result);
            Assert.True(testStart < result.CreatedAt);
            Assert.True(testStart < result.ModifiedAt);

        }

        [Fact]
        public async Task GetAsync_NoHouseDetailsShouldNotBeFound_WhenNoId()
        {
            Assert.Null(await Svc<IHousesServices>().GetAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetAsync_AllHouseDetailsShouldBeFound_WhenId()
        {
            HouseDto houseDto = CreateValidHouse();
            var createdNewHouse = await Svc<IHousesServices>().Create(houseDto);

            var result = await Svc<IHousesServices>().GetAsync((Guid)createdNewHouse.Id);

            Assert.Equal(createdNewHouse, result); 
        }

        [Fact]
        public async Task Delete_FoundByIdHouse_ShouldBeDeleted()
        {

            HouseDto houseDto = CreateValidHouse();
            var createdNewHouse = await Svc<IHousesServices>().Create(houseDto);

            var result = await Svc<IHousesServices>().Delete((Guid)createdNewHouse.Id);
            Assert.Equal(createdNewHouse, result);

        }

        [Fact]
        public async Task Should_UpdateHouse_WhenUpdateData()
        {

            HouseDto houseDto = CreateValidHouse();
            await Svc<IHousesServices>().Create(houseDto);
            HouseDto updateHouse = UpdateValidHouse(houseDto);

            var result  = await Svc<IHousesServices>().Update(updateHouse);
            AssertHouseFields(updateHouse, result);
            Assert.Equal(updateHouse.CreatedAt, result.CreatedAt);
            Assert.True(updateHouse.ModifiedAt < result.ModifiedAt);
        }

        private HouseDto UpdateValidHouse(HouseDto house)
        {
            house.Address = "Myllykoskitie";
            house.RoomCount = 3;
            house.Size = 55;
            house.Price = 332444;
            house.Country = "Sweden";
           

            return house;
            
        }

        private HouseDto CreateValidHouse()
        {

            HouseDto houseDto = new();

            houseDto.Address = "Myllykoski";
            houseDto.RoomCount = 2;
            houseDto.Size = 40;
            houseDto.Price = 12223;
            houseDto.BuiltDate = DateTime.Now;
            houseDto.Country = "Finland";

            return houseDto;

        }

        private void AssertHouseFields(HouseDto expected, House actual)
        {

            Assert.NotNull(actual.Id);
            Assert.Equal(expected.Address, actual.Address);
            Assert.Equal(expected.RoomCount, actual.RoomCount);
            Assert.Equal(expected.Size, actual.Size);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.BuiltDate, actual.BuiltDate);
            Assert.Equal(expected.Country, actual.Country);

        }
    }
}