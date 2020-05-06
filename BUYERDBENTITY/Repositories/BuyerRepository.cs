using BUYERDBENTITY.Entity;
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
        public async Task<bool> EditBuyerProfile(Buyer buyer)
        {
            _context.Update(buyer);
            var user = await _context.SaveChangesAsync();
            if (user > 0)
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
