using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassScheduleProcessor.structure.constants
{
    public class Enrollment
    {
        public double ld;
        public double ud;
        public double master;
        public double doctorRS;
        public double doctorPP;

        public Enrollment(string enrollment)
        {
            this.ld = Convert.ToDouble(enrollment.Substring(0, 3));
            this.ud = Convert.ToDouble(enrollment.Substring(3, 3));
            this.master = Convert.ToDouble(enrollment.Substring(6, 3));
            this.doctorRS = Convert.ToDouble(enrollment.Substring(9, 3));
            this.doctorPP = Convert.ToDouble(enrollment.Substring(12, 3));
        }
    }
}
