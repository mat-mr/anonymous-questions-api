using System;

namespace AnonymousQuestions.Domain
{
    public class Reply
    {
        public long Id { get; private set; }

        public string Author { get; private set; }

        public string Body { get; private set; }

        public DateTime Date { get; private set; }

        private Reply()
        {
        }

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
