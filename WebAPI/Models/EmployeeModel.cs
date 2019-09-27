using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.DLL;

namespace WebAPI.Models
{
    public class EmployeeModel
    {
       

        public int id { get; set; }

       
        public string name { get; set; }


        
        public decimal Salary { get; set; }

         
    }

   
}