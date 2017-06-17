using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.EntityFrameworkCore;
using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository;
using System.Collections.Generic;

namespace AnonymousQuestions.Test
{
    [TestClass]
    public class QuestionRepositoryTest
    {
        private readonly Mock<IAnonymousQuestionsContext> _dbContextMock = new Mock<IAnonymousQuestionsContext>();

        [TestMethod]
        public void FindAll_MustFindAllQuestions()
        {
            var question = new Question { Title = "title", Body = "body", Date = DateTime.Today };
            var _questionRepositoryMock = new QuestionRepository(_dbContextMock.Object);
            Mock<DbSet<Question>> _questionDBSetMock = DbSetMock.Create(question);
            _dbContextMock.Setup(m => m.Questions).Returns(_questionDBSetMock.Object);

            Assert.AreEqual(1, _questionRepositoryMock.FindAll().Count);
        }
    }
}
