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
    public class IndicatorsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public IndicatorsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dataContext.Indicators.Select(m => new { m.Id, m.Name }).ToListAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(IndicatorsModel indicatorModel)
        {
            indicatorModel.TypeOfForm = await _dataContext.TypeOfForm.FirstOrDefaultAsync(i => i.Id == indicatorModel.TypeOfForm.Id);
            indicatorModel.GroupOfIndicators = await _dataContext.GroupOfIndicators.FirstOrDefaultAsync(i => i.Id == indicatorModel.GroupOfIndicators.Id);
            var model = await _dataContext.Indicators.FirstOrDefaultAsync(i => i.Name == indicatorModel.Name);
            if (model != null)
            {
                model.TypeOfForm = await _dataContext.TypeOfForm.FirstOrDefaultAsync(i => i.Id == indicatorModel.TypeOfForm.Id);
                model.GroupOfIndicators = await _dataContext.GroupOfIndicators.FirstOrDefaultAsync(i => i.Id == indicatorModel.GroupOfIndicators.Id);
                _dataContext.Indicators.Update(model);
            }
            else
            {
                await _dataContext.AddAsync(indicatorModel);
            }
            int? x = await _dataContext.SaveChangesAsync();
            if (x.HasValue)
                return Ok(true);
            else
                return BadRequest("Прозошла ошибка");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _dataContext.Entry(await _dataContext.Set<IndicatorsModel>().FirstOrDefaultAsync(i => i.Id == id)).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> PostAllFiltered(BaseFilterModel filter)
        {
            var query = _dataContext.Indicators.AsQueryable();
            if (filter.GroupOfIndicators != null)
            {
                query = query.Where(i => i.GroupOfIndicators.Id == filter.GroupOfIndicators.Id);
            }
            if (filter.TypeOfForm != null)
            {
                query = query.Where(i => i.TypeOfForm.Id == filter.TypeOfForm.Id);
            }
            return Ok(await query.ToListAsync());
        }
    }
}