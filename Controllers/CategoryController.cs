using Accounting.Data;
using Accounting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Categories;
            return View(objList);

        }

        public IActionResult curCategory(int id)
        {
            var objList = from goods in _db.Goods.ToList()
                          from storages in _db.Storages.ToList()
                          where goods.categoryId == id
                          where goods.storageId == storages.storageId
                          select goods;

            return View(objList);
        }


    }
}
