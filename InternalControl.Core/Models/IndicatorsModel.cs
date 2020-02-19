using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Models
{
    public class IndicatorsModel : BaseModel
    {
        public virtual GroupOfIndicatorsModel GroupOfIndicators { get; set; }
    }
}
