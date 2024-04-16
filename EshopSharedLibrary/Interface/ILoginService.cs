using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Interface
{
    public interface ILoginService
    {
       Task Login(string username, string password);

        bool CheckIfAdmin();

    }
}
