using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Models
{
    public class QuestionModel : BaseModel
    {
        public virtual TypeOfForm TypeOfForm { get; set; }
     
        public virtual GroupOfIndicatorsModel GroupOfIndicators { get; set; }

        public virtual IndicatorsModel Indicators { get; set; }

        public virtual AnswersModel Answer { get; set; }

        public int TypeOfFormId { get; set; }

        public virtual ICollection<FormQuestion> FormQuestions { get; set; }
    }
}
