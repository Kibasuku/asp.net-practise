using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [DisplayName("Category Name")]
        [Required]
        public string categoryName { get; set; }

        public List<Goods> Goods { set; get; }

        /*public Category()
        {
            Goods = new List<Goods>();
        }*/

    }
}
