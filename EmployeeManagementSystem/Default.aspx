<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
<form id="form1" runat="server">
<table align="left">
<tr>
<td>

    <asp:TextBox ID="SearchQuery" runat="server"></asp:TextBox></td>
<td>
    <asp:Button ID="SearchButton" runat="server" Text="Search" 
        onclick="SearchButton_Click" /></td>
</tr>
</table>
<table align="right">
<tr>
<td><b><a href="Default.aspx">Home</a></b></td>
<td>|</td>
<td><a href="AddNew.aspx">Add New Employee</a></td>
<td>|</td>
<td><a href="AddWork.aspx">Add Work Information</a></td>
</tr>
</table><br /><br />
    
    <div>
    <br />
        <asp:Label ID="Records" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
