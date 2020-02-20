using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Models
{
    public class FormQuestion
    {
        public int FormId { get; set; }
        public virtual Form Form { get; set; }
        public int QuestionId { get; set; }
        public virtual QuestionModel Question { get; set; }
        public virtual AnswersModel Answers { get; set; }
        public int Order { get; set; }
    }
}
