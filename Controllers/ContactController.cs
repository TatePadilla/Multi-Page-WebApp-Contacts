using Microsoft.AspNetCore.Mvc;
using Multi_Page_WebApp_Contacts.Models;


namespace Multi_Page_WebApp_Contacts.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }
        public ContactController(ContactContext ctx) => context = ctx;

        // HttpGet command to add new objects.
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            // Returning the "Edit" view.
            return View("Edit", new Contact());
        }

        // HttpGet command to edit new objects.
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var Contact = context.Contacts.Find(id);
            // Return the edit view for the object matching the parameter id provided.
            return View(Contact);
        }

        // HttpGet command to delete objects with the ID provided in the parameter.
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Contact = context.Contacts.Find(id);
            return View(Contact);
        }

        // HttpPost command editing the contact provided in the parameter.
        [HttpPost]
        public IActionResult Edit(Contact Contact)
        {
            if (ModelState.IsValid)
            {
                // If no contact, return the Add Page.
                if (Contact.ContactId == 0)
                {
                    context.Contacts.Add(Contact);
                }
                else
                {
                    context.Contacts.Update(Contact);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (Contact.ContactId == 0) ? "Add" : "Edit";
                return View(Contact);
            }
        }
        
        // HttpPost command for deleting objects.
        [HttpPost]
        public IActionResult Delete(Contact Contact)
        {
            context.Contacts.Remove(Contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
