using APIDemo13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCustomController : ControllerBase
    {
        //Insertar los estudiantes

        private readonly SchoolContext _context;

        public StudentCustomController(SchoolContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(Student student)
        {
            student.IsActive = true;
            _context.Students.Add(student);
            _context.SaveChanges();           
        }

        [HttpDelete]
        public void Delete(int Id)
        {

            //Busco
            var student = _context.Students.Where(x=>x.IsActive==true && x.StudentID== Id).FirstOrDefault();
            //Preparo para modificarse
            
            student.IsActive = false;
            _context.Entry(student).State = EntityState.Modified;
           
            //Commit
            _context.SaveChanges();

        }


        [HttpGet]
        public List<Student> Get()
        {
            //Expresiones lambda
            var response = _context.Students.Where(x => x.IsActive == true).ToList();
            return response;

        }
        [HttpGet]
        public List<Student> GetOrderByCity()
        {
            //Expresiones lambda
            var response = _context.Students.Where(x => x.IsActive == true)
                .OrderByDescending(x=>x.City)
                .ToList();
            return response;

        }


        [HttpGet]
        public Student GetById(int Id)
        {
            //Expresiones lambda
            var response = _context.Students.Where(x => x.StudentID==Id && x.IsActive==true).FirstOrDefault();
            return response;
        }
    }
}
