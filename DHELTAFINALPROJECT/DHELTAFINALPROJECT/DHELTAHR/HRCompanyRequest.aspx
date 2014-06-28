<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRCompanyRequest.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm7" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="transfer">
                <div class="heading">
                    <h4>Employee(s) Available for Transfer: 
                        <asp:DropDownList ID="dpPosition" runat="server" class="ddl" 
                            AutoPostBack="True" onselectedindexchanged="dpPosition_SelectedIndexChanged">
                        </asp:DropDownList>
                    </h4>
                </div>
                <hr />
                <div class="mainBody">
                    <asp:GridView ID="gvEmployee" runat="server" Width="60%" 
                        CssClass="table table-striped table-bordered table-condensed" 
                        onrowdatabound="gvEmployee_RowDataBound" 
                        onselectedindexchanged="gvEmployee_SelectedIndexChanged">
                    </asp:GridView>

                    <div class="transferEmp">
                        <h4>Employee Request for Transfer:</h4>
                        <div class="transferInfo">
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
                                onclick="btnSubmit_Click"/>
                        </div>
                    </div>
                    <asp:Label ID="lblComID" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblYourCompanyID" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
