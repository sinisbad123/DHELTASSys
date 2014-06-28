<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="DHELTAFINALPROJECT._404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .jumbotron {
            background-color: #F9690E;
        }
        .btn{
            background-color: #EB9532;
        }
        p {
            color: #EEEEEE;
        }

        h1 {
            color: #EEEEEE !important;
        }
    </style>
</head>
<body>
    

    <form id="form1" runat="server">
            <div class="jumbotron">
            <div class="container">
                <h1>Page Not Found</h1>
                <p>Perhaps you got lost? Don't worry, we'll fix that.</p>
                <asp:Button ID="btnHome" CssClass="btn btn-warning" Text="Back to Home" runat="server" OnClick="btnHome_Click" />
            </div>
    </div>
    </form>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/jquery-1.9.1.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
