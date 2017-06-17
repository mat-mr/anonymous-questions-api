using AnonymousQuestions.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnonymousQuestions.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private readonly ApiContext _context;

        public QuestionsController(ApiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            var questions = await _context.Questions.ToArrayAsync();

            var response = questions.Select(u => new
            {
                id = u.Id,
                title = u.Title,
                body = u.Body,
                date = u.Date
            });

            return Ok(response);
        }
    }
}