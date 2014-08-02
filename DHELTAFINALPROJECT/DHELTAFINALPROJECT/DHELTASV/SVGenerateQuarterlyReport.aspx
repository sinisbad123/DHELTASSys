<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTASV/Supervisor.Master" AutoEventWireup="true" CodeBehind="SVGenerateQuarterlyReport.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTASV.SVGenerateQuarterlyReport" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="humanresource">
            <h1>Generate Quarterly Report</h1>
            <hr />
            <p> Report Type: 
                <asp:DropDownList ID="dpReportType" runat="server" Width="250px" 
                    AutoPostBack="True" onselectedindexchanged="dpReportType_SelectedIndexChanged" >
                <asp:ListItem Selected="True" Text="Attendance and Evaluation"></asp:ListItem>               
                <asp:ListItem Text="Attendance"></asp:ListItem>
                <asp:ListItem Text="Evaluation"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <asp:GridView ID="gvActiveEmployees" runat="server" Caption="Active Employees"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEmployeeEvaluation" runat="server" Caption="Employee Evaluation"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEmployeeAttendance" runat="server" Caption="Employee Attendance"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnGenerateAttendanceReport" runat="server" Text="Generate Report" class="btn btn-primary" onclick="btnGenerateReport_Click" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
