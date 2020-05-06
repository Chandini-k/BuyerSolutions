using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsService.Manager
{
    public interface IItemManager
    {
        Task<List<Items>> Search(Product product);
        Task<List<Items>> SearchItemByCategory(ProductCategory productCategory);
        Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory);
        Task<bool> BuyItem(Purchasehistory purchase);
        Task<List<Purchasehistory>> Purchase(Login login);
        Task<List<Category>> GetCategories();
        Task<List<SubCategory>> GetSubCategories(int categoryId);
        Task<List<Items>> GetItems();
        Task<bool> AddToCart(Cart cart);
        Task<int> GetCount(int bid);
        Task<bool> CheckCartItem(int buyerid, int itemid);
        Task<List<Cart>> GetCarts(int bid);
        Task<bool> DeleteCart(int cartId);
        Task<Cart> GetCartItem(int cartid);
        Task<List<Items>> Items(int price, int price1);
    }
}
