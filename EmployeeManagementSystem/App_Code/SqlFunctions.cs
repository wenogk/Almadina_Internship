using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class SqlFunction
{
    //public string connectionString="Data Source=HAISAL-7\MSSQLSERVER2014;Initial Catalog=EMPLOYEES;User ID=sa;Password=sa@123@sa";
    public bool query(string query, string data1 = "", string data2 = "", string data3 = "", string data4 = "", string data5 = "", string data6 = "", string data7 = "", string data8 = "")
    {
        using (SqlConnection sqlCon = new SqlConnection(@"Data Source=HAISAL-7\MSSQLSERVER2014;Initial Catalog=EmployeeDatabase;User ID=sa;Password=sa@123@sa"))
        {
            using (SqlCommand command = new SqlCommand(query, sqlCon))
            {
                command.Parameters.AddWithValue("@data1", data1);
                command.Parameters.AddWithValue("@data2", data2);
                command.Parameters.AddWithValue("@data3", data3);
                command.Parameters.AddWithValue("@data4", data4);
                command.Parameters.AddWithValue("@data5", data5);
                command.Parameters.AddWithValue("@data6", data6);
                command.Parameters.AddWithValue("@data7", data7);
                command.Parameters.AddWithValue("@data8", data8);
                sqlCon.Open();
                command.ExecuteNonQuery();
                sqlCon.Close();
                return true;
            }
        }
    }

    public int countQuery(string query, string data1 = "", string data2 = "", string data3 = "", string data4 = "")
    {
        using (SqlConnection sqlCon = new SqlConnection(@"Data Source=HAISAL-7\MSSQLSERVER2014;Initial Catalog=EmployeeDatabase;User ID=sa;Password=sa@123@sa"))
        {
            using (SqlCommand command = new SqlCommand(query, sqlCon))
            {
                command.Parameters.AddWithValue("@data1", data1);
                command.Parameters.AddWithValue("@data2", data2);
                command.Parameters.AddWithValue("@data3", data3);
                command.Parameters.AddWithValue("@data4", data4);
                sqlCon.Open();
                int count = (int)command.ExecuteScalar();
                sqlCon.Close();
                return count;
            }
        }
    }

    public string getEmployeeInfo(string data1 = "",string data2 = "", string data3 = "", string data4 = "")
    {
        //
        using (SqlConnection sqlCon = new SqlConnection(@"Data Source=HAISAL-7\MSSQLSERVER2014;Initial Catalog=EmployeeDatabase;User ID=sa;Password=sa@123@sa"))
        {
            string query = "SELECT * FROM EMP_MASTER WHERE EMP_ID=@data1";
            using (SqlCommand command = new SqlCommand(query, sqlCon))
            {
                command.Parameters.AddWithValue("@data1", data1);
                command.Parameters.AddWithValue("@data2", data2);
                command.Parameters.AddWithValue("@data3", data3);
                command.Parameters.AddWithValue("@data4", data4);


                sqlCon.Open();
                SqlDataReader datareader = command.ExecuteReader();
                string returnInfo = "";
                while (datareader.Read())
                {
                    returnInfo = datareader[data2].ToString().Trim();
                }
                sqlCon.Close();
                return returnInfo;
            }
        }
    }

    public string hoursWorked(string EmployeeID, string dateValue, string topHeading = "Today's work sessions:", string bottomHeading = "Total Work Time Today: ")
    {

        using (SqlConnection sqlCon = new SqlConnection(@"Data Source=HAISAL-7\MSSQLSERVER2014;Initial Catalog=EMPLOYEES;User ID=sa;Password=sa@123@sa"))
        {
            string query = "SELECT * FROM TimeEntries WHERE Date=@data1 AND EmployeeID=@data2 AND Time_Out IS NOT NULL ORDER BY EntryID DESC";
            using (SqlCommand command = new SqlCommand(query, sqlCon))
            {
                command.Parameters.AddWithValue("@data1", dateValue);
                command.Parameters.AddWithValue("@data2", EmployeeID);
                sqlCon.Open();
                SqlDataReader datareader = command.ExecuteReader();

                string returnString = "<h2 align='center'>" + topHeading + "</h2>";
                TimeSpan totalTime = new TimeSpan(0, 0, 0, 0);
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        //DateTime timeOut = Convert.ToDateTime(datareader["Time_Out"]);
                        // DateTime timeIn = Convert.ToDateTime(datareader["Time_In"]);
                        TimeSpan t3 = new TimeSpan(0, 0, 0, 0);
                        TimeSpan t1 = (TimeSpan)datareader["Time_Out"];
                        TimeSpan t2 = (TimeSpan)datareader["Time_In"];
                        returnString += "<Table align='center' style='border: 1px solid black;'><Tr><td>";
                        returnString += "Time in: " + t2.ToString() + "</td></tr><tr><Td>";
                        returnString += "Time out: " + t1.ToString() + "</td></tr><tr><Td>";
                        t3 = t1.Subtract(t2);
                        totalTime = totalTime.Add(t3);
                        returnString += "Time Worked: " + t3.ToString() + "</td></tr></table><br/>";
                        //returnString += "-Total-" + totalTime.ToString() + "--<hr><br/>";

                    }
                }
                returnString = returnString.Insert(0, "<h2>" + bottomHeading + totalTime.ToString() + "</h2><hr><br/>");
                sqlCon.Close();
                return returnString;
            }
        }
    }
}
