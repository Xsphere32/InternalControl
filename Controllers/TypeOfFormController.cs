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
    public class TypeOfFormController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TypeOfFormController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dataContext.TypeOfForm.Select(m => new { m.Id, m.Name }).ToListAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(TypeOfForm typeOfFormModel)
        {
            _dataContext.Entry(typeOfFormModel).State = EntityState.Added;
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