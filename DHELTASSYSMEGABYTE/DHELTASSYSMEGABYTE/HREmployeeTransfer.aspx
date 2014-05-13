<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="HREmployeeTransfer.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="transfer">
                <h2>Available Employee(s) to Transfer</h2><br />

                <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl">
                </asp:DropDownList> 
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="search"
                    onclick="btnSearch_Click" /><br />
                    <hr />

                <asp:GridView ID="gvEmployee" runat="server" 
                    CssClass="table table-striped table-bordered table-condensed" Width=60% 
                    onselectedindexchanged="gvEmployee_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>

            <div class="requestForm">
            <p class="requestInfo">Employee ID:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Label ID="lblEmpID" runat="server" Text=""></asp:Label></p>
            <p class="requestInfo">Last Name: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp
                <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label></p>
            <p class="requestInfo">First Name:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp
                <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label></p>
            <p class="requestInfo">Middle Name:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                <asp:Label ID="lblMiddleName" runat="server" Text=""></asp:Label></p>
            <p class="requestInfo">Company Name:&nbsp&nbsp 
                <asp:Label ID="lblComName" runat="server" Text=""></asp:Label></p>
            <p class="requestInfo">Position:&nbsp&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
                <asp:Label ID="lblPos" runat="server" Text=""></asp:Label></p>
            <p class="requestInfo">Date of Transfer:&nbsp 
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox></p><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" 
                    onclick="btnSubmit_Click" />
            </div>
            <asp:Label ID="lblComID" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblYourCompanyID" runat="server" Text=""></asp:Label>
        </div>
    </div>
</div>


</asp:Content>
