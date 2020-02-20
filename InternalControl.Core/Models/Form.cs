using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Models
{
    public class Form : BaseModel
    {
        public virtual TypeOfForm TypeOfForm { get; set; }
        public virtual ICollection<FormQuestion> FormQuestions { get; set; }
    }
}
