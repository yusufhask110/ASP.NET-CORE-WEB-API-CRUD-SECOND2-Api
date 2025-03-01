using ASP.NET_CORE_WEB_API__CRUD_SECOND2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_WEB_API__CRUD_SECOND2.Controllers
{
    /*student controller class*/
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDatabaseContext context;

        public StudentController(MyDatabaseContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Getstudent()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Getstudentbyid(double id)
        {
            var studentid = await context.Students.FindAsync(id);
            if (studentid == null)
            {
                return NotFound();
            }
            return Ok(studentid);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> createstudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> updateStudent(double id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> deletebyid(double id)
        {
            var stddelete = await context.Students.FindAsync(id);
            if (stddelete == null)
            {
                return NotFound();
            }
            context.Students.Remove(stddelete);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}