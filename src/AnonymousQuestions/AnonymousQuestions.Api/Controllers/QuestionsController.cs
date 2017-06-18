using AnonymousQuestions.Api.Models;
using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        #region GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var questions = await _context.Questions
                    .Include(q => q.Replies)
                    .ToArrayAsync();

            var response = questions.Select(u => new
            {
                id = u.Id,
                title = u.Title,
                body = u.Body,
                date = u.Date,
                replies = u.Replies
            });

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetQuestion")]
        public async Task<IActionResult> GetOne(long id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == id);
            if (question == null)
                return NotFound();

            return Ok(question);
        }

        [HttpGet("unanswered")]
        public async Task<IActionResult> GetUnanswered()
        {
            var questions = await _context.Questions.ToArrayAsync();

            var response = questions.Where(q => q.Replies.Count == 0).Select(u => new
            {
                id = u.Id,
                title = u.Title,
                body = u.Body,
                date = u.Date,
                replies = u.Replies
            });

            return Ok(response);
        }
        #endregion GET

        #region POST
        [HttpPost("{idQuestion}/reply")]
        public async Task<IActionResult> AddReply([FromBody]ReplyModel replyModel, long idQuestion)
        {
            var question = await _context.Questions.FindAsync(idQuestion);
            if (question == null)
                return NotFound();

            question.AddReply(replyModel.ToEntity());

            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetQuestion", new { id = question.Id }, question);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]QuestionModel questionModel)
        {
            var question = await _context.Questions.AddAsync(questionModel.ToEntity());
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetQuestion", new { id = question.Entity.Id }, question.Entity);
        }
        #endregion POST

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