using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practise.DAL.DatabaseServices;
using Practise.Helpers;
using Practise.DAL.ViewModels;
using Practise.DAL.Models;

namespace Practise.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class CategoryController : Controller
        {
            private readonly IMapper _mapper;
            private readonly DatabaseService _databaseService;
            public CategoryController(IMapper mapper, DatabaseContext databaseContext)
            {
                _mapper = mapper;
                _databaseService = new DatabaseService(databaseContext);
            }

            [Route("GetCategory")]
            [HttpGet]
            public async Task<IActionResult> GetCategory(SortState sortOrder = SortState.NameAsc)
            {
                var categories = await _databaseService.GetCategoriesAsync();
                ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
                ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
                

                categories = sortOrder switch
                {
                    SortState.IdAsc => categories.OrderBy(s => s.Id),
                    SortState.IdDesc => categories.OrderByDescending(s => s.Id),
                    SortState.NameAsc => categories.OrderBy(s => s.Name),
                    SortState.NameDesc => categories.OrderByDescending(s => s.Name),
              
                };

                return View(categories.ToList());
            }

            [Route("AddCategory")]
            [HttpPost]
            public async Task<IActionResult> AddCategory(CategoryViewModel categoryViewModel)
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                var result = await _databaseService.AddCategoryAsync(category);
                return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
            }
        }
}

