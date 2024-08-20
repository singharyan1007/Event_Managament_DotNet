using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Repository
{
    public interface IEventRepository
    {
        void Create(Event eve);
        void Update(Event eve);

        void Delete(int id);
        List<Event> GetAll();
        Event GetById(int id);

    }
}
