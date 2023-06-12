using Microsoft.EntityFrameworkCore;
using Practise.DAL.Models;

namespace Practise.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories
                .Include(e => e.Products)
                .ToList();
        }

        public IEnumerable<Category> GetCategoriesByName(string name)
        {
            return _context.Categories
                .Include(e => e.Products)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories
                .Include(e => e.Products)
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddCategory(Category categories)
        {
            _context.Categories.Add(categories);
            return _context.SaveChanges();
        }

        public int AddCategories(IList<Category> orderlists)
        {
            _context.Categories.AddRange(orderlists);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public int UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChanges();
        }

        public int UpdateCategory(IList<Category> categories)
        {
            _context.Categories.UpdateRange(categories);
            return _context.SaveChanges();
        }

        #endregion

        #region Remove 

        public int RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            return _context.SaveChanges();
        }

        public int RemoveCategoryById(int id)
        {
            var resCategory = _context.Categories.FirstOrDefault(e => e.Id == id);
            if (resCategory is null)
            {
                return default;
            }

            _context.Categories.Remove(resCategory);
            return _context.SaveChanges();
        }




        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Include(e => e.Products)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name)
        {
            return await _context.Categories
                .Include(e => e.Products)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories
                .Include(e => e.Products)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task<int> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCategoriesAsync(IList<Category> categories)
        {
            _context.Categories.UpdateRange(categories);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove
        public async Task<int> RemoveCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveCategoryByIdAsync(int id)
        {
            var resCategory = await _context.Categories.FirstOrDefaultAsync(e => e.Id == id);
            if (resCategory is null)
            {
                return default;
            }

            _context.Categories.Remove(resCategory);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveCategoriesAsync(IList<Category> categories)
        {
            _context.Categories.RemoveRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
