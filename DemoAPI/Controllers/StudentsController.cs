using DemoAPI.Data;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private ApplicationDbContext _db;

        public StudentsController(ApplicationDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public List<StudentEntity> GetAllStudent()
        {
            return _db.StudentRegister.ToList();
        }


        [HttpGet("GetAllStudents")]


        public string GetStudent()
        {
            return "Hello world";
        }

        [HttpGet("GetStudentsById")]
        public ActionResult<StudentEntity> GetStudentDetails(int Id) {
            //validate the id 
            if (Id == 0)
            {
                return BadRequest();
            }
            var StudentDetails = _db.StudentRegister.FirstOrDefault(
                x => x.Id == Id
                );
            if (StudentDetails == null)
            {
                return NotFound();
            }




            return StudentDetails;


        }



        [HttpPost]
        public ActionResult<StudentEntity> AddStudent([FromBody] StudentEntity studentDetails)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure Id is not set manually (optional)
            studentDetails.Id = 0; // Reset Id to default to ensure no explicit value is set

            // Add the new student entity to the context
            _db.StudentRegister.Add(studentDetails);

            // Save changes to the database
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a server error response
                // (You might want to log the exception details for further investigation)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the entity.");
            }

            // Return the added student entity
            return Ok(studentDetails);
        }
        [HttpPost("UpdateUser")]
       /* public ActionResult<StudentEntity> UpdateStudent(int Id, [FromBody] StudentEntity studentDetails)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StudentDetails = _db.StudentRegister.FirstOrDefault(x => x.Id == Id);


            if (studentDetails == null)
            {
                return NotFound();
            }


            StudentDetails.Name = studentDetails.Name;
            StudentDetails.Age = studentDetails.Age;
            StudentDetails.Standard = studentDetails.Standard;
            studentDetails.EmailAddress = studentDetails.EmailAddress;

            // Add the new student entity to the context
            //_db.StudentRegister.Add(studentDetails);
            _db.SaveChanges();
            return Ok(StudentDetails);


        }*/

        [HttpPut("DeleteStudent")]
        public ActionResult<StudentEntity> DeleteStudent(int Id, [FromBody] StudentEntity studentDetails)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StudentDetails = _db.StudentRegister.FirstOrDefault(x => x.Id == Id);


            if (studentDetails == null)
            {
                return NotFound();
            }

            _db.StudentRegister.Remove(StudentDetails);

            
            _db.SaveChanges();
            return NoContent();


        }


    }
}