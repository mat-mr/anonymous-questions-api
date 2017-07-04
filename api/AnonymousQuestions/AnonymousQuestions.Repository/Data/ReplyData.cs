using AnonymousQuestions.Domain;
using System.Collections.Generic;

namespace AnonymousQuestions.Repository.Data
{
    public static class ReplyData
    {
        private static List<Reply> replies;

        static ReplyData()
        {
            CreateReplies();
        }

        public static List<Reply> GetAll()
        {
            return replies;
        }

        private static Reply CreateReply(long id, string author, string body)
        {
            return new Reply(id, author, body);
        }

        private static void CreateReplies()
        {
            replies = new List<Reply>
            {
                CreateReply(1, "Bernardo", "Sim salabim."),
                CreateReply(2, "Nunes", "et cetera e tal.")
            };
        }
    }
}
