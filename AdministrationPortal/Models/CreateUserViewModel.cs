using AdministrationPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministrationPortal.Models
{
    public class CreateUserViewModel : ApplicationUser
    {
        public string Password { get; set; }
    }
}
