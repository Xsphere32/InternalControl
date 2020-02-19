using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Models
{
    public class QuestionModel : BaseModel
    {
        public virtual GroupOfIndicatorsModel GroupOfIndicators { get; set; }

        public virtual IndicatorsModel Indicators { get; set; }

        public bool Answer { get; set; }

        public int TypeOfFormId { get; set; }

        public virtual TypeOfForm TypeOfForm { get; set; }
    }
}
