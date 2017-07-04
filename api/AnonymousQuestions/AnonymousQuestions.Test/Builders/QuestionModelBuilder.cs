using AnonymousQuestions.Api.Models;
using System;

namespace AnonymousQuestions.Test.Builders
{
    public class QuestionModelBuilder : IBuilder<QuestionModel>
    {
        private string title = "title";
        private string body = "body";

        public QuestionModel Build()
        {
            return new QuestionModel() { Title = title, Body = body };
        }
    }
}
