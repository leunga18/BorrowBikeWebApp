using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowBikeWebApp.Models
{
    public class Admin
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
