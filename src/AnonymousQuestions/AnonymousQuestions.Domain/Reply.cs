using System;

namespace AnonymousQuestions.Domain
{
    public class Reply
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public Reply(long id, string author, string body, DateTime date)
            : this(author, body, date)
        {
            this.Id = id;
        }

        public Reply(string author, string body, DateTime date)
        {
            this.Author = author;
            this.Body = body;
            this.Date = date;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }
    }
}
