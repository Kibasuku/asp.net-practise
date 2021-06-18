using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class Order
    {
       [Key]
       public int orderId { get; set; }

        public string orderTitle { get; set; }

        public int goodsId { get; set; }
        public virtual Goods Goods { get; set; }

    }
}
