using EventManagement.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Domain.Entities;
using EventManagement.Data;


namespace EventManagement.WebApp.Controllers
{
    public class EventsController : Controller
    {
        IEventRepository EventRepository;

        public EventsController(IEventRepository eventRepository) 
        {
            this.EventRepository = eventRepository;
        }
        public IActionResult Index()
        {
            List<Event> allEvents=EventRepository.GetAll();
            return View(allEvents);
        }



        //Create event - only admins 

        [HttpGet]
        public IActionResult Submit() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Event eve) 
        {
            if (ModelState.IsValid)
            {
                EventRepository.Create(eve);

                return RedirectToAction("Index");
            }
            return View(eve);

           

        }


        [HttpGet]
        public IActionResult Manage() 
        {
            
			List<Event> allEvents = EventRepository.GetAll();
            if (allEvents == null)
            {
                return NotFound();
            }
			return View(allEvents);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Event eve = EventRepository.GetById(id);

            return View(eve);
        }

        [HttpPost]
        
        public IActionResult Edit(Event eve)
        {
            if (ModelState.IsValid)
            {
                EventRepository.Update(eve);
                return RedirectToAction("Manage");
            }
            return View(eve);
        }

        public IActionResult Cancel()
        {
            return View("Manage");
        }

		//Manage events -  Delete, Update
		//Delete only those events that are UPCOMING 

		//View all the events - for all
	}
}
