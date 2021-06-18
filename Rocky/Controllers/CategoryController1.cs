using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class CategoryController1 : Controller

    {
        //This class takes data from the DataBase then ouuput it View.
        private readonly AppDBContext _db;

        public CategoryController1(AppDBContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category; //Extract the Category data from the DataBase and adds to ObjList.
            return View(objList); //Takes this list and present to the view.
        }
        /*public IActionResult Create()
        {
     
            return View(); //Takes this list and present to the view.
        }*/


        [HttpPost] //method that tranfers data from the page from to the server.
        [ValidateAntiForgeryToken] //this is used to secure the application.
        public IActionResult Create(Category obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index"); //Redirect us to the home page.
        }
    }
}
