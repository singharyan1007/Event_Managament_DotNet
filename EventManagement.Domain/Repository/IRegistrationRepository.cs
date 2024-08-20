using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Repository
{
    public interface IRegistrationRepository
    {
        void Create(Registration registration);
        Event GetResitrationDetails(int registrationId);

        List<Registration> GetAllRegistrations(string userId);

        void Delete(int registrationId);


    }
}
