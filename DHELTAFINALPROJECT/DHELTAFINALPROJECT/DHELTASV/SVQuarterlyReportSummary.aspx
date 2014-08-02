<%@ Page Language="C#" MasterPageFile="~/DHELTASV/Supervisor.Master"AutoEventWireup="true" CodeBehind="SVQuarterlyReportSummary.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.SVQuarterlyReportSummary"  EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="humanresource">
                <h1>Quarterly Report Summary</h1>
                <hr />
                <asp:GridView ID="gvReportStatus" runat="server" Caption="Report Status"
                    CssClass="table table-striped table-bordered table-condensed"
                    onselectedindexchanged="gvReportStatus_SelectedIndexChanged" 
                    onrowdatabound="gvReportStatus_RowDataBound" >
                </asp:GridView>
                <br />
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
        </div>
    </div>
</div>
</asp:Content>
