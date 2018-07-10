<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWork.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    
   table {
    border-collapse: collapse;
}

table, th, td {
    border: 1px solid black;
    padding:5px;
}

    </style>
</head>
<body>
<table align="right">
<tr>
<td><a href="Default.aspx">Home</a></td>
<td>|</td>
<td><a href="AddNew.aspx">Add New Employee</a></td>
<td>|</td>
<td><b><a href="AddWork.aspx">Add Work Information</a></b></td>
</tr>
</table>
<br /><br />
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>Name</td>
    <td>Time In (24  Hour Format)</td>
    <td>Time Out (24  Hour Format)</td>
    <td>Date</td>
    <td></td>
    </tr>
    <tr><td>
      <asp:DropDownList ID="Employees" runat="server" 
            OnSelectedIndexChanged="EmployeeListSelected">
        </asp:DropDownList>
        </td>
        <td>
            <asp:TextBox ID="TimeIn" runat="server"></asp:TextBox><br />
             <asp:RegularExpressionValidator ID="rev"
    runat="server" ErrorMessage="Invalid Time" ControlToValidate="TimeIn"
     ValidationExpression="^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$">
    </asp:RegularExpressionValidator>
        </td>
        <td>
         <asp:TextBox ID="TimeOut" runat="server"></asp:TextBox><br />
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
    runat="server" ErrorMessage="Invalid Time" ControlToValidate="TimeOut"
     ValidationExpression="^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$">
    </asp:RegularExpressionValidator>
        </td>
        <td>
            <asp:Calendar ID="Date" runat="server"></asp:Calendar>
        </td>
        <td><asp:Button ID="AddWorkButton" runat="server" Text="Add Work Session" 
                onclick="AddWorkButton_Click" /></td>
        
        </tr>
    </table>
    </div>
     <br />
    <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </form>
   
</body>
</html>
