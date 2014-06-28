<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HREmployeeOffense.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="offense">
                <div class="greetings">
                    <h4>Employee's Offense</h4>
                </div>

                <hr />

                <div class="mainBody">
            <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    Offense ID:</td>
                <td>
                    <asp:Label ID="lblOffenseID" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Employee Name:</td>
                <td>
                    <asp:Label ID="lblEmpFiled" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Filed Offense:</td>
                <td>
                    <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
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
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Offense Category: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOffenseCategory" runat="server"></asp:Label>
                </td>
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
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label8" runat="server" Text="Supervisor Statement: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSupervisorStatement" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:DropDownList ID="drpDecision" runat="server" class="ddl">
                        <asp:ListItem>Approve</asp:ListItem>
                        <asp:ListItem>Disapprove</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnEvaluate" runat="server" Text="Evaluate" 
                        class="btn btn-primary" onclick="btnEvaluate_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnBack" runat="server" Text="Back"  class="btn btn-default" 
                        onclick="btnBack_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
