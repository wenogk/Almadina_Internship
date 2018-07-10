using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id= Request.QueryString["id"];
        if ((id != "") && (!Page.IsPostBack))
        {
            SqlFunction fillBoxes = new SqlFunction();
            FullName.Text = fillBoxes.getEmployeeInfo(id, "Name");
            Nationality.Text = fillBoxes.getEmployeeInfo(id, "Nationality");
            Salary.Text = fillBoxes.getEmployeeInfo(id, "Pay");
            DOB.SelectedDate = DateTime.Parse(fillBoxes.getEmployeeInfo(id, "DOB"));
            DOB.VisibleDate = DateTime.Parse(fillBoxes.getEmployeeInfo(id, "DOB"));
            Join_Date.SelectedDate = DateTime.Parse(fillBoxes.getEmployeeInfo(id, "Join_Date"));
            Join_Date.VisibleDate = DateTime.Parse(fillBoxes.getEmployeeInfo(id, "Join_Date"));
            //Info.Text = fillBoxes.getEmployeeInfo(id, "DOB");
        }
    }
    protected void DOB_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void EditButton_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        SqlFunction updateQuery = new SqlFunction();
        if (updateQuery.query("UPDATE EMP_MASTER SET Name=@data1,Nationality=@data2,Pay=@data3,DOB=@data4,Join_Date=@data5 WHERE EMP_ID=@data6", FullName.Text, Nationality.Text, Salary.Text, DOB.SelectedDate.ToString("dd-MM-yyyy"), Join_Date.SelectedDate.ToString("dd-MM-yyyy"), id)) {
            Response.Redirect("Default.aspx");
        }
    }
}