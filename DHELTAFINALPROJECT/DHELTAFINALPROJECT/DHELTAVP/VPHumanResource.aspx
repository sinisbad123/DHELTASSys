<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAVP/VicePresident.Master" AutoEventWireup="true" CodeBehind="VPHumanResource.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAVP.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="greetings">
                <h4> Your Collegues </h4>
            </div>
            <hr />
            <div class="mainBody">
                <asp:GridView ID="gvEmployees" runat="server" CssClass="table table-striped table-bordered table-condensed">
                </asp:GridView>
            </div>
        </div>
    </div>
</div>

</asp:Content>
