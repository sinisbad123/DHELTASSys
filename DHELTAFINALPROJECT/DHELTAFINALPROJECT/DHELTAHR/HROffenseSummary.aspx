<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HROffenseSummary.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="offense">
                <div class="greetings">
                    <h4>Offense Summary</h4>
                </div>
                <hr />

                <div class="mainBody">
                    <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-hover table-striped">
                    </asp:GridView>

                    <hr />
                    <asp:Label ID="lblOffense" runat="server" Text="Offense Made by the Employee:"></asp:Label>
                    <asp:GridView ID="gvOffense" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>

                </div>

            </div>
        </div>
    </div>
</div>
</asp:Content>
