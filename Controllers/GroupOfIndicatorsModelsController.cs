using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalControl.Core.Core;
using InternalControl.Core.Models;

namespace InternalControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupOfIndicatorsModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public GroupOfIndicatorsModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GroupOfIndicatorsModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupOfIndicatorsModel>>> GetGroupOfIndicators()
        {
            return await _context.GroupOfIndicators.ToListAsync();
        }

        // GET: api/GroupOfIndicatorsModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupOfIndicatorsModel>> GetGroupOfIndicatorsModel(int id)
        {
            var groupOfIndicatorsModel = await _context.GroupOfIndicators.FindAsync(id);

            if (groupOfIndicatorsModel == null)
            {
                return NotFound();
            }

            return groupOfIndicatorsModel;
        }

        // PUT: api/GroupOfIndicatorsModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupOfIndicatorsModel(int id, GroupOfIndicatorsModel groupOfIndicatorsModel)
        {
            if (id != groupOfIndicatorsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupOfIndicatorsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupOfIndicatorsModelExists(id))
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

        // POST: api/GroupOfIndicatorsModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GroupOfIndicatorsModel>> PostGroupOfIndicatorsModel(GroupOfIndicatorsModel groupOfIndicatorsModel)
        {
            _context.GroupOfIndicators.Add(groupOfIndicatorsModel);
            await _context.SaveChangesAsync();

            return Ok(groupOfIndicatorsModel);
        }

        // DELETE: api/GroupOfIndicatorsModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupOfIndicatorsModel>> DeleteGroupOfIndicatorsModel(int id)
        {
            var groupOfIndicatorsModel = await _context.GroupOfIndicators.FindAsync(id);
            if (groupOfIndicatorsModel == null)
            {
                return NotFound();
            }

            _context.GroupOfIndicators.Remove(groupOfIndicatorsModel);
            await _context.SaveChangesAsync();

            return groupOfIndicatorsModel;
        }

        private bool GroupOfIndicatorsModelExists(int id)
        {
            return _context.GroupOfIndicators.Any(e => e.Id == id);
        }
    }
}
