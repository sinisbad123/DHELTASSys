<%@ Page Language="C#" MasterPageFile="~/DHELTASV/Supervisor.Master" AutoEventWireup="true" CodeBehind="SVGenerateReport.aspx.cs" Inherits="DHELTASSys.GenerateReport" EnableEventValidation="false"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--
<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
            <li class="sidebarmenu">
                <asp:HyperLink ID="lnkAssess" runat="server" href="HRAssessPersonnel.aspx">Assess Personnel</asp:HyperLink>
            </li>
           <li class="sidebarmenu">
                <a data-toggle="modal" href="#filterModal">Add Evaluation Question</a>
            </li>
        </ul>
    </div>
</div>
-->

<div class="containerfluid">
    <div class="mainContainer">
        <div class="humanresource">
        <br />
            <h1>Generate Reports</h1>
            <hr />
            <asp:GridView ID="gvActiveEmployees" runat="server" Caption="Active Employees"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEmployeeLeave" runat="server" Caption="Employee Leave"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEmployeeOffense" runat="server" Caption="Employee Offense"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEmployeePresent" runat="server" Caption="Employee Present"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEmployeeAttendance" runat="server" Caption="Employee Attendance"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEmployeeEvaluation" runat="server" Caption="Employee Evaluation"
            CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            </div>
            <div class="modal-footer">
                    <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" class="btn btn-primary" onclick="btnGenerateReport_Click" />
                    <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
        </div>
    </div>
</div>
</asp:Content>

