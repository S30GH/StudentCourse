using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourse.Models;

namespace StudentCourse.Controllers
{
    public class StudentCourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InsertStudent()
        {
            StudentDetalj sd = new StudentDetalj();
            StudentMetoder sm = new StudentMetoder();
            int i = 0;
            string error = "";

            //i = sm.InsertStudent(sd, out error);
            ViewBag.error = error;
            ViewBag.antal = i;

            return View();


        }
        [HttpPost]
        public IActionResult InsertStudent(IFormCollection fc)
        {
            StudentDetalj sd = new StudentDetalj();
            StudentMetoder sm = new StudentMetoder();
            int i = 0;
            string error = "";

            //ändra fc["firstname"] till fc["St_Firstname"] eftersom att jag tror att detta relaterar till namnet på formulärrutan. 
            sd.St_Firstname = fc["St_Firstname"];
            sd.St_Lastname = fc["St_Lastname"];
            sd.St_Pnr = fc["St_Pnr"];


            i = sm.InsertStudent(sd, out error);
            ViewBag.error = error;
            ViewBag.antal = i;

            //return View();
            return RedirectToAction("ListStudents");


        }

        public IActionResult ListStudents()
        {
            List<StudentDetalj> Studentlist = new List<StudentDetalj>();
            StudentMetoder sm = new StudentMetoder();

            string error = "";

            Studentlist = sm.GetStudentWithDataSet(out error);

            ViewBag.error = error;

            return View(Studentlist);
        }


        /*[HttpPost]
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
        */

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
        /*
        public ActionResult SelectWithDataReader()
        {
            List<StudentDetalj> Studentlist = new List<StudentDetalj>();
            StudentMetoder sm = new StudentMetoder();
            string error = "";
            Studentlist = sm.GetStudentWithReader(out error);
            ViewBag.error = error;
            return View(Studentlist);
        }
        */
    }


}
