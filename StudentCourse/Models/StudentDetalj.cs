using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StudentCourse.Models
{
    public class StudentDetalj
    {
        //Konstruktor
        public StudentDetalj()
        {
        }

        //Publika egenskaper
        [Display(Name = "Förnamn")]
        public string St_Firstname { get; set; }
        [Display(Name = "Efternamn")]
        public string St_Lastname { get; set; }
        [Display(Name = "StudentID")]
        public int St_Id { get; set; }
        [Display(Name = "Personnummer")]
        public string St_Pnr { get; set; }
    }
}
