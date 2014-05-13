<%@ Page Title="" Language="C#" MasterPageFile="~/VP.Master" AutoEventWireup="true" CodeBehind="VPReceivingTransfer.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="transfer">
             <h2>Employees Requested by Another Company:</h2><br />
              <asp:Label ID="lblEmpRequest" runat="server" Text="No Employee Request"></asp:Label>
              <asp:GridView ID="gvEmployee" CssClass="table table-striped table-bordered table-condensed" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chckbxTransfer" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />

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

</asp:Content>
