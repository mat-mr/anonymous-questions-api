using AnonymousQuestions.Api.Controllers;
using AnonymousQuestions.Api.Models;
using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnonymousQuestions.Test
{
    [TestClass]
    public class QuestionRepositoryTest
    {
        [TestMethod]
        public async Task GetAllProducts_ShouldReturnAllProductsAsync()
        {
            var mockRepo = new Mock<IQuestionRepository>();
            mockRepo.Setup(repo => repo.FindAllAsync()).Returns(Task.FromResult(GetTestSessions()));
            var controller = new QuestionsController(mockRepo.Object);

            var result = await controller.Get() as List<QuestionModel>;
            Assert.AreEqual(2, result.Count);
        }

        private List<Question> GetTestSessions()
        {
            return new List<Question>()
            {
                new Question("Como fazer uma API?", "Gostaria de saber como fazer uma API restful."),
                new Question("Fortran 90", "Como se usa essa linguagem tão moderna?")
            };
        }
    }
}
