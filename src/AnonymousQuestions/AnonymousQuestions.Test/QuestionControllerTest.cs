using AnonymousQuestions.Api.Models;
using AnonymousQuestions.Domain;
using AnonymousQuestions.Test.Builders;
using AnonymousQuestions.Test.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnonymousQuestions.Test
{
    [TestClass]
    public class QuestionControllerTest
    {
        private readonly QuestionModel _questionModel = new QuestionModelBuilder().Build();
        private readonly QuestionModel _questionModel2 = new QuestionModelBuilder().Build();
        private readonly ReplyModel _replyModel = new ReplyModelBuilder().Build();

        [TestMethod]
        public async Task Get_ShouldReturnAllQuestions()
        {

            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            await questionController.Add(_questionModel);
            await questionController.Add(_questionModel2);

            var okResult = await questionController.Get();
            var questions = okResult.Cast<OkObjectResult, List<QuestionModel>>();

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
            Assert.AreEqual(2, questions.Count);
        }

        [TestMethod]
        public async Task GetOne_ShouldReturnOneQuestion()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var savedQuestion = (await questionController.Add(_questionModel)).Cast<CreatedAtRouteResult, Question>();

            var okResult = await questionController.GetOne(savedQuestion.Id);
            var question = okResult.Cast<OkObjectResult, QuestionModel>();

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetOne_ShouldReturnNotFoundIfQuestionNotExists()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var notFoundResult = await questionController.GetOne(1);

            Assert.IsInstanceOfType(notFoundResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetUnanswered_ShouldReturnUnanswered()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var savedQuestion = (await questionController.Add(_questionModel)).Cast<CreatedAtRouteResult, Question>();
            await questionController.Add(_questionModel2);

            await questionController.AddReply(_replyModel, savedQuestion.Id);

            var okResult = await questionController.GetUnanswered();
            var questions = okResult.Cast<OkObjectResult, List<QuestionModel>>();

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
            Assert.AreEqual(1, questions.Count);
            Assert.IsFalse(questions.TrueForAll(q => q.Replies.Count > 0));
        }

        [TestMethod]
        public async Task Add_ShouldAddQuestion()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var okResult = await questionController.Add(_questionModel);

            Assert.IsInstanceOfType(okResult, typeof(CreatedAtRouteResult));
        }

        [TestMethod]
        public async Task Add_ShouldReturnBadRequestIfQuestionModelIsNotSend()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var badRequestResult = await questionController.Add(null);

            Assert.IsInstanceOfType(badRequestResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task AddReply_ShouldAddReplyToQuestion()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var savedQuestion = (await questionController.Add(_questionModel)).Cast<CreatedAtRouteResult, Question>();

            var okResult = await questionController.AddReply(_replyModel, savedQuestion.Id);

            Assert.IsInstanceOfType(okResult, typeof(CreatedAtRouteResult));
        }


        [TestMethod]
        public async Task AddReply_ShouldReturnNotFoundIfQuestionNotExists()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var okResult = await questionController.AddReply(_replyModel, 1);

            Assert.IsInstanceOfType(okResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task AddReply_ShouldReturnBadRequestIfReplyModelIsNotSend()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var badRequestResult = await questionController.AddReply(null, 1);

            Assert.IsInstanceOfType(badRequestResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task Remove_ShouldRemoveQuestion()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var savedQuestion = (await questionController.Add(_questionModel)).Cast<CreatedAtRouteResult, Question>();
            var allQuestions = (await questionController.Get()).Cast<OkObjectResult, List<QuestionModel>>();

            Assert.AreEqual(1, allQuestions.Count);

            var okResult = await questionController.Remove(savedQuestion.Id);
            allQuestions = (await questionController.Get()).Cast<OkObjectResult, List<QuestionModel>>();

            Assert.IsInstanceOfType(okResult, typeof(OkResult));
            Assert.AreEqual(0, allQuestions.Count);
        }

        [TestMethod]
        public async Task Remove_ShouldReturnNotFoundIfQuestionNotExists()
        {
            var questionRepository = new QuestionRepositoryBuilder().Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var notFoundResult = await questionController.Remove(1);

            Assert.IsInstanceOfType(notFoundResult, typeof(NotFoundResult));
        }
    }
}
