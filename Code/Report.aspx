<%@ page language="C#" autoeventwireup="true" inherits="Report, App_Web_bjqzw2ce" %>

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
<body onload="window.print()">
<br />
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="ProfileResult" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
