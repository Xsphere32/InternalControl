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
    public class QuestionsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public QuestionsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _dataContext.Questions.Select(m => new { m.Id, m.Name }).ToListAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(QuestionModel questionModel)
        {
            questionModel.TypeOfForm = await _dataContext.TypeOfForm.FirstOrDefaultAsync(i => i.Id == questionModel.TypeOfForm.Id);
            questionModel.GroupOfIndicators = await _dataContext.GroupOfIndicators.FirstOrDefaultAsync(i => i.Id == questionModel.GroupOfIndicators.Id);
            questionModel.Indicators = await _dataContext.Indicators.FirstOrDefaultAsync(i => i.Id == questionModel.Indicators.Id);
            var model = await _dataContext.Questions.FirstOrDefaultAsync(i => i.Name == questionModel.Name);
            if (model != null)
            {
                model.TypeOfForm = await _dataContext.TypeOfForm.FirstOrDefaultAsync(i => i.Id == questionModel.TypeOfForm.Id);
                model.GroupOfIndicators = await _dataContext.GroupOfIndicators.FirstOrDefaultAsync(i => i.Id == questionModel.GroupOfIndicators.Id);
                model.Indicators = await _dataContext.Indicators.FirstOrDefaultAsync(i => i.Id == questionModel.Indicators.Id);
                _dataContext.Questions.Update(model);
            }
            else
            {
                await _dataContext.AddAsync(questionModel);
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
            _dataContext.Entry(await _dataContext.Set<QuestionModel>().FirstOrDefaultAsync(i => i.Id == id)).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return Ok(true);
        }
        [EnableCors]
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> PostAllFiltered(BaseFilterModel filter)
        {
            var query = _dataContext.Questions.AsQueryable();
            if (filter.GroupOfIndicators != null)
            {
                query = query.Where(i => i.GroupOfIndicators.Id == filter.GroupOfIndicators.Id);
            }
            if (filter.TypeOfForm != null)
            {
                query = query.Where(i => i.TypeOfForm.Id == filter.TypeOfForm.Id);
            }
            if (filter.Indicators != null)
            {
                query = query.Where(i => i.Indicators.Id == filter.Indicators.Id);
            }
            return Ok(await query.Select(m => new { m.Id, m.Name }).ToListAsync());
        }
    }
}