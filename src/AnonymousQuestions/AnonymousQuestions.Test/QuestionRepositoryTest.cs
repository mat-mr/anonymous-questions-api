using AnonymousQuestions.Api.Controllers;
using AnonymousQuestions.Api.Models;
using AnonymousQuestions.Repository;
using AnonymousQuestions.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnonymousQuestions.Test
{
    [TestClass]
    public class QuestionControllerTest
    {
        private const string DatabaseForGetAllQuestions = "GetAllQuestions";
        private const string DatabaseForGetOneQuestion = "GetOneQuestion";

        [TestMethod]
        public async Task GetAllQuestions_ShouldReturnAllQuestionsAsync()
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase(databaseName: DatabaseForGetAllQuestions)
                                                       .Options;
            var apiContext = new ApiContext(options);
            TestData.CreateData(apiContext);
            var questionRepository = new QuestionRepository(apiContext);
            var questionController = new QuestionsController(questionRepository);

            var result = await questionController.Get();
            var okResult = result as OkObjectResult;
            var questions = okResult.Value as List<QuestionModel>;

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
            Assert.AreEqual(2, questions.Count);

            apiContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task GetOneQuestions_ShouldReturnOneQuestionAsync()
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase(databaseName: DatabaseForGetOneQuestion)
                                                       .Options;

            var apiContext = new ApiContext(options);
            TestData.CreateData(apiContext);
            var questionRepository = new QuestionRepository(apiContext);
            var questionController = new QuestionsController(questionRepository);

            var result = await questionController.GetOne(1);
            var okResult = result as OkObjectResult;
            var question = okResult.Value as QuestionModel;

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));

            apiContext.Database.EnsureDeleted();
        }

    }
}
