using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Manager
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository _iuserRepository;
        public UserManager(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }
        public async Task<bool> BuyerRegister(Buyer buyer)
        {
                bool user = await _iuserRepository.BuyerRegister(buyer);
                return user;
            
        }

        public async Task<Login> BuyerLogin(Login login)
        {
                Buyer buyer=new Buyer();
                Login login1 = await _iuserRepository.BuyerLogin(login);
                if (buyer.Username == login.userName && buyer.Password == login.userPassword)
                {
                    return login1;
                }
                else
                {
                    Console.WriteLine("Invalid");
                    return login1;
                }
        }

    }
}
