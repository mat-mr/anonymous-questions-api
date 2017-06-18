﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnonymousQuestions.Domain
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public virtual List<Reply> Replies { get; private set; }

        public Question()
        {
            Replies = new List<Reply>();
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void AddReply(Reply reply)
        {
            reply.AddReferenceQuestion(this);
            Replies.Add(reply);
        }
    }
}
