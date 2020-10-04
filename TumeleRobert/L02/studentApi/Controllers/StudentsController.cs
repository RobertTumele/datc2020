using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace studentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        [HttpGet("list")]
        public IEnumerable<Student> Get()
        {
            return StudentRepo.Students;
        }
        
        [HttpGet("{id}")]
        public Student GetStudent([FromRoute] int id){
            return StudentRepo.Students.FirstOrDefault(s => s.Id == id);
        }
        [HttpPost]
        public string Post([FromBody] Student student){
            try
            {
                StudentRepo.Students.Add(student);
                return "S-a adugat cu succes!";
            }
            catch (System.Exception e)
            {
                return "Eroarea: "+e.Message;
                throw;
            }
        }
    }
}
