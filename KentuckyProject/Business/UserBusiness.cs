using KentuckyWebService.Models;
using KentuckyWebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Business
{
    public class UserBusiness
    {
        UserRepository userRepo = new UserRepository();
        LoginRepository loginRepo = new LoginRepository();

        public User CreateUser(User user)
        {
            if (loginRepo.SelectOneWNick(user.Login) == null)
            {
                userRepo.CreateUser(user);
                return userRepo.SelectOneLogin(user);
            }
            else
            {                
                return null;
            }

            
        }
    }
}