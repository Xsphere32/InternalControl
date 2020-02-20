using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Models
{
    public class TypeOfForm : BaseModel
    {
        public virtual List<QuestionModel> Questions { get; set; }
    }
}
