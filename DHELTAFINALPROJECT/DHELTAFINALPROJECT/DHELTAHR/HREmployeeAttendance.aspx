<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HREmployeeAttendance.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.HREmployeeAttendance" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="attendance">
                <div class="greetings">
                    <h4>Employee Attendance</h4>
                </div>
                <hr />
                <div class="mainBody">
                    <div class="greetings">
                        <asp:GridView ID="grdviewAllSummary" runat="server" 
                            CssClass="table table-hover table-striped" 
                            onrowdatabound="grdviewAllSummary_RowDataBound" 
                            onselectedindexchanged="grdviewAllSummary_SelectedIndexChanged">
                        </asp:GridView>
                         <asp:Label ID="lblAttendance" runat="server" Text="Employee Attendance Summary"></asp:Label>
                        <hr />
                        <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                        <asp:GridView ID="grdViewSummary" runat="server" CssClass="table table-striped table-bordered table-condensed">
                        </asp:GridView>
                </div>

            </div>
        </div>
    </div>
</div>
</asp:Content>
