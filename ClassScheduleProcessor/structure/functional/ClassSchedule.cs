using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassScheduleProcessor.structure.functional
{
    public class ClassSchedule : IDisposable
    {
        private bool _disposed = false;
        private string dataRecord = "";
        public String recordCode = "";
        public String institutionCode = "";
        public String subjectPrefix = "";
        public String courseNumber = "";
        public String sectionNumber = "";
        public String typeOfInstruction = "";
        public double creditHours = 0.0;
        public String locationCode = "";
        public String otherHigherEduSite = "";
        public String compositeClasses = "";
        public int tenure = 0;
        public String offCampusLocation = "";
        public String instructorCode = "";
        public String responsibilityFactor = "";
        public String enrollment = "";
        public int semester = 0;
        public String semesterYear = "";
        public String studentsExceedStateFundLimits = "";
        public String studentsNotStateFunded = "";
        public String lowerLevelAffectedByUG = "";
        public String upperLevelAffectedByUG = "";
        public int instructionMode = 0;
        public String interInstitutionalIdentifier = "";
        public String teachingLoadCredit = "";

        public ClassSchedule(string record)
        {
            this.dataRecord = record;

            // process data and store it other instance variables
            this.processDataRecord();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            this.Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            this._disposed = true;
        }

        private double getCreditHours(String creditHours)
        {
            return Convert.ToDouble(creditHours)/100;
        }

        private void processDataRecord()
        {
            this.recordCode = this.dataRecord.Substring(0, 1);
            this.institutionCode = this.dataRecord.Substring(1, 6).Trim();
            this.subjectPrefix = this.dataRecord.Substring(7, 7).Trim();
            this.courseNumber = this.dataRecord.Substring(14, 7).Trim();
            this.sectionNumber = this.dataRecord.Substring(21, 7).Trim();
            this.typeOfInstruction = this.dataRecord.Substring(28, 1);
            this.creditHours = this.getCreditHours(this.dataRecord.Substring(29, 4));
            this.locationCode = this.dataRecord.Substring(33, 1);
            this.otherHigherEduSite = this.dataRecord.Substring(34, 6).Trim();
            this.compositeClasses = this.dataRecord.Substring(41, 2).Trim();
            this.tenure = Convert.ToInt32(this.dataRecord.Substring(44, 1));
            this.offCampusLocation = this.dataRecord.Substring(45, 5).Trim();
            this.instructorCode = this.dataRecord.Substring(50, 9).Trim();
            this.responsibilityFactor = this.dataRecord.Substring(59, 3);
            this.enrollment = this.dataRecord.Substring(62, 15);
            this.semester = Convert.ToInt32(this.dataRecord.Substring(77, 1));
            this.semesterYear = this.dataRecord.Substring(78, 4);
            this.studentsExceedStateFundLimits = this.dataRecord.Substring(82, 3);
            this.studentsNotStateFunded = this.dataRecord.Substring(85, 3);
            this.lowerLevelAffectedByUG = this.dataRecord.Substring(88, 3);
            this.upperLevelAffectedByUG = this.dataRecord.Substring(91, 3);
            this.instructionMode = Convert.ToInt32(this.dataRecord.Substring(94, 1));
            this.interInstitutionalIdentifier = this.dataRecord.Substring(95, 1);
            this.teachingLoadCredit = this.dataRecord.Substring(96, 3);

        }
    }
}
