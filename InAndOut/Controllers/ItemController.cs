using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        //enables dependency injection: this code allows you to use the database in your code.
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        //end of dependency injection

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;//allows you to get all the items in your database
            return View(objList);
        }

        //Get-Create: for displaying the view
        public IActionResult Create()
        {
            return View();
        }

        //Post-Create: for saving view data
        [HttpPost] //signals thats its a post method
        [ValidateAntiForgeryToken]// only allows people who are authenticated to post
        public IActionResult Create(Item obj /**/)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
