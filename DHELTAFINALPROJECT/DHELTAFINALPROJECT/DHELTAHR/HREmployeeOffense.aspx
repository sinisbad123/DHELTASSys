<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HREmployeeOffense.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm12" EnableEventValidation="false" %>
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
                    <asp:GridView ID="gvEmployee" runat="server" 
                        CssClass="table table-hover table-striped" 
                        onrowdatabound="gvEmployee_RowDataBound" 
                        onselectedindexchanged="gvEmployee_SelectedIndexChanged">
                    </asp:GridView>

                    <hr />

                    <asp:Label ID="lblOffense" runat="server" Text="Offense Made by the Employee:"></asp:Label>
                    <asp:GridView ID="gvOffense" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
            <hr />
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
