<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DHELTAFINALPROJECT.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="content">
            <div class="dheltalogo">
                <img src="images/finallogo.png" width="700" height="300" />
            </div>

            <div class="mainContent">
                <asp:TextBox ID="txtEmployeeID" runat="server" placeholder="Employee ID Number"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>

                <div class="btnSignin">
                    <asp:Button ID="btnSignin" runat="server" Text="Sign In" class="btnlogin" 
                        onclick="btnSignin_Click" />
                </div>

            </div>

        </div>
    </div>
    </form>
</body>
</html>
