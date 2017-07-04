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

        public Reply(string author, string body)
        {
            this.Author = author;
            this.Body = body;
            this.Date = DateTime.Now;
        }

        public Reply(long id, string author, string body)
            : this(author, body)
        {
            this.Id = id;
        }
    }
}
