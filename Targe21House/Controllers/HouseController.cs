using Microsoft.AspNetCore.Mvc;
using Targe21House.Models.House;

namespace Targe21House.Controllers
{
    public class HouseController : Controller
    {

        private readonly TARge21HouseContext _context;



        public HouseController
            (
                TARge21HouseContext context


            )
        {
            _context = context;

        }


        [HttpPost]

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
                    BuiltDate = x.BuiltDate
                });

            return View(result);
        }
    }
}