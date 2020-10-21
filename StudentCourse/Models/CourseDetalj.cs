using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StudentCourse.Models
{
    public class CourseDetalj
    {
        //Konstruktor
        public CourseDetalj()
        {
        }

        //Publika egenskaper
        [Display(Name = "Kursnamn")]
        public string Co_Name { get; set; }
        [Display(Name = "Period")]
        public string Co_Period { get; set; }
        [Display(Name = "Studietakt")]
        public string Co_Studyrate { get; set; }
        [Display(Name = "KursID")]
        public int Co_Id { get; set; }

    }
}
