using AnonymousQuestions.Api.Controllers;
using AnonymousQuestions.Domain;

namespace AnonymousQuestions.Test.Builders
{
    public class QuestionsControllerBuilder : IBuilder<QuestionsController>
    {
        private IQuestionRepository questionRepository = new QuestionRepositoryBuilder().Build();

        public QuestionsControllerBuilder WithRepository(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
            return this;
        }

        public QuestionsController Build()
        {

            return new QuestionsController(questionRepository);
        }
    }
}
