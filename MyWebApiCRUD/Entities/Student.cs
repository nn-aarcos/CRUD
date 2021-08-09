using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCRUD.Entities
{
    public class Student
    {
        [Key]
        public int idStudent { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telphone { get; set; }
        public string grade { get; set; }
    }
}