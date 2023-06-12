using Microsoft.EntityFrameworkCore;
using Practise.DAL.Models;

namespace Practise.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<OrderList> GetOrderList()
        {
            return _context.OrderLists
                .ToList();
        }

        public OrderList GetOrderList(int id)
        {
            return _context.OrderLists
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddOrderList(OrderList orderlists)
        {
            _context.OrderLists.Add(orderlists);
            return _context.SaveChanges();
        }

        public int AddOrderLists(IList<OrderList> orderlists)
        {
            _context.OrderLists.AddRange(orderlists);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public int UpdateOrderList(OrderList orderlist)
        {
            _context.OrderLists.Update(orderlist);
            return _context.SaveChanges();
        }

        public int UpdateOrderList(IList<OrderList> orderlists)
        {
            _context.OrderLists.UpdateRange(orderlists);
            return _context.SaveChanges();
        }

        #endregion

        #region Remove 

        public int RemoveOrderList(OrderList orderlist)
        {
            _context.OrderLists.Remove(orderlist);
            return _context.SaveChanges();
        }

        public int RemoveOrderListById(int id)
        {
            var resOrderList = _context.OrderLists.FirstOrDefault(e => e.Id == id);
            if (resOrderList is null)
            {
                return default;
            }

            _context.OrderLists.Remove(resOrderList);
            return _context.SaveChanges();
        }




        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<OrderList>> GetOrderListsAsync()
        {
            return await _context.OrderLists
                .ToListAsync();
        }

        public async Task<OrderList> GetOrderListAsync(int id)
        {
            return await _context.OrderLists
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddOrderListAsync(OrderList orderlist)
        {
            await _context.OrderLists.AddAsync(orderlist);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task<int> UpdateOrderListAsync(OrderList orderlist)
        {
            _context.OrderLists.Update(orderlist);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateOrderListsAsync(IList<OrderList> orderlists)
        {
            _context.OrderLists.UpdateRange(orderlists);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove
        public async Task<int> RemoveOrderListAsync(OrderList orderlist)
        {
            _context.OrderLists.Remove(orderlist);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveOrderListByIdAsync(int id)
        {
            var resOrderList = await _context.OrderLists.FirstOrDefaultAsync(e => e.Id == id);
            if (resOrderList is null)
            {
                return default;
            }

            _context.OrderLists.Remove(resOrderList);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveOrderListsAsync(IList<OrderList> orderlists)
        {
            _context.OrderLists.RemoveRange(orderlists);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
