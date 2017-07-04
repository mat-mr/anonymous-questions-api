using AnonymousQuestions.Repository.Context;

namespace AnonymousQuestions.Repository.Data
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