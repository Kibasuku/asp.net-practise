using Accounting.Data;
using Accounting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objList = from orders in _db.Orders.ToList()
                          from goods in _db.Goods.ToList()
                          where orders.goodsId == goods.goodsId
                          select orders;

            return View(objList);
        }
    }
}
