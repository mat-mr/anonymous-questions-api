using AnonymousQuestions.Api.Controllers;
using AnonymousQuestions.Repository;
using AnonymousQuestions.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Test
{
    public class QuestionsControllerBuilder : IBuilder<QuestionsController>
    {
        private DbContextOptions options = new DbContextOptions<ApiContext>();
        private bool withData = false;

        public QuestionsControllerBuilder WithOptions(DbContextOptions options)
        {
            this.options = options;
            return this;
        }

        public QuestionsControllerBuilder WithData()
        {
            this.withData = true;
            return this;
        }

        public QuestionsController Build()
        {
            var apiContext = new ApiContext(options);

            if (this.withData)
            {
                TestData.CreateData(apiContext);
            }

            var questionRepository = new QuestionRepository(apiContext);
            return new QuestionsController(questionRepository);
        }
    }
}
