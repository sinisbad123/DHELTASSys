<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDependent.aspx.cs" Inherits="DHELTAFINALPROJECT.AddDependent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Dependent</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/general.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 877px;
        }
        .style2
        {
            width: 438px;
        }
        .style3
        {
            width: 439px;
        }
        .style4
        {
            width: 438px;
            height: 16px;
        }
        .style5
        {
            width: 439px;
            height: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar navbar-inverse navbar-static-top" role="navigation">
            <div class="container-fluid">
                <a class="navbar-brand">DHELTASSYS</a>
                
                <button class="navbar-toggle" data-toggle="collapse" data-target="#navHeaderCollapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                </button>

                <div class="collapse navbar-collapse" id="navHeaderCollapse"> 
                </div>
            </div>
        </div>


       <div class="container">
            <div class="content">
                <div class="mainContent">
                    <div class="dependent">
                        <div class="greetings">
                            <h4>Add Dependent</h4>
                        </div>
                        <hr />
                        <div class="mainBody">
                            <table class="style1">
                                <tr>
                                    <td align="right" class="style2">
                                        Name:&nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style2">
                                        Contact Number:&nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                        <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style2">
                                        Relation:&nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                        <asp:DropDownList ID="dpRelationship" runat="server" class="ddl">
                                            <asp:ListItem>Spouse</asp:ListItem>
                                            <asp:ListItem>Child</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style4">
                                    </td>
                                    <td class="style5">
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnAdd" runat="server" Text="Add Dependent" 
                                            class="btn btn-primary" Width=35% onclick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </div>
                </div>
            </div>
       </div>

        <div id="footer">
            <p class="text-muted">(c) DHELTASSYS 2014</p>
        </div>

    </form>
    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
</body>
</html>
