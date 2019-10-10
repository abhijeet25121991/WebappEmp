using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.EmpRepository;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ShowAllEmployee()
        {
            EmpDataRepository empDtrepObj = new EmpDataRepository();

            if (empDtrepObj.FetchAllEmployee() != null)
            {
                return View(empDtrepObj.FetchAllEmployee());
            }
            return View();

        }

        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employees empObj)
        {

            EmpDataRepository empDtrepObj = new EmpDataRepository();
           
            if (ModelState.IsValid)
            {
                if (empDtrepObj.AddEmpoyee(empObj) == true) { ViewBag.Message = "Employee Added Successfully"; return View(); }
                else
                {
                    ViewBag.Message = "Something went wrong";
                    return View();
                }
            }

            else
            {
                return View();
            }
           
        }

     
       
        public ActionResult updateEmployee(int empid)
        {
            EmpDataRepository empDtrepObj = new EmpDataRepository();
            ModelState.Clear();
           
            return View(empDtrepObj.FetchEmployee(empid));
        }


        [HttpPost]
        public ActionResult updateEmployee(Employees empObj)
        {

            EmpDataRepository empDtrepObj = new EmpDataRepository();
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (empDtrepObj.updateEmployee(empObj)) { ViewBag.Message = "Employee Update Successfully"; return View(); }
                return View();
            }
            else
            {
                ViewBag.Message = "Something went wrong";
                return View();
            }
        }



      
       
        [HttpGet]
        public ActionResult deleteEmployee(int empId)
        {

            EmpDataRepository empDtrepObj = new EmpDataRepository();
            ModelState.Clear();
            empDtrepObj.deleteEmployee(empId);
            ViewBag.Message = "Deleted Successfully";
            return RedirectToAction("ShowAllEmployee", "Home");
        }


    }
}