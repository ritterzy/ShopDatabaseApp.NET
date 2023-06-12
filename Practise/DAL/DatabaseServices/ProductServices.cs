using Microsoft.EntityFrameworkCore;
using Practise.DAL.Models;

namespace Practise.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products
                .Include(e => e.Category)
                .ToList();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return _context.Products
                .Include(e => e.Category)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products
                .Include(e => e.Category)
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddProduct(Product products)
        {
            _context.Products.Add(products);
            return _context.SaveChanges();
        }

        public int AddProdcuts(IList<Product> products)
        {
            _context.Products.AddRange(products);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public int UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return _context.SaveChanges();
        }

        public int UpdateProduct(IList<Product> products)
        {
            _context.Products.UpdateRange(products);
            return _context.SaveChanges();
        }

        #endregion

        #region Remove 

        public int RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            return _context.SaveChanges();
        }

        public int RemoveProductById(int id)
        {
            var resProduct = _context.Products.FirstOrDefault(e => e.Id == id);
            if (resProduct is null)
            {
                return default;
            }

            _context.Products.Remove(resProduct);
            return _context.SaveChanges();
        }




        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(e => e.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _context.Products
                .Include(e => e.Category)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task<int> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCategoriesAsync(IList<Product> products)
        {
            _context.Products.UpdateRange(products);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove
        public async Task<int> RemoveProductAsync(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveProductByIdAsync(int id)
        {
            var resProduct = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
            if (resProduct is null)
            {
                return default;
            }

            _context.Products.Remove(resProduct);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveProductsAsync(IList<Product> products)
        {
            _context.Products.RemoveRange(products);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
