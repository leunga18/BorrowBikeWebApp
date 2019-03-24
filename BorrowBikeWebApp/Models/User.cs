using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowBikeWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Bike Bike { get; set; }
    }
}
