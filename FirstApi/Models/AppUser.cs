using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FirstApi.Models
{
    public class AppUser : IdentityUser
    {
        public List<Portfolio> Porfolios {get; set; } = new List<Portfolio>();
    }
}