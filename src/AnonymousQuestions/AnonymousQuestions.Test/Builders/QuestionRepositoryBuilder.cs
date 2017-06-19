using AnonymousQuestions.Repository;
using AnonymousQuestions.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnonymousQuestions.Test.Builders
{
    public class QuestionRepositoryBuilder : IBuilder<QuestionRepository>
    {
        private DbContextOptions options;
        private bool withData = false;

        public QuestionRepositoryBuilder WithDbContextOptions(DbContextOptions options)
        {
            this.options = options;
            return this;
        }

        public QuestionRepositoryBuilder WithData()
        {
            this.withData = true;
            return this;
        }

        public QuestionRepository Build()
        {
            options = options ?? GetDefaultDbContextOptions();

            var apiContext = new ApiContext(options);

            if (this.withData)
            {
                TestData.CreateData(apiContext);
            }

            return new QuestionRepository(apiContext);
        }

        private DbContextOptions GetDefaultDbContextOptions()
        {
            return new DbContextOptionsBuilder().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                                .Options;
        }
    }
}
