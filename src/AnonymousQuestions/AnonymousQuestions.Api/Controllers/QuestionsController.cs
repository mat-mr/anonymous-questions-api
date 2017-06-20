using AnonymousQuestions.Api.Models;
using AnonymousQuestions.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AnonymousQuestions.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        #region GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var questions = await _questionRepository.FindAllAsync();

            var response = questions.Select(q => new QuestionModel(q))
                                    .ToList();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetQuestion")]
        public async Task<IActionResult> GetOne(long id)
        {
            var question = await _questionRepository.FindAsync(id);

            if (question == null)
                return NotFound();

            return Ok(new QuestionModel(question));
        }

        [HttpGet("unanswered")]
        public async Task<IActionResult> GetUnanswered()
        {
            var questions = await _questionRepository.FindAllUnansweredAsync();
            var response = questions.Select(q => new QuestionModel(q))
                                    .ToList();
            return Ok(response);
        }
        #endregion GET

        #region POST

        [HttpPost("{idQuestion}/reply")]
        public async Task<IActionResult> AddReply([FromBody]ReplyModel replyModel, long idQuestion)
        {
            if (!ModelState.IsValid || replyModel == null)
                return BadRequest();

            var question = await _questionRepository.FindAsync(idQuestion);

            if (question == null)
                return NotFound();

            var reply = replyModel.ToEntity();
            question.AddReply(reply);

            await _questionRepository.UpdateAsync(question);

            return CreatedAtRoute("GetQuestion", new { id = question.Id }, question);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]QuestionModel questionModel)
        {
            if (!ModelState.IsValid || questionModel == null)
                return BadRequest();

            var question = questionModel.ToEntity();
            var savedQuestion = await _questionRepository.AddAsync(question);

            return CreatedAtRoute("GetQuestion", new { id = savedQuestion.Id }, savedQuestion);
        }
        #endregion POST

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            var question = await _questionRepository.FindAsync(id);

            if (question == null)
                return NotFound();

            await _questionRepository.RemoveAsync(id);

            return Ok();
        }
    }
}