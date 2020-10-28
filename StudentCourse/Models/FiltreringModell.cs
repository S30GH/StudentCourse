using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentCourse.Models
{
    public class FiltreringModell

    {
        public IEnumerable<StudentCourseDetalj> StudentCourseDetaljLista { get; set; }
        public IEnumerable<CourseDetalj> CourseDetaljLista { get; set; }

        public IEnumerable<StudentDetalj> StudentDetaljLista { get; set; }
       

    }
}
