<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DHELTASSYSMEGABYTE.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DHELTASSYS</title>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="content">
            <div id="logo">
                <img src="images/finallogo.png" width="700" height="300" alt="DHELTASSYS" style="max-width:100%;"/>
            </div>

            <div class="mainContent">
                <asp:TextBox ID="txtEmployeeID" runat="server" placeholder="ID Number"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:Button ID="btnSignin" runat="server" Text="Sign In" 
                    onclick="btnSignin_Click" />
            </div>
         </div>
    </div>
    </form>
</body>
</html>
