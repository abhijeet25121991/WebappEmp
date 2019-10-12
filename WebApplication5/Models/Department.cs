using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Department
    {
       public int deptid { get; set; }
        [Required(ErrorMessage ="Department is required")]
        [DataType(DataType.Text)]
        public  string deptname { get; set; }
    }
}