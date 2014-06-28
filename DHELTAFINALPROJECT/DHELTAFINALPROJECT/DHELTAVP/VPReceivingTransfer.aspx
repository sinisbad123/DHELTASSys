<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAVP/VicePresident.Master" AutoEventWireup="true" CodeBehind="VPReceivingTransfer.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAVP.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="transfer">
                <div class="greetings">
                    <h4>Employee(s) Requested by Another Company:</h4>
                    <asp:Label ID="lblEmpRequest" runat="server" Text="No Employee Request"></asp:Label>
                </div>
                <hr />
                <div class="mainBody">
                    <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped table-bordered table-condensed">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chckbxTransfer" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <hr />

                    <asp:Label ID="lblTransferID" runat="server" Text=""></asp:Label>
                        <asp:DropDownList ID="dpApproval" runat="server" CssClass="ddl">
                        <asp:ListItem Selected="True">Approve</asp:ListItem>
                        <asp:ListItem>Deny</asp:ListItem>
                     </asp:DropDownList>
                 <asp:Label ID="lblCompanyIDRequesting" runat="server"></asp:Label>
                <hr />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" 
                        onclick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
