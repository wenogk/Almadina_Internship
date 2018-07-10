using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string id= Request.QueryString["id"];
         if ((id != "") && (!Page.IsPostBack))
         {
             SqlFunction getData = new SqlFunction();
             string recordsHtml = "<h2 align='right'>" + DateTime.Now.ToShortDateString() + "</h2><br/><h1 align='center'>" + getData.getEmployeeInfo(id, "Name") + "'s Employee Report.</h1>";
             recordsHtml+="<table align='center' style='border: 1px solid black;'><tr><b>";
             recordsHtml += "<Td border: 1px solid black;><b>Name</b></td>";
             recordsHtml += "<Td><b>Nationality</b></td>";
             recordsHtml += "<Td><b>Date Of Birth</b></td>";
             recordsHtml += "<Td><b>Join Date</b></td>";
             recordsHtml += "<Td><b>Salary</b></td>";

             recordsHtml += "</b></tr>";

             using (SqlConnection con = new SqlConnection(@"Data Source=haisal-7\mssqlserver2014;Initial Catalog=EmployeeDatabase;User ID=sa;Password=sa@123@sa"))
             {
                 using (SqlCommand command = new SqlCommand("SELECT * FROM EMP_MASTER WHERE EMP_ID=@id", con))
                 {
                     command.Parameters.AddWithValue("@id",id );
                     con.Open();
                     SqlDataReader reader = command.ExecuteReader();

                     while (reader.Read())
                     {
                         if (!reader.IsDBNull(0))
                         {

                             recordsHtml += "<Tr>";
                             recordsHtml += "<Td><a href='Report.aspx?id=";
                             recordsHtml += reader["EMP_ID"].ToString();
                             recordsHtml += "'>" + reader["Name"].ToString() + "</a></Td>";

                             recordsHtml += "<Td>";
                             recordsHtml += reader["Nationality"].ToString();
                             recordsHtml += "</Td>";
                             recordsHtml += "<Td>";
                             recordsHtml += reader["DOB"].ToString();
                             recordsHtml += "</Td>";
                             recordsHtml += "<Td>";
                             recordsHtml += reader["Join_Date"].ToString();
                             recordsHtml += "</Td>";
                             recordsHtml += "<Td>";
                             recordsHtml += reader["Pay"].ToString();
                             recordsHtml += "</Td>";
               

                             recordsHtml += "</Tr>";
                         }
                         else
                         {
                             recordsHtml += "<Tr><td>No result</td></Tr>";
                         }
                     }

                     con.Close();
                 }
             }

             recordsHtml += "</table><br/><br/>";
             //THE OTHER DATA

             recordsHtml += "<table align='center' style='border: 1px solid black;'><tr><b>";
             recordsHtml += "<Td><b>EMP_ID</b></td>";
             recordsHtml += "<Td><b>Entry ID</b></td>";
             recordsHtml += "<Td><b>Time In</b></td>";
             recordsHtml += "<Td><b>Time Out</b></td>";
            
             recordsHtml += "</b></tr>";
             using (SqlConnection con = new SqlConnection(@"Data Source=haisal-7\mssqlserver2014;Initial Catalog=EmployeeDatabase;User ID=sa;Password=sa@123@sa"))
             {
                 using (SqlCommand command = new SqlCommand("SELECT * FROM EMP_WORK WHERE EMP_ID=@id", con))
                 {
                     command.Parameters.AddWithValue("@id", id);
                     con.Open();
                     SqlDataReader reader = command.ExecuteReader();

                     while (reader.Read())
                     {
                       

                             recordsHtml += "<Tr>";
                             recordsHtml += "<Td>";
                             recordsHtml += reader["EMP_ID"].ToString();
                             recordsHtml += "</Td>";

                             recordsHtml += "<Td>";
                             recordsHtml += reader["ENTRY_ID"].ToString();
                             recordsHtml += "</Td>";
                             recordsHtml += "<Td>";
                           
                             recordsHtml += reader["Time_In"].ToString();
                             recordsHtml += "</Td>";
                             recordsHtml += "<Td>";
                             recordsHtml += reader["Time_Out"].ToString();
                             recordsHtml += "</Td>";
                           


                             recordsHtml += "</Tr>";
                     }

                     con.Close();
                 }
             }

             recordsHtml += "</table>";



             ProfileResult.Text = recordsHtml;
         }


    }
}