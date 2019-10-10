using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Employees
    {
        [Display(Name = "ID ")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Employee Name Required")]

        [Display(Name = "Emp. Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employee City Required")]

        [Display(Name = "Emp. City")]
        public string City { get; set; }

        

        [Display(Name = "Emp. Gender")]
        public int gender { get; set; }


        [Required(ErrorMessage = "Employee Birthdate Required")]
        [Display(Name = "Emp. Birthdate")]
        [DataType(DataType.Date)]
        public DateTime Bdate { get; set; }

        [Required(ErrorMessage = "Employee Age Required")]
         public string Address { get; set; }
    }
}