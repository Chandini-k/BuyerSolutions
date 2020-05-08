using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public class BuyerRepository:IBuyerRepository
    {
        private readonly BuyerContext _context;
        public BuyerRepository(BuyerContext context)
        {
            _context = context;
        }
        public async Task<bool> EditBuyerProfile(BuyerData buyer)
        {
            Buyer buyer1 = _context.Buyer.Find(buyer.buyerId);
                buyer1.Username = buyer.userName;
                buyer1.Password = buyer.password;
                buyer1.Mobileno = buyer.mobileNo;
                buyer1.Email = buyer.emailId;
            _context.Buyer.Update(buyer1);
            var user=await _context.SaveChangesAsync();
            if (user>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Buyer> GetBuyerProfile(int bid)
        {
                Buyer buyer = await _context.Buyer.FindAsync(bid);
                if (buyer == null)
                    return null;
                else
                    return buyer;
        }
    }
}
