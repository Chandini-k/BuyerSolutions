﻿using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Manager
{
    public interface IUserManager
    {
        Task<bool> BuyerRegister(Buyer buyer);
        Task<Login> BuyerLogin(Login login);
    }
}