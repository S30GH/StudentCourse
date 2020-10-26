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

        [HttpGet]
        public IActionResult InsertCourse()
        {
            CourseDetalj cd = new CourseDetalj();
            CourseMetoder cm = new CourseMetoder();
            int i = 0;
            string error = "";

            //i = sm.InsertStudent(sd, out error);
            ViewBag.error = error;
            ViewBag.antal = i;

            return View();
        }

        [HttpPost]
        public IActionResult InsertCourse(IFormCollection fc)
        {
            CourseDetalj cd = new CourseDetalj();
            CourseMetoder cm = new CourseMetoder();
            int i = 0;
            string error = "";

            cd.Co_Name = fc["Co_Name"];
            cd.Co_Period = fc["Co_Period"];
            cd.Co_Studyrate = fc["Co_Studyrate"];


            i = cm.InsertCourse(cd, out error);
            ViewBag.error = error;
            ViewBag.antal = i;

            //return View();
            return RedirectToAction("ListCourses");


        }

        public IActionResult ListCourses()
        {
            List<CourseDetalj> Courselist = new List<CourseDetalj>();
            CourseMetoder cm = new CourseMetoder();

            string error = "";

            Courselist = cm.GetCourseWithDataSet(out error);

            ViewBag.error = error;

            return View(Courselist);
        }

        public IActionResult DeleteStudent(int id)
        {
            StudentMetoder sm = new StudentMetoder();

            int i = sm.DeleteStudent(id, out string error);
            ViewBag.error = error;
            ViewBag.antal = i;

            return View();
        }

        public IActionResult DeleteCourse(int id)
        {
            CourseMetoder cm = new CourseMetoder();
            int i = cm.DeleteCourse(id, out string error);
            ViewBag.error = error;
            ViewBag.antal = i;

            return View();
        }

        public IActionResult UpdateStudent(IFormCollection fc, int id)
        {
            StudentDetalj sd = new StudentDetalj();
            StudentMetoder sm = new StudentMetoder();

            int i = 0;
            string error = "";

            sd.St_Firstname = fc["St_Firstname"];
            sd.St_Lastname = fc["St_Lastname"];
            sd.St_Pnr = fc["St_Pnr"];

            i = sm.UpdateStudent(sd, id, out error);
            ViewBag.error = error;
            ViewBag.antal = i;


            return View();
        }
        public IActionResult UpdateCourse(IFormCollection fc, int id)
        {
            CourseDetalj cd = new CourseDetalj();
            CourseMetoder cm = new CourseMetoder();

            int i = 0;
            string error = "";

            cd.Co_Name = fc["Co_Name"];
            cd.Co_Period = fc["Co_Period"];
            cd.Co_Studyrate = fc["Co_Studyrate"];

            i = cm.UpdateCourse(cd, id, out error);
            ViewBag.error = error;
            ViewBag.antal = i;


            return View();
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

        /*
        public IActionResult DeleteStudent()
        {
            StudentMetoder sm = new StudentMetoder();
            string error = "";
            int i = 0;
            i = sm.DeleteStudent(out error);
            HttpContext.Session.SetString("antal", i.ToString());
            return RedirectToAction("SelectWithDataSet");
        }
        */

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
