using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Entities
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public Event Event { get; set; }
        public ApplicationUser User { get; set; }
    }
}
