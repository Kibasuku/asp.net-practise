using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class Goods
    {
        [Key]
        public int goodsId { get; set; }

        [DisplayName("Наименование оборудования")]
        [Required(ErrorMessage = "Не указано название")]
        public string goodsName { get; set; }
        [DisplayName("Цена")]
        [Range(1, 999999, ErrorMessage = "Недопустимая цена")]
        [Required(ErrorMessage = "Не указана цена")]
        public int goodsCost { get; set; }
        [DisplayName("Склад")]
        [Required(ErrorMessage = "Не указан склад")]
        public int storageId { get; set; }
        [DisplayName("Категория")]
        [Required(ErrorMessage = "Не указана категория")]
        public int categoryId { get; set; }

        public Category Category { get; set; }

        public virtual Storage Storage { get; set; }

        public virtual Order Order { get; set; }


    }
}
