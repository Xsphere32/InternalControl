using System.Linq;
using System.Threading.Tasks;
using InternalControl.Core.Core;
using InternalControl.Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternalControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupOfIndicatorsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public GroupOfIndicatorsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dataContext.GroupOfIndicators.Select(m => new { m.Id, m.Name }).ToListAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(GroupOfIndicatorsModel groupOfIndicatorsModel)
        {
            groupOfIndicatorsModel.TypeOfForm = await _dataContext.TypeOfForm.FirstOrDefaultAsync(i => i.Id == groupOfIndicatorsModel.TypeOfForm.Id);
            var model = await _dataContext.GroupOfIndicators.FirstOrDefaultAsync(i => i.Name == groupOfIndicatorsModel.Name);
            if (model != null)
            {
                model.TypeOfForm = groupOfIndicatorsModel.TypeOfForm;
                _dataContext.GroupOfIndicators.Update(model);
            }
            else
            {
                await _dataContext.AddAsync(groupOfIndicatorsModel);
            }
            int? x = await _dataContext.SaveChangesAsync();
            if (x.HasValue)
                return Ok(true);
            else
                return BadRequest("Произошла ошибка");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _dataContext.Entry(await _dataContext.Set<GroupOfIndicatorsModel>().FirstOrDefaultAsync(i => i.Id == id)).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> PostAllFiltered(BaseFilterModel filter)
        {
            var query = _dataContext.GroupOfIndicators.AsQueryable();
            if (filter.TypeOfForm != null)
            {
                query = query.Where(i => i.TypeOfForm.Id == filter.TypeOfForm.Id);
            }
            return Ok(await query.ToListAsync());
        }
    }
}