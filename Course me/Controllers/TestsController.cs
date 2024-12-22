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
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _testService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _testService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(Test test)
        {
            await _testService.AddAsync(test);
            return CreatedAtAction(nameof(GetById), new { id = test.TestId }, test);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Test test)
        {
            await _testService.UpdateAsync(test);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _testService.DeleteAsync(id);
            return NoContent();
        }
    }
}
