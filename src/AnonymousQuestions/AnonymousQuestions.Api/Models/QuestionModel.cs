using AnonymousQuestions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnonymousQuestions.Api.Models
{
    public class QuestionModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public List<ReplyModel> Replies { get; set; }

        internal Question ToEntity()
        {
            return new Question(Title, Body, DateTime.Now);
        }
    }
}
