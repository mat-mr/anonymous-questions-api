using AnonymousQuestions.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnonymousQuestions.Api.Models
{
    public class QuestionModel
    {
        public long QuestionId { get; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public List<ReplyModel> Replies { get; set; }

        [JsonConstructor]
        public QuestionModel()
        {
        }

        public QuestionModel(Question question)
        {
            QuestionId = question.Id;
            Title = question.Title;
            Body = question.Body;
            Date = question.Date;
            Replies = question.Replies.Select(r => new ReplyModel(r)).ToList();
        }

        internal Question ToEntity()
        {
            return new Question(Title, Body, DateTime.Now);
        }
    }
}
