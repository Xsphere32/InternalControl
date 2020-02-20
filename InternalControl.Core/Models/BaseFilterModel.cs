using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Models
{
    public class BaseFilterModel
    {
        public TypeOfForm TypeOfForm { get; set; }
        public GroupOfIndicatorsModel GroupOfIndicators { get; set; }
        public IndicatorsModel Indicators { get; set; }
    }
}
