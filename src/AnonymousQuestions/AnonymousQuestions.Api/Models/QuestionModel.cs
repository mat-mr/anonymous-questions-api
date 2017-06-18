using AnonymousQuestions.Domain;
using System.Collections.Generic;

namespace AnonymousQuestions.Api.Models
{
    public class QuestionModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<ReplyModel> Replies { get; set; }

        internal Question ToEntity()
        {
            return new Question(Title, Body);
        }
    }
}
