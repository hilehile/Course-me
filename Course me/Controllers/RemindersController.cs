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
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _reminderService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _reminderService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(Reminder reminder)
        {
            await _reminderService.AddAsync(reminder);
            return CreatedAtAction(nameof(GetById), new { id = reminder.ReminderId }, reminder);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Reminder reminder)
        {
            await _reminderService.UpdateAsync(reminder);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.DeleteAsync(id);
            return NoContent();
        }
    }
}
