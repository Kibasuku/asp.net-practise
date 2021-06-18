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
    public class ExportController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ExportController(ApplicationDbContext db)
        {
            _db = db;
        }

 

        public IActionResult Download(int id)
        {
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Report");

                var objList = from goods in _db.Goods.ToList()
                          from categories in _db.Categories.ToList()
                          from storages in _db.Storages.ToList()
                          where goods.categoryId == categories.categoryId
                          where goods.storageId == storages.storageId
                          select goods;

              

                if (id == 2)
                {
                        objList = from orders in _db.Orders.ToList()
                                  from goods in _db.Goods.ToList()
                                  where orders.goodsId == goods.goodsId
                                  select goods;


                    worksheet.Cell("A1").Value = "Заказчик";
                    worksheet.Cell("B1").Value = "Товар";
                    worksheet.Cell("C1").Value = "Стоимость";

                    worksheet.Row(1).Style.Font.Bold = true;

                    for (int i = 0; i < objList.ToList().Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = objList.ToList()[i].Order.orderTitle;
                        worksheet.Cell(i + 2, 2).Value = objList.ToList()[i].goodsName;
                        worksheet.Cell(i + 2, 3).Value = objList.ToList()[i].goodsCost;
                    }

                }
                else
                {
                    worksheet.Cell("A1").Value = "Название";
                    worksheet.Cell("B1").Value = "Категория";
                    worksheet.Cell("C1").Value = "Стоимость, BYN";
                    worksheet.Cell("D1").Value = "Склад";

                    worksheet.Row(1).Style.Font.Bold = true;

                    for (int i = 0; i < objList.ToList().Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = objList.ToList()[i].goodsName;
                        worksheet.Cell(i + 2, 2).Value = objList.ToList()[i].Category.categoryName;
                        worksheet.Cell(i + 2, 3).Value = objList.ToList()[i].goodsCost;
                        worksheet.Cell(i + 2, 4).Value = objList.ToList()[i].Storage.storageTitle;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"report_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }


        }
        
    }
}
