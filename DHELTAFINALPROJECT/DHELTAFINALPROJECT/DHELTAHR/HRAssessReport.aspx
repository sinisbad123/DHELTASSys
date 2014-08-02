<%@ Page Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRAssessReport.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.HRAssessReport"  EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="containerfluid">
    <div class="mainContainer">
        <div class="humanresource">
        <br />
            <h1>Consolidate Reports</h1>
            <hr />
            <asp:GridView ID="gvReportStatus" runat="server" Caption="Report Status"
            CssClass="table table-striped table-bordered table-condensed" 
                onselectedindexchanged="gvReportStatus_SelectedIndexChanged" 
                onrowdatabound="gvReportStatus_RowDataBound" >
            </asp:GridView>
            <br />
            <asp:GridView ID="gvActiveEmployees" runat="server" Caption="Employees under the supervision"
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
            <br>
            <div class="modal-footer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" onclick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
