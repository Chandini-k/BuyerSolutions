using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsService.Manager
{
    public class ItemManager:IItemManager
    {
        private readonly IItemRepository _iitemRepository;
        public ItemManager(IItemRepository iitemRepository)
        {
            _iitemRepository = iitemRepository;
        }

        public async Task<bool> AddToCart(Cart cart)
        {
            bool buyercart = await _iitemRepository.AddToCart(cart);
            if (buyercart)
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
            bool buyitem = await _iitemRepository.BuyItem(purchase);
            if (buyitem)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<bool> CheckCartItem(int buyerid, int itemid)
        {
            bool cart = await _iitemRepository.CheckCartItem(buyerid, itemid);
            if(cart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            var deletecart = await _iitemRepository.DeleteCart(cartId);
            if(deletecart)
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
            var cart = await _iitemRepository.GetCartItem(cartid);
            if(cart!=null)
            {
                return cart;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Cart>> GetCarts(int bid)
        {
            List<Cart> cart = await _iitemRepository.GetCarts(bid);
            if (cart!=null)
            {
                return cart;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> category = await _iitemRepository.GetCategories();
            if (category != null)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> GetCount(int bid)
        {
            var count = await _iitemRepository.GetCount(bid);
            if (count>0)
            {
                return count;
            }
            else
                return 0;
        }

        public async Task<List<Items>> GetItems()
        {
            List<Items> items = await _iitemRepository.GetItems();
            if (items != null)
            {
                return items;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<SubCategory>> GetSubCategories(int categoryId)
        {
            List<SubCategory> subCategory = await _iitemRepository.GetSubCategories(categoryId);
            if (subCategory != null)
            {
                return subCategory;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Items>> Items(int price, int price1)
        {
            List<Items> itemsprice = await _iitemRepository.Items(price,price1);
            if (itemsprice != null)
            {
                return itemsprice;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Purchasehistory>> Purchase(Login login)
        {
            List<Purchasehistory> purchase = await _iitemRepository.Purchase(login);
            if (purchase!= null)
            {
                return purchase;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Items>> Search(Product product)
        {
            List<Items> search = await _iitemRepository.Search(product);
            if (search != null)
            {
                return search;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Items>> SearchItemByCategory(ProductCategory productCategory)
        {
            List<Items> searchCategory = await _iitemRepository.SearchItemByCategory(productCategory);
            if (searchCategory!=null)
            {
                return searchCategory;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            List<Items> searchSubCategory = await _iitemRepository.SearchItemBySubCategory(productSubCategory);
            if (searchSubCategory != null)
            {
                return searchSubCategory;
            }
            else
            {
                return null;
            }
        }
    }
}
