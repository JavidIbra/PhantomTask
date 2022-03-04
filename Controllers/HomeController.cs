using Microsoft.AspNetCore.Mvc;
using PhantomTask.DAL;
using PhantomTask.Models.Entity;
using System;
using System.Linq;

namespace PhantomTask.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext db;

        public HomeController(AppDbContext database)
        {
            this.db = database;
        }

        public IActionResult Index()
        {
            
            return View(db.Blocks.ToList());
        }

        [HttpPost]
        public IActionResult Contact(string name,string email,string message)
        {

            Contact cnt = new Contact();
            cnt.Name = name;
            cnt.Email = email;
            cnt.Message = message;
            cnt.CreatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Contacts.Add(cnt);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");

        }

    }
}
