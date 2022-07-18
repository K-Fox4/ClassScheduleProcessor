using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassScheduleProcessor;
using ClassScheduleProcessor.CS_DBDataSetTableAdapters;

namespace ClassScheduleProcessor.structure.functional
{
    public class FileProcessor
    {
        private Dictionary<int, string> semesters;
        private Dictionary<int, string> tenures;
        private Dictionary<int, string> instructionModes;
        private Dictionary<string, string> typeOfInstructions;
        private Dictionary<string, string> locationCodes;

        private CS_DBDataSet dataSet;
        private Class_Schedules_RecordsTableAdapter cSRTableAdapter;

        public FileProcessor()
        {
            // Initialize instance variables
            this.dataSet = new CS_DBDataSet();
            this.cSRTableAdapter = new Class_Schedules_RecordsTableAdapter();

            this.semesters = this.fetchSemesterDataRecords();
            this.tenures = this.fetchTenureDataRecords();
            this.instructionModes = this.fetchInstructionModeDataRecords();
            this.typeOfInstructions = this.fetchTypeOfInstructionDataRecords();
            this.locationCodes = this.fetchLocationCodeDataRecords();
        }

        private Dictionary<int, string> fetchSemesterDataRecords()
        {
            Dictionary<int, string> dataRecords = new Dictionary<int, string>();

            using (SemesterTableAdapter semesterTableAdapter = new SemesterTableAdapter())
            {
                CS_DBDataSet.SemesterDataTable semesterRows = semesterTableAdapter.GetData();
                foreach (CS_DBDataSet.SemesterRow row in semesterRows.Rows)
                {
                    dataRecords[row.ID] = row.Semester_Name;
                }
            }

            return dataRecords;
        }

        private Dictionary<int, string> fetchTenureDataRecords()
        {
            Dictionary<int, string> dataRecords = new Dictionary<int, string>();

            using (TenureTableAdapter tenureTableAdapter = new TenureTableAdapter())
            {
                CS_DBDataSet.TenureDataTable tenureRows = tenureTableAdapter.GetData();
                foreach (CS_DBDataSet.TenureRow row in tenureRows.Rows)
                {
                    dataRecords[row.Tenure_Value] = row.Tenure_Description;
                }
            }

            return dataRecords;
        }

        private Dictionary<int, string> fetchInstructionModeDataRecords()
        {
            Dictionary<int, string> dataRecords = new Dictionary<int, string>();

            using (Instruction_ModeTableAdapter instructionModeTableAdapter = new Instruction_ModeTableAdapter())
            {
                CS_DBDataSet.Instruction_ModeDataTable instructionModeRows = instructionModeTableAdapter.GetData();
                foreach (CS_DBDataSet.Instruction_ModeRow row in instructionModeRows.Rows)
                {
                    dataRecords[row.Mode_Value] = row.Mode_Description;
                }
            }

            return dataRecords;
        }

        private Dictionary<string, string> fetchTypeOfInstructionDataRecords()
        {
            Dictionary<string, string> dataRecords = new Dictionary<string, string>();

            using (Type_of_InstructionTableAdapter typeOfInstTableAdapter = new Type_of_InstructionTableAdapter())
            {
                CS_DBDataSet.Type_of_InstructionDataTable typeOfInstRows = typeOfInstTableAdapter.GetData();
                foreach (CS_DBDataSet.Type_of_InstructionRow row in typeOfInstRows.Rows)
                {
                    dataRecords[row.Instruction_Value] = row.Instruction_Description;
                }
            }

            return dataRecords;
        }

        private Dictionary<string, string> fetchLocationCodeDataRecords()
        {
            Dictionary<string, string> dataRecords = new Dictionary<string, string>();

            using (Location_CodeTableAdapter locationCodeTableAdapter = new Location_CodeTableAdapter())
            {
                CS_DBDataSet.Location_CodeDataTable locationCodeRows = locationCodeTableAdapter.GetData();
                foreach (CS_DBDataSet.Location_CodeRow row in locationCodeRows.Rows)
                {
                    dataRecords[row.Location_Code_Value] = row.Location_Code_Description;
                }
            }

            return dataRecords;
        }

        public void processAndUploadRecord(string record)
        {
            // Create Class Schedule object for easy access of data
            ClassSchedule classSchedule = new ClassSchedule(record);

            // Create new Class_Schedules_Records table data row
            CS_DBDataSet.Class_Schedules_RecordsRow newDataRow;
            newDataRow = this.dataSet.Class_Schedules_Records.NewClass_Schedules_RecordsRow();
            newDataRow.Record_Code = classSchedule.recordCode;
            newDataRow.Institution_code = classSchedule.institutionCode;
            newDataRow.Subject_prefix = classSchedule.subjectPrefix;
            newDataRow.Course_number = classSchedule.courseNumber;
            newDataRow.Section_number = classSchedule.sectionNumber;
            newDataRow.Type_of_Instruction = typeOfInstructions[classSchedule.typeOfInstruction];
            newDataRow.Credit_Hours = classSchedule.creditHours;
            newDataRow.Location_code = locationCodes[classSchedule.locationCode];
            newDataRow.Other_Higher_Education_Site = classSchedule.otherHigherEduSite;
            newDataRow.Composite_classes = classSchedule.compositeClasses;
            newDataRow.Tenure = tenures[classSchedule.tenure];
            newDataRow.Off_campus_location = classSchedule.offCampusLocation;
            newDataRow.Instructor_code = classSchedule.instructorCode;
            newDataRow.Responsibility_factor = classSchedule.responsibilityFactor;
            newDataRow.Enrollment = classSchedule.enrollment;
            newDataRow.Semester = semesters[classSchedule.semester];
            newDataRow.Semester_Year = classSchedule.semesterYear;
            newDataRow.Students_Exceeding_State_Funding_Limits = classSchedule.studentsExceedStateFundLimits;
            newDataRow.Students_Not_State_Funded = classSchedule.studentsNotStateFunded;
            newDataRow.Lower_Level_Affected_by_UG = classSchedule.lowerLevelAffectedByUG;
            newDataRow.Upper_Level_Affected_by_UG = classSchedule.upperLevelAffectedByUG;
            newDataRow.Instruction_mode = instructionModes[classSchedule.instructionMode];
            newDataRow.Inter_Institutional_Identifier = classSchedule.interInstitutionalIdentifier;
            newDataRow.Teaching_Load_Credit = classSchedule.teachingLoadCredit;

            // Add the row to the Class_Schedules_Records table
            this.dataSet.Class_Schedules_Records.Rows.Add(newDataRow);

            // Save the new row to the database
            this.cSRTableAdapter.Update(this.dataSet.Class_Schedules_Records);
        }
    }
}
