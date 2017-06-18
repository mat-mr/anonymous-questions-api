﻿using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository.Context;
using System;

namespace AnonymousQuestions.Repository
{
    public static class TestData
    {
        public static void CreateData(ApiContext context)
        {
            var question1 = new Question("Como fazer uma API?", "Gostaria de saber como fazer uma API restful.", DateTime.Now);
            var question2 = new Question("Fortran 90", "Como se usa essa linguagem tão moderna?", DateTime.Now.AddDays(15));

            var reply1 = new Reply("Bernardo", "Vou ensinar amanhã na aula.", DateTime.Now.AddHours(3));
            var reply2 = new Reply("Nunes", "et cetera e tal.", DateTime.Now.AddHours(4));

            context.Replies.Add(reply1);
            context.Questions.Add(question1);
            context.Questions.Add(question2);

            context.Questions.Find(question1.Id).AddReply(reply1);
            context.Questions.Find(question1.Id).AddReply(reply2);

            context.SaveChanges();
        }
    }
}
