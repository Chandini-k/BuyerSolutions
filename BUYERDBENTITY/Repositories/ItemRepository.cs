using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly BuyerContext _context;
        public ItemRepository(BuyerContext context)
        {
            _context = context;
        }
        public async Task<bool> AddToCart(Cart cart)
        {
            _context.Cart.Add(cart);
            var buyercart=await _context.SaveChangesAsync();
            if(buyercart>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> BuyItem(Purchasehistory purchase)
        {
            _context.Purchasehistory.Add(purchase);
            var buyitem=await _context.SaveChangesAsync();
            if(buyitem>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CheckCartItem(int buyerid, int itemid)
        {
            Cart cart = await _context.Cart.SingleOrDefaultAsync(e => e.Bid == buyerid && e.Itemid == itemid);
            if (cart != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            Cart cart=await _context.Cart.FindAsync(cartId);
            _context.Cart.Remove(cart);
            var cartitem=await _context.SaveChangesAsync();
            if(cartitem==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Cart> GetCartItem(int cartid)
        {
            return await _context.Cart.FindAsync(cartid);
        }

        public async Task<List<Cart>> GetCarts(int bid)
        {
            return await _context.Cart.Where(e => e.Bid == bid).ToListAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<int> GetCount(int bid)
        {
            var count=await _context.Cart.Where(e => e.Bid == bid).ToListAsync();
            return count.Count();
        }

        public async Task<List<Items>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }
        public async Task<List<SubCategory>> GetSubCategories(int categoryId)
        {
            return await _context.SubCategory.Where(e => e.Cid == categoryId).ToListAsync();
        }

        public async Task<List<Items>> Items(int price, int price1)
        {
            return await _context.Items.Where(e => e.Price >= price && e.Price <= price1).ToListAsync();
        }

        public Task<List<Purchasehistory>> Purchase(Login login)
        {
            return _context.Purchasehistory.Where(e => e.Bid == login.buyerId).ToListAsync();
        }

        public async Task<List<Items>> Search(Product product)
        {
            return await _context.Items.Where(e => e.Itemname == product.productName).ToListAsync();
        }

        public async Task<List<Items>> SearchItemByCategory(ProductCategory productCategory)
        {
            return await _context.Items.Where(e => e.Itemname == productCategory.categoryName).ToListAsync();
        }

        public async Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            return await _context.Items.Where(e => e.Itemname == productSubCategory.subCategoryName).ToListAsync();
        }
    }
}
