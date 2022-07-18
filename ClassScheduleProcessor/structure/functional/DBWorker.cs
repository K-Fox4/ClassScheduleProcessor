using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using ClassScheduleProcessor.structure.constants;
using ClassScheduleProcessor.CS_DBDataSetTableAdapters;

namespace ClassScheduleProcessor.structure.functional
{
    // This class does all the interaction with the DB
    // for all custom sql queries
    public static class DBWorker
    {
        public static List<string> getUniqueColumnData(string columnName, string tableName)
        {
            List<string> result = new List<string>();

            using (OleDbConnection sqlConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CS_DB.accdb"))
            {
                // Give the command with the select statement
                string selectStatement = String.Format("SELECT DISTINCT {0} FROM {1}", columnName, tableName);
                OleDbCommand cmd = new OleDbCommand(selectStatement);

                // Set the Connection to the new OleDbConnection.
                cmd.Connection = sqlConnection;

                // Open the connection and execute the sql command.
                try
                {
                    sqlConnection.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                    }
                    // always call Close when done reading.
                    reader.Close();

                    return result;
                }
                catch (Exception ex)
                {
                    // Do Nothing
                    result = new List<string>();
                    return result;
                }
            }
        }

        public static List<CS_DBDataSet.Class_Schedules_RecordsRow> fetchCSRecords(string tableName, Option year, Option semester, Option major, Option course)
        {
            CS_DBDataSet dataSet = new CS_DBDataSet();
            List<CS_DBDataSet.Class_Schedules_RecordsRow> result = new List<CS_DBDataSet.Class_Schedules_RecordsRow>();

            // Base SQL query
            string sqlQuery = String.Format("SELECT * FROM {0}", tableName);

            // Add WHERE to SQL if any of the filters is selected
            if (year.isSelected | semester.isSelected | major.isSelected | course.isSelected)
            {
                sqlQuery += " WHERE";
            }

            // Check if year is selected
            if (year.isSelected)
            {
                sqlQuery += " Semester_Year = @Semester_Year";
            }

            // Check if semester is selected
            if (semester.isSelected)
            {
                if (year.isSelected)
                {
                    sqlQuery += " AND";
                }

                sqlQuery += " Semester = @Semester";
            }

            // Check if major is selected
            if (major.isSelected)
            {
                if (year.isSelected | semester.isSelected)
                {
                    sqlQuery += " AND";
                }

                sqlQuery += " Subject_prefix = @Subject_prefix";
            }

            // Check if course is selected
            if (course.isSelected)
            {
                if (year.isSelected | semester.isSelected | major.isSelected)
                {
                    sqlQuery += " AND";
                }

                sqlQuery += " Course_number = @Course_number";
            }

            using (OleDbConnection sqlConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CS_DB.accdb"))
            {
                // Give the command with the select statement
                OleDbCommand cmd = new OleDbCommand(sqlQuery);

                // Add parameters
                if (year.isSelected)
                {
                    cmd.Parameters.AddWithValue("@Semester_Year", year.value);
                }

                if (semester.isSelected)
                {
                    cmd.Parameters.AddWithValue("@Semester", semester.value);
                }

                if (major.isSelected)
                {
                    cmd.Parameters.AddWithValue("@Subject_prefix", major.value);
                }

                if (course.isSelected)
                {
                    cmd.Parameters.AddWithValue("@Course_number", course.value);
                }

                // Set the Connection to the new OleDbConnection.
                cmd.Connection = sqlConnection;

                // Open the connection and execute the sql command.
                try
                {
                    sqlConnection.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create DB row
                        CS_DBDataSet.Class_Schedules_RecordsRow newDataRow;
                        newDataRow = dataSet.Class_Schedules_Records.NewClass_Schedules_RecordsRow();
                        newDataRow.Record_Code = (string)reader[1];
                        newDataRow.Institution_code = (string)reader[2];
                        newDataRow.Subject_prefix = (string)reader[3];
                        newDataRow.Course_number = (string)reader[4];
                        newDataRow.Section_number = (string)reader[5];
                        newDataRow.Type_of_Instruction = (string)reader[6];
                        newDataRow.Credit_Hours = (double)reader[7];
                        newDataRow.Location_code = (string)reader[8];
                        newDataRow.Other_Higher_Education_Site = (string)reader[9];
                        newDataRow.Composite_classes = (string)reader[10];
                        newDataRow.Tenure = (string)reader[11];
                        newDataRow.Off_campus_location = (string)reader[12];
                        newDataRow.Instructor_code = (string)reader[13];
                        newDataRow.Responsibility_factor = (string)reader[14];
                        newDataRow.Enrollment = (string)reader[15];
                        newDataRow.Semester = (string)reader[16];
                        newDataRow.Semester_Year = (string)reader[17];
                        newDataRow.Students_Exceeding_State_Funding_Limits = (string)reader[18];
                        newDataRow.Students_Not_State_Funded = (string)reader[19];
                        newDataRow.Lower_Level_Affected_by_UG = (string)reader[20];
                        newDataRow.Upper_Level_Affected_by_UG = (string)reader[21];
                        newDataRow.Instruction_mode = (string)reader[22];
                        newDataRow.Inter_Institutional_Identifier = (string)reader[23];
                        newDataRow.Teaching_Load_Credit = (string)reader[24];

                        result.Add(newDataRow);
                    }
                    // always call Close when done reading.
                    reader.Close();

                    return result;
                }
                catch (Exception ex)
                {
                    // Do Nothing
                    result = new List<CS_DBDataSet.Class_Schedules_RecordsRow>();
                    return result;
                }
            }

        }
    }
}
