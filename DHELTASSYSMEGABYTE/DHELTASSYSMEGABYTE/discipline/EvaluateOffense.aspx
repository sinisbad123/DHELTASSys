<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluateOffense.aspx.cs" Inherits="DHELTASSys.EvaluateOffense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 132px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Offense ID: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOffenseID" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Employee Filed: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmpFiled" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Supervisor Filing:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Offense Type: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOffenseType" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Proof Image:"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Offense Information: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOffenseInfo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="imgProof" runat="server" />
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Offense Category: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOffenseCategory" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Date Commited: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOffenseDate" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label8" runat="server" Text="Supervisor Statement: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSupervisorStatement" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:DropDownList ID="drpDecision" runat="server">
                        <asp:ListItem>Approve</asp:ListItem>
                        <asp:ListItem>Disapprove</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnEvaluate" runat="server" OnClick="btnEvaluate_Click" Text="Evaluate" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
