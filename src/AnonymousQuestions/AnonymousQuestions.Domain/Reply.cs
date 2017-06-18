﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnonymousQuestions.Domain
{
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Author { get; set; }

        public string Body { get; set; }

        public DateTime Date { get;  set; }

        public Question Question { get; set; }

        public void AddReferenceQuestion(Question question)
        {
            Question = question;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }
    }
}
