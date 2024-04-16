using EshopSharedLibrary.DBStuff;
using EshopSharedLibrary.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Eshop_Obligatorisk_Opgave
{
    public class LoginService : ILoginService
    {
        private static User user;
        private static bool isLoggedIn;
        private DBContext dbContext;

        public LoginService(DBContext db) {
            dbContext = db ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public bool CheckIfAdmin()
        {
            return isLoggedIn && user != null && user.IsAdmin;
        }

        public async Task Login(string username, string password)
        {
            var tempUser = await dbContext.User.FirstOrDefaultAsync(u => u.Email == username && u.Password == password);
            if (tempUser != null)
            {
                user = tempUser;
                isLoggedIn = true;
            }
            else
            {
                user = null;
                isLoggedIn = false;
                throw new Exception("Invalid credentials. Please try again.");
            }
        }

    }
}
