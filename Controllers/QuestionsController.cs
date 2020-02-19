using System.Threading.Tasks;
using InternalControl.Core.Core;
using InternalControl.Core.Models;
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

            return Ok("Test Message");
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(QuestionModel questionModel)
        {
            questionModel.GroupOfIndicators = await _dataContext.GroupOfIndicators.FirstOrDefaultAsync(i => i.Id == questionModel.GroupOfIndicators.Id);
            questionModel.Indicators = await _dataContext.Indicators.FirstOrDefaultAsync(i => i.Id == questionModel.Indicators.Id);
            questionModel.TypeOfForm = await _dataContext.TypeOfForm.FirstOrDefaultAsync(i => i.Id == questionModel.Indicators.Id);
            await _dataContext.AddAsync(questionModel);
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
    }
}