using backendForStudentRegisterApp.Database;
using backendForStudentRegisterApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendForStudentRegisterApp.Controllers
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

        [HttpGet("GetAllStudents")]
        public List<StudentEntity> GetAllStudents()
        {
            return _db.StudentRegister.ToList();

        }

        [HttpPost]
        public ActionResult<StudentEntity> AddStudent([FromBody]StudentEntity studentDetails)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            
            }
            studentDetails.Id = 0;

            _db.StudentRegister.Add(studentDetails);

            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex) 
            { 
            
             return StatusCode(500, ex.Message);
            
            }

            return Ok(studentDetails);
        
        }


     


       
        
    }
}
