using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiCRUD.DBContext;
using MyWebApiCRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCRUD.Controllers
{
    [Route("[controller]")]
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly AppDbContext contextDB;

        public AlumnoController(AppDbContext context)
        {
            this.contextDB = context;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return contextDB.Student.ToList();
        }

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            var alumno = contextDB.Student.FirstOrDefault(x => x.idStudent == id);
            return alumno;
        }

        [HttpPost]
        public ActionResult AddNewStudent([FromBody]Student alumno)
        {
            try
            {
                contextDB.Student.Add(alumno);
                contextDB.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult ModifyStudent(int id, [FromBody]Student alumno)
        {
            if (alumno.idStudent == id)
            {
                contextDB.Entry(alumno).State = EntityState.Modified;
                contextDB.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var alumno = contextDB.Student.FirstOrDefault(p => p.idStudent == id);
            if (alumno != null)
            {
                contextDB.Student.Remove(alumno);
                contextDB.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}