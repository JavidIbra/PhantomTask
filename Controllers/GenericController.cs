using Microsoft.AspNetCore.Mvc;
using PhantomTask.DAL;
using PhantomTask.Models.Entity;
using System.Linq;

namespace PhantomTask.Controllers
{
    public class GenericController : Controller
    {
        private readonly AppDbContext db;

        public GenericController(AppDbContext database)
        {
            this.db = database;
        }

        public IActionResult Index(int id)
        {

          Block blck = db.Blocks.FirstOrDefault(x => x.Id == id);

            return View(blck);
        }
        public IActionResult GoAddBlock()
        {
            return View();
        }

        public IActionResult AddBlock(string photo,string title,string subtitle,string text)
        {

            Block block = new Block();
            block.Image = photo;
            block.Title = title;
            block.SubTitle = subtitle;
            block.AboutText = text;

            if (photo==null || title==null || subtitle == null || text==null)
            {
                TempData["messageToUser"] = "ugursuz emeliyyat";
                return RedirectToAction("Index", "Home");

            }


            else if (ModelState.IsValid)
            {
                db.Blocks.Add(block);
                db.SaveChanges();
                TempData["messageToUser"] = "ugurla icra olundu";
                return RedirectToAction("Index", "Home");
            }
            


            return View();
        }
    }
}
