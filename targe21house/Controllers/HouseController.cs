using Microsoft.AspNetCore.Mvc;
using targe21house.Core.Dto;
using targe21house.Core.ServiceInterface;
using targe21house.Data;
using targe21house.Models.House;

namespace targe21house.Controllers
{
    public class HouseController : Controller
    {
        private readonly targe21houseContext _context;
        private readonly IHousesServices _housesServices;


        public HouseController
            (
                targe21houseContext context,
                IHousesServices housesServices

            )
        {
            _context = context;
            _housesServices = housesServices;

        }

        public IActionResult Index()
        {
            var result = _context.Houses
                 .OrderByDescending(y => y.CreatedAt)
                 .Select(x => new HouseIndexViewModel
                 {
                     Id = x.Id,
                     Address = x.Address,
                     RoomCount = x.RoomCount,
                     Size = x.Size,
                     Price = x.Price,
                     BuiltDate = x.BuiltDate,
                     Country = x.Country

                 });

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            HouseCreateUpdateViewModel house = new HouseCreateUpdateViewModel();

            return View("CreateUpdate", house);
        }


        [HttpPost]
        public async Task<IActionResult> Create(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                RoomCount = vm.RoomCount,
                Size = vm.Size,
                Price = vm.Price,
                BuiltDate = vm.BuiltDate,
                Country = vm.Country,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _housesServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            var house = await _housesServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseCreateUpdateViewModel();

            vm.Id = house.Id;
            vm.Address = house.Address;
            vm.Size = house.Size;
            vm.RoomCount = house.RoomCount;
            vm.Price = house.Price;
            vm.BuiltDate = house.BuiltDate;
            vm.Country = house.Country;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View("CreateUpdate", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                RoomCount = vm.RoomCount,
                Size = vm.Size,
                Price = vm.Price,
                BuiltDate = vm.BuiltDate,
                Country = vm.Country,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };

            var result = await _housesServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            var house = await _housesServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDetailsViewModel();

            vm.Id = house.Id;
            vm.Address = house.Address;
            vm.Size = house.Size;
            vm.RoomCount = house.RoomCount;
            vm.Price = house.Price;
            vm.BuiltDate = house.BuiltDate;
            vm.Country = house.Country;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var house = await _housesServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDeleteViewModel();

            vm.Id = house.Id;
            vm.Address = house.Address;
            vm.Size = house.Size;
            vm.RoomCount = house.RoomCount;
            vm.Price = house.Price;
            vm.BuiltDate = house.BuiltDate;
            vm.Country = house.Country;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;
    
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid? id)
        {
            var houseId = await _housesServices.Delete(id);

            if (houseId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}



