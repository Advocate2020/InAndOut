using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        //enables dependency injection: this code allows you to use the database in your code.
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        //end of dependency injection

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;//allows you to get all the expenses in your database
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
        public IActionResult Create(Expense obj /**/)
        {
            if(ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //Delete-Get: for getting delete view data       
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Delete - post: for saving view data
        [HttpPost] //signals thats its a post method
        [ValidateAntiForgeryToken]// only allows people who are authenticated to post
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get-Update: for getting update view data       
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post-Update: for saving view data
        [HttpPost] //signals thats its a post method
        [ValidateAntiForgeryToken]// only allows people who are authenticated to post
        public IActionResult Update(Expense obj /**/)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


    }
}
