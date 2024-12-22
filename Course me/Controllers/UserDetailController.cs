using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public UserDetailsController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userDetails = _context.UserDetails.Include(ud => ud.User).ToList();
            return Ok(userDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userDetail = _context.UserDetails.Include(ud => ud.User).FirstOrDefault(ud => ud.UserDetailId == id);
            if (userDetail == null)
            {
                return NotFound(new { message = "User detail not found" });
            }
            return Ok(userDetail);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDetail userDetail)
        {
            if (userDetail == null)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            _context.UserDetails.Add(userDetail);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = userDetail.UserDetailId }, userDetail);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDetail updatedUserDetail)
        {
            if (updatedUserDetail == null || updatedUserDetail.UserDetailId != id)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            var existingUserDetail = _context.UserDetails.FirstOrDefault(ud => ud.UserDetailId == id);
            if (existingUserDetail == null)
            {
                return NotFound(new { message = "User detail not found" });
            }

            existingUserDetail.FullName = updatedUserDetail.FullName;
            existingUserDetail.BirthDate = updatedUserDetail.BirthDate;
            existingUserDetail.Gender = updatedUserDetail.Gender;
            existingUserDetail.HeightCm = updatedUserDetail.HeightCm;
            existingUserDetail.WeightKg = updatedUserDetail.WeightKg;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userDetail = _context.UserDetails.FirstOrDefault(ud => ud.UserDetailId == id);
            if (userDetail == null)
            {
                return NotFound(new { message = "User detail not found" });
            }

            _context.UserDetails.Remove(userDetail);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
