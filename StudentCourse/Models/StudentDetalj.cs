using System;
using System.Collections.Generic;
using System.Linq;
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
        public string St_Firstname { get; set; }
        public string St_Lastname { get; set; }
        public int St_Id { get; set; }
        public string St_Pnr { get; set; }
    }
}
