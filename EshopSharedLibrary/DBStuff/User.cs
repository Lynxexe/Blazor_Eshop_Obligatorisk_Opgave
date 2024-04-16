using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.DBStuff
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Adress { get; set; }
        public int ZipCode { get; set; }
        public string? City { get; set; }
        public bool IsAdmin { get; set; }
    }

}
