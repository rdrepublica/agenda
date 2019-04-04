using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts.Controllers
{
    public class LocalEventsController : Controller
    {
        private readonly ContactDatabaseContext Database;
        public LocalEventsController(ContactDatabaseContext contactDatabase)
        {
            this.Database = contactDatabase;
        }

        // GET: /<controller>/
        public IActionResult Index(DateTime? SearchCriteria)
        {
            List<LocalEvent> localEvent;

            if (SearchCriteria != null)
            {
                localEvent = Database.LocalEvents.Where(lEvent => lEvent.Date.ToString("dd/MM/yyyy") == (SearchCriteria ?? DateTime.Now).ToString("dd/MM/yyyy")).ToList();
            }
            else
            {
                localEvent = Database.LocalEvents.ToList();
            }

            ViewData.Add("LocalEventList", localEvent);

            return View();
        }


        public IActionResult Edit(int? Id)
        {
            LocalEvent localEvent;

            if(Id != null)
            {
                localEvent = Database.LocalEvents.Find(Id);
            }
            else
            {
                localEvent = new LocalEvent
                {
                    Date = DateTime.Now
                };
            }

            return View(localEvent);
        }

        [HttpPost]
        public IActionResult Edit(LocalEvent localEvent)
        {
            if(!ModelState.IsValid)
            {
                return View(localEvent);
            }

            if(localEvent.Id == 0)
            {
                Database.Add(localEvent);
            }
            else
            {
                Database.Update(localEvent);
            }
            Database.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
