using EshopSharedLibrary.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Eshop_Obligatorisk_Opgave.Client
{
    public class LoginServiceClient : ILoginService
    {
        //private string? username;
        //private string? password;
        //private int Id;
        //private bool isLoggedIn;
        //private bool isAdmin;
        //private  DBContext dbContext {  get; set; } 


        //public async Task<bool> CheckIfAdmin(string username)
        //{
        //    var user = await dbContext.User.FirstOrDefaultAsync(u => u.Email == username);
        //    return user != null && user.IsAdmin;
        //}

        //public async Task Login(string username, string password)
        //{
        //    var user = await dbContext.User.FirstOrDefaultAsync(u => u.Email == username && u.Password == password);
        //    if (user != null)
        //    {
        //        isLoggedIn = true;
        //        isAdmin = user.IsAdmin;
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid credentials. Please try again.");
        //    }
        //}
        public Task<bool> CheckIfAdmin(string username)
        {
            throw new NotImplementedException();
        }

        public Task Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
