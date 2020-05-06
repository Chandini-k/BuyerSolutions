using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BuyerContext _context;
        public UserRepository(BuyerContext context)
        {
            _context = context;
        }

        public async Task<bool> BuyerRegister(Buyer buyer)
        {
            _context.Buyer.Add(buyer);
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

        public async Task<Login> BuyerLogin(Login login)
        {
             Buyer buyer = await _context.Buyer.SingleOrDefaultAsync(e => e.Username ==login.userName && e.Password == login.userPassword);
            if (buyer.Username == login.userName && buyer.Password == login.userPassword)
            {
                return login;
            }
            else
            {
                Console.WriteLine("Not valid");
                return login;
            }

        }
    }
}
