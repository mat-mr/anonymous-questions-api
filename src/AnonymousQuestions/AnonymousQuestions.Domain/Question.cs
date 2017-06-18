using System;
using System.Collections.Generic;

namespace AnonymousQuestions.Domain
{
    public class Question
    {
        public long Id { get; private set; }

        public string Title { get; private set; }

        public string Body { get; private set; }

        public DateTime Date { get; private set; }

        public virtual List<Reply> Replies { get; private set; }

        private Question()
        {
            this.Replies = new List<Reply>();
        }

        public Question(string title, string body, DateTime date)
            : this()
        {
            this.Title = title;
            this.Body = body;
            this.Date = date;
        }

        public Question(long id, string title, string body, DateTime date)
            : this(title, body, date)
        {
            this.Id = id;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void AddReply(Reply reply)
        {
            Replies.Add(reply);
        }
    }
}
