using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_webapi_template.Models;

namespace dotnet_webapi_template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestContext _context;

        public TestController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestModel>>> GetTestModels()
        {
            return await _context.TestModels.ToListAsync();
        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestModel>> GetTestModel(long id)
        {
            var testModel = await _context.TestModels.FindAsync(id);

            if (testModel == null)
            {
                return NotFound();
            }

            return testModel;
        }

        // POST: api/Test
        [HttpPost]
        public async Task<ActionResult<TestModel>> PostTestModel(TestModel testModel)
        {
            _context.TestModels.Add(testModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTestModel), new { id = testModel.Id }, testModel);
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestModel(long id, TestModel testModel)
        {
            if (id != testModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(testModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestModel(long id)
        {
            var testModel = await _context.TestModels.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }

            _context.TestModels.Remove(testModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestModelExists(long id)
        {
            return _context.TestModels.Any(e => e.Id == id);
        }
    }
}