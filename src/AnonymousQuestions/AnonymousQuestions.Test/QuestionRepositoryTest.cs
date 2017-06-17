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
        private readonly QuestionRepository _questionRepository = new QuestionRepository();

        [TestMethod]
        public void FindAll_MustFindAllQuestions()
        {
            Assert.AreEqual(0, _questionRepository.FindAll().Count);
        }
    }
}
