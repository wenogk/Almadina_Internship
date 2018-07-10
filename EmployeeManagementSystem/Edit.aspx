<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<table align="right">
<tr>
<td><a href="Default.aspx">Home</a></td>
<td>|</td>
<td><a href="AddNew.aspx">Add New Employee</a></td>
<td>|</td>
<td><a href="AddWork.aspx">Add Work Information</a></td>
</tr>
</table><br />
    <form id="form1" runat="server">
    <div>
    
    </div>
    <br /><br />
    <table style="border: 1px solid black;">
    <tbody><tr><td border:="" 1px="" solid="" black;=""><b>Name</b></td>
    <td><b>Nationality</b></td>
    <td><b>Date Of Birth</b></td>
    <td><b>Join Date</b></td>
    <td><b>Salary</b></td><td></td></tr>
    <tr><td><asp:TextBox ID="FullName" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Only characters allowed" ControlToValidate="FullName" ValidationExpression="^[A-Za-z ]*$" ></asp:RegularExpressionValidator>
    </td>
    <td> <asp:TextBox ID="Nationality" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Only characters allowed" ControlToValidate="Nationality" ValidationExpression="^[A-Za-z ]*$" ></asp:RegularExpressionValidator>
    </td>
    <td>
        <asp:Calendar ID="DOB" runat="server" onselectionchanged="DOB_SelectionChanged"></asp:Calendar>
    </td>
    <td><asp:Calendar ID="Join_Date" runat="server"></asp:Calendar></td>
    <td><asp:TextBox ID="Salary" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
    ControlToValidate="Salary" runat="server"
    ErrorMessage="Only Numbers allowed"
    ValidationExpression="\d+">
</asp:RegularExpressionValidator>
    </td>
    <td>
        <asp:Button ID="EditButton" runat="server" Text="Edit" 
            onclick="EditButton_Click" /></td></tr></tbody></table>
    <asp:Label ID="Info" runat="server" Text="Info"></asp:Label>
    </form>

</body>
</html>
