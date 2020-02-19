using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalControl.Core.Core;
using InternalControl.Core.Models;
using Microsoft.AspNetCore.Http;
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
            return Ok(await _dataContext.Questions.ToListAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(QuestionModel questionModel)
        {
            questionModel.GroupOfIndicators = await _dataContext.GroupOfIndicators.FirstOrDefaultAsync(i => i.Id == questionModel.GroupOfIndicators.Id);
            questionModel.Indicators = await _dataContext.Indicators.FirstOrDefaultAsync(i => i.Id == questionModel.Indicators.Id);
            await _dataContext.AddAsync(questionModel);
            int? x = await _dataContext.SaveChangesAsync();
            if (x.HasValue)
                return Ok(true);
            else
                return BadRequest("Прозошла ошибка");
            
        }
    }
}