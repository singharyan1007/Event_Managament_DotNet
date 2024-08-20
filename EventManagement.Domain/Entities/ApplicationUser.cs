using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace EventManagement.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Registration> Registrations { get; set; }
    }
}
