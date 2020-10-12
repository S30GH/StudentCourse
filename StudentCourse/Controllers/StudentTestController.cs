using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourse.Models;

namespace StudentCourse.Controllers
{
    public class StudentTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InsertStudent()
        {
            StudentDetalj sd = new StudentDetalj();
            StudentMetoder sm = new StudentMetoder();
            int i = 0;
            string error = "";

            sd.St_Firstname = "Kalle";
            sd.St_Lastname = "Karlsson";
            sd.St_Pnr = "201012012234";


            i = sm.InsertPerson(sd, out error);
            ViewBag.error = error;
            ViewBag.antal = i;

            return View();


        }

        [HttpPost]
        public IActionResult InsertStudentForm(StudentDetalj sd) {
            StudentMetoder sm = new StudentMetoder();
            int i = 0;
            string error = "";
            i = sm.InsertPerson(sd, out error);
            ViewBag.error = error;
            ViewBag.antal = i;
            if (i == 1) { return RedirectToAction("SelectWithDataSet"); }
            else { return View("InsertPerson"); }

        }

        public IActionResult DeleteStudent()
        {
            StudentMetoder sm = new StudentMetoder();
            string error = "";
            int i = 0;
            i = sm.DeleteStudent(out error);
            HttpContext.Session.SetString("antal", i.ToString());
            return RedirectToAction("SelectWithDataSet");
        }

        public ActionResult SelectWithDataSet()
        {
            List<StudentDetalj> Studentlist = new List<StudentDetalj>();
            StudentMetoder sm = new StudentMetoder();
            string error = "";
            Studentlist = sm.GetStudentWithDataSet(out error);
            //ViewBag.antal = HttpContext.Session.GetString("antal");
            ViewBag.error = error;
            return View(Studentlist);
        }

        public ActionResult SelectWithDataReader()
        {
            List<StudentDetalj> Studentlist = new List<StudentDetalj>();
            StudentMetoder sm = new StudentMetoder();
            string error = "";
            Studentlist = sm.GetStudentWithReader(out error);
            ViewBag.error = error;
            return View(Studentlist);
        }
        
    }


}
