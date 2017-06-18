using AnonymousQuestions.Domain;

namespace AnonymousQuestions.Api.Models
{
    public class ReplyModel
    {
        public string Author { get; set; }
        public string Body { get; set; }

        internal Reply ToEntity()
        {
            return new Reply(Author, Body);
        }
    }
}
