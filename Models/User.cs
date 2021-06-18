using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        [DisplayName("Имя пользователя")]
        [Required(ErrorMessage ="Не указано имя пользователя")]
        public string UserName { get; set; }

        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Уровень доступа")]
        //[Required(ErrorMessage = "Не указан уровень доступа")]
        //[Range(0, 3, ErrorMessage = "Недопустимый уровень")]
        public string UserLevel { get; set; }

    }
}
