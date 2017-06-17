using AnonymousQuestions.Domain;
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

        [HttpGet]
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

        [HttpGet("{id}", Name = "GetQuestion")]
        public async Task<IActionResult> GetOne(long id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == id);

            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetQuestion", new { id = question.Id }, question);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == id);
            if (question == null)
                return NotFound();

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}