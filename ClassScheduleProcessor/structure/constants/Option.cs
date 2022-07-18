using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassScheduleProcessor.structure.constants
{
    public class Option
    {
        public string value;
        public bool isSelected;

        public Option(string value, bool isSelected = false)
        {
            this.value = value;
            this.isSelected = isSelected;
        }
    }
}
