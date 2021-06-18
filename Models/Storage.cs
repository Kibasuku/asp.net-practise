using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class Storage
    {
        [Key]
        public int storageId { get; set; }

        [DisplayName("Название склада")]
        public string storageTitle { get; set; }
        [DisplayName("Адрес склада")]
        public string storageAdress { get; set; }

        public List<Goods> Goods { get; set; }
        
    }
}
