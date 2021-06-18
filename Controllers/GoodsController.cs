using Accounting.Data;
using Accounting.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Controllers
{
    public class GoodsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GoodsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objList = from goods in _db.Goods.ToList()
                          from categories in _db.Categories.ToList()
                          from storages in _db.Storages.ToList()
                          where goods.categoryId == categories.categoryId
                          where goods.storageId == storages.storageId
                          select goods;

            return View(objList);
        }

        //GET Create
        public IActionResult Create()
        {
            return View();

        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Goods obj)
        {
            if (ModelState.IsValid)
            {
                _db.Goods.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Goods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST Delet
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Goods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Goods.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Goods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }
        //POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Goods obj)
        {

            if (ModelState.IsValid)
            {
                _db.Goods.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


    }
}
