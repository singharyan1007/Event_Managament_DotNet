using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private EventManagementDBContext _dbContext = new EventManagementDBContext();
        public void Create(Registration registration)
        {
            _dbContext.Registrations.Add(registration);
            _dbContext.SaveChanges();
        }

        public void Delete(int registrationId)
        {
            //User can cancel his upcoming event registration
            var reg = _dbContext.Registrations.FirstOrDefault(e => registrationId == e.RegistrationId);
            if (reg != null && reg.Event.DateAndTime > DateTime.Now)
            {
                _dbContext.Registrations.Remove(reg);
                _dbContext.SaveChanges();
            }
        }

        public List<Registration> GetAllRegistrations(string userId)
        {
            var registrations=_dbContext.Registrations.Where(i=>i.UserId==userId).ToList();
            return registrations;
        }

        public Event GetResitrationDetails(int registrationId)
        {
            //User gets all the Details for the particular event from the registrationId
            var regDetails = _dbContext.Registrations.FirstOrDefault(e => registrationId == e.RegistrationId).EventId;
            var eventDetails = _dbContext.Events.FirstOrDefault(i => i.EventId == regDetails);

            return eventDetails;
            
        }
    }
}
