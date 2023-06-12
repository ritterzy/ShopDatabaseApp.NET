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
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DatabaseService _databaseService;
        public ProductController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _databaseService = new DatabaseService(databaseContext);
        }

        [Route("GetProduct")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(SortState sortOrder = SortState.NameAsc)
        {
            var products = await _databaseService.GetProductsAsync();
            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["PriceSort"] = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;


            products = sortOrder switch
            {
                SortState.IdAsc => products.OrderBy(s => s.Id),
                SortState.IdDesc => products.OrderByDescending(s => s.Id),
                SortState.NameAsc => products.OrderBy(s => s.Name),
                SortState.NameDesc => products.OrderByDescending(s => s.Name),
                SortState.PriceAsc => products.OrderBy(s => s.Price),
                SortState.PriceDesc => products.OrderByDescending(s => s.Price),

            };

            return View(products.ToList());
        }

        [Route("Addproduct")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Category>(productViewModel);
            var result = await _databaseService.AddCategoryAsync(product);
            return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }
    }
}