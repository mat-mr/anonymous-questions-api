using AnonymousQuestions.Repository.Context;
using AnonymousQuestions.Repository.Data;

namespace AnonymousQuestions.Repository
{
    public static class TestDataCreator
    {
        public static void Create(ApiContext context)
        {
            context.Replies.AddRange(ReplyData.GetAll());
            context.Questions.AddRange(QuestionData.GetAll());
            context.SaveChanges();
        }
    }
}