using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repository;

namespace EventManagement.Data
{
    public class EventRepository : IEventRepository
    {
        private EventManagementDBContext dbContext = new EventManagementDBContext();
        public void Create(Event eve)
        {
            dbContext.Events.Add(eve);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var eventEntity = dbContext.Events.FirstOrDefault(e => id == e.EventId);
            if (eventEntity!=null && eventEntity.DateAndTime > DateTime.Now)
            {
                dbContext.Events.Remove(eventEntity);
                dbContext.SaveChanges();
                
            }
        }

        public List<Event> GetAll()
        {
            var listEvents= dbContext.Events.ToList();
            return listEvents;
        }

        public void Update(Event eve)
        {
            dbContext.Events.Update(eve);
            dbContext.SaveChanges();
        }

        public Event GetById(int id)
        {
            return dbContext.Events.FirstOrDefault(e => e.EventId == id);
        }
    }
}
