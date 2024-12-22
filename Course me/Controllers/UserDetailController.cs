using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using BusinessLogic.Services;
using DataAccess;
using Domain.Interfaces;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserDetailService _userDetailService;

        public UserDetailController(IUserDetailService userDetailService)
        {
            _userDetailService = userDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userDetailService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _userDetailService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(UserDetail userDetail)
        {
            await _userDetailService.AddAsync(userDetail);
            return CreatedAtAction(nameof(GetById), new { id = userDetail.UserDetailId }, userDetail);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDetail userDetail)
        {
            await _userDetailService.UpdateAsync(userDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userDetailService.DeleteAsync(id);
            return NoContent();
        }
    }
}
