using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnonymousQuestions.Domain;

namespace AnonymousQuestions.Api.Models
{
    public class ReplyModel
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        internal Reply ToEntity()
        {
            return new Reply(Author, Body, DateTime.Now);
        }
    }
}
