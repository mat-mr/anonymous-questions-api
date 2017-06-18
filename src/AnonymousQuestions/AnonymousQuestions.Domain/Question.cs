using System;

namespace AnonymousQuestions.Domain
{
    public class Question
    {
        public long Id { get; private set; }

        public string Title { get; private set; }

        public string Body { get; private set; }

        public DateTime Date { get; private set; }

        public Question(string title, string body, DateTime date)
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
    }
}
