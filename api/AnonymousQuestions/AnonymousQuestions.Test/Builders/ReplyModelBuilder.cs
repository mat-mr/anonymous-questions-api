using AnonymousQuestions.Api.Models;

namespace AnonymousQuestions.Test.Builders
{
    public class ReplyModelBuilder : IBuilder<ReplyModel>
    {
        private string author = "author";
        private string body = "body";

        public ReplyModel Build()
        {
            return new ReplyModel() { Author = author, Body = body };
        }
    }
}