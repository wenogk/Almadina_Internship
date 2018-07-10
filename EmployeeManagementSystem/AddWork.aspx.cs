using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!Page.IsPostBack))
        {
            SqlFunction dropDownThing = new SqlFunction();
            using (SqlConnection con = new SqlConnection(@"Data Source=HAISAL-7\MSSQLSERVER2014;Initial Catalog=EmployeeDatabase;User ID=sa;Password=sa@123@sa"))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM EMP_MASTER", con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //DropDownList1.Items.Clear();
                    
                    while (reader.Read())
                    {
                        Employees.Items.Insert(0, new ListItem(reader["Name"].ToString(), reader["EMP_ID"].ToString()));
                    }
                    Employees.Items.Insert(0, new ListItem("Select an Employee", "X"));
                    con.Close();
                }
            }
        }
    }
   
    protected void DOB_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Join_Date_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void EmployeeListSelected(object sender, EventArgs e)
    {

    }
    protected void AddWorkButton_Click(object sender, EventArgs e)
    {
        DateTime date1 = DateTime.Parse(TimeIn.Text, System.Globalization.CultureInfo.CurrentCulture);

        //string t1 = date1.ToString("HH:mm:ss");
      //  DateTime date2 = DateTime.Parse(TimeOut.Text, System.Globalization.CultureInfo.CurrentCulture);

        //string t2 = date2.ToString("HH:mm:ss");
        //Result.Text = t1;
        SqlFunction addNew = new SqlFunction();

        if (addNew.query("INSERT INTO EMP_WORK (EMP_ID,Time_In,Time_Out,Date) VALUES (@data1,@data2,@data3,@data4)", Employees.SelectedValue, Date.SelectedDate.ToString("dd-MM-yyyy") + " " + TimeIn.Text + ":00.0000000", Date.SelectedDate.ToString("dd-MM-yyyy") + " " + TimeOut.Text + ":00.0000000", Date.SelectedDate.ToString("dd-MM-yyyy")))
        {
            Result.Text = "Success";
        }
    }
}