using AnonymousQuestions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnonymousQuestions.Domain;
using Newtonsoft.Json;

namespace AnonymousQuestions.Api.Models
{
    public class ReplyModel
    {
        public long ReplyId { get; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        [JsonConstructor]
        public ReplyModel()
        {
        }

        public ReplyModel(Reply reply)
        {
            ReplyId = reply.Id;
            Author = reply.Author;
            Body = reply.Body;
            Date = reply.Date;
        }

        internal Reply ToEntity()
        {
            return new Reply(Author, Body);
        }
    }
}
