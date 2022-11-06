using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjCinema.Models
{
    public class LoginModel
    {
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool RememberMe { get; set; }
    }
}