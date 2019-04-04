using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactDatabaseContext Database;
        public ContactsController(ContactDatabaseContext contactDatabase)
        {
            this.Database = contactDatabase;
        }

        // GET: /<controller>/
        public IActionResult Index(string SearchCriteria)
        {
            List<Contact> contacts;

            if (SearchCriteria != null)
            {
                contacts = Database.Contacts.Where(contact => (contact.FirstName + " " + contact.LastName).Contains(SearchCriteria)).ToList();
            }
            else
            {
                contacts = Database.Contacts.ToList();
            }

            ViewData.Add("ContactList", contacts);

            return View();
        }

        // Esta consulta me retorna los contactos, como un JSON es decir un arreglo de datos.
        public IActionResult Search(string SearchCriteria)
        {

            // Creo una lista para mis resultados
            List<Contact> contacts;

            // Si el criterio de busqueda no es nulo.
            if (SearchCriteria != null)
            {
                // Entonces busco de mi base de datos los contactos cuyo nombre concatenado
                // con el apellido, contengan el criterio de busqueda.
                contacts = Database.Contacts.Where(contact => (contact.FirstName + " " + contact.LastName).Contains(SearchCriteria)).ToList();
            }
            else
            {
                // Si no hay criterio de busqueda lleno la lista con tooodos los contactos.
                contacts = Database.Contacts.ToList();
            }

            // Retorno los datos resultantes.
            return Json(contacts);
        }


        public IActionResult Edit(int? Id)
        {
            Contact contact;

            if(Id != null)
            {
                contact = Database.Contacts.Find(Id);
            }
            else
            {
                contact = new Contact();
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if(!ModelState.IsValid)
            {
                return View(contact);
            }

            if(contact.Id == 0)
            {
                Database.Add(contact);
            }
            else
            {
                Database.Update(contact);
            }
            Database.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
