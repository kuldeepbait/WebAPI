using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
