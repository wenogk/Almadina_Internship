using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void EditButton_Click(object sender, EventArgs e)
    {
        SqlFunction addNew = new SqlFunction();
        if (addNew.query("INSERT INTO EMP_MASTER (Name,Nationality,Pay,DOB,Join_Date) VALUES (@data1,@data2,@data3,@data4,@data5)", FullName.Text, Nationality.Text, Salary.Text, DOB.SelectedDate.ToString("dd-MM-yyyy"), Join_Date.SelectedDate.ToString("dd-MM-yyyy")))
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void DOB_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Join_Date_SelectionChanged(object sender, EventArgs e)
    {

    }
}