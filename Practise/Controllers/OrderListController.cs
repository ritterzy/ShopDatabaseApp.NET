using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practise.DAL.DatabaseServices;
using Practise.DAL.Models;
using Practise.DAL.ViewModels;
using Practise.Helpers;

namespace Practise.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class OrderListController : Controller
        {
            private readonly IMapper _mapper;
            private readonly DatabaseService _databaseService;
            public OrderListController(IMapper mapper, DatabaseContext databaseContext)
            {
                _mapper = mapper;
                _databaseService = new DatabaseService(databaseContext);
            }

            [Route("GetOrderList")]
            [HttpGet]
            public async Task<IActionResult> GetOrderList(SortState sortOrder = SortState.NameAsc)
            {
                var orderlists = await _databaseService.GetOrderListsAsync();
                ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;


                orderlists = sortOrder switch
                {
                    SortState.IdAsc => orderlists.OrderBy(s => s.Id),
                    SortState.IdDesc => orderlists.OrderByDescending(s => s.Id),


                };

                return View(orderlists.ToList());
            }

            [Route("AddOrderList")]
            [HttpPost]
            public async Task<IActionResult> AddOrderList(CategoryViewModel orderlistViewModel)
            {
                var orderlist = _mapper.Map<Category>(orderlistViewModel);
                var result = await _databaseService.AddCategoryAsync(orderlist);
                return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
            }
        }
    }

