<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileOffense.aspx.cs" Inherits="DHELTASSys.FileOffense" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 492px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 492px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdEmployeeList" runat="server" OnRowDataBound="grdEmployeeList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:GridView ID="grdOffenseType" runat="server">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDisplayEmpOffenses" runat="server" OnClick="btnDisplayEmpOffenses_Click" Text="Display Employee Offenses" />
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Offense Type: "></asp:Label>
                    <br />
                    <asp:DropDownList ID="drpdownOffenseType" runat="server">
                        <asp:ListItem>Minor</asp:ListItem>
                        <asp:ListItem>Major</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Select Offense Category"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnFileOffense" runat="server" OnClick="btnFileOffense_Click" Text="File an Offense" />
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Offense Info (Short description of the offense)"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpdownOffenseCategory" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtOffenseInfo" runat="server" Height="69px" Width="184px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Add Offense Category: "></asp:Label>
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAddOffenseType" runat="server" OnClick="btnAddOffenseType_Click" Text="Add Offense Type" />
                </td>
                <td>
                    <asp:Button ID="btnAddCategoryName" runat="server" OnClick="btnAddCategoryName_Click" Text="Add Category Name" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
