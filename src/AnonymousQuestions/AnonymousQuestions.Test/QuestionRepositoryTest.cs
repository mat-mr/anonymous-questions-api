using AnonymousQuestions.Api.Models;
using AnonymousQuestions.Test.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnonymousQuestions.Test
{
    [TestClass]
    public class QuestionControllerTest
    {
        [TestMethod]
        public async Task GetAllQuestions_ShouldReturnAllQuestionsAsync()
        {

            var questionRepository = new QuestionRepositoryBuilder().WithData()
                                                                    .Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var result = await questionController.Get();
            var okResult = result as OkObjectResult;
            var questions = okResult.Value as List<QuestionModel>;

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
            Assert.AreEqual(2, questions.Count);
        }

        [TestMethod]
        public async Task GetOneQuestions_ShouldReturnOneQuestionAsync()
        {
            var questionRepository = new QuestionRepositoryBuilder().WithData()
                                                                    .Build();
            var questionController = new QuestionsControllerBuilder().WithRepository(questionRepository)
                                                                     .Build();

            var result = await questionController.GetOne(1);
            var okResult = result as OkObjectResult;
            var question = okResult.Value as QuestionModel;

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }


    }
}
