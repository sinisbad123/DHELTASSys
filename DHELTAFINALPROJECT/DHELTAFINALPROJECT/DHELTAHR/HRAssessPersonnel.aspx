<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRAssessPersonnel.aspx.cs" Inherits="DHELTASSYSMEGABYTE.HRAssessPersonnel" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="humanresource">
                <h1>Personnel Assessment</h1>
                <hr />
                <asp:Label ID="lblNotification" runat="server"></asp:Label>
                    <%--<asp:GridView ID="gvCompanyEmployees" runat="server"
                    CssClass="table table-striped table-bordered table-condensed"
                    onselectedindexchanged="gvCompanyEmployees_SelectedIndexChanged" 
                    onrowdatabound="gvCompanyEmployees_RowDataBound" 
                    Caption="Company Personnel">
                </asp:GridView>--%>
         <%--       <p> Report Type: 
                    <asp:DropDownList ID="dpReportType" runat="server" Width="250px" 
                        AutoPostBack="True" onselectedindexchanged="dpReportType_SelectedIndexChanged" >
                        <asp:ListItem Selected="True" Text="All"></asp:ListItem>               
                        <asp:ListItem Text="Employee"></asp:ListItem>
                        <asp:ListItem Text="Supervisor"></asp:ListItem>
                    </asp:DropDownList>
                </p>--%>
                <asp:GridView ID="gvEvaluationStatusEmployee" runat="server"
                    CssClass="table table-striped table-bordered table-condensed" 
                    onselectedindexchanged="gvEvaluationStatusEmployee_SelectedIndexChanged" 
                    onrowdatabound="gvEvaluationStatusEmployee_RowDataBound" 
                    Caption="Employee Evaluation">
                </asp:GridView>
                <br />
                <asp:GridView ID="gvEvaluationStatus_Group" runat="server"
                    CssClass="table table-striped table-bordered table-condensed" 
                    onselectedindexchanged="gvEvaluationStatus_Group_SelectedIndexChanged" 
                    onrowdatabound="gvEvaluationStatus_Group_RowDataBound" 
                    Caption="Supervisor Evaluation">
                </asp:GridView>
                <hr />
                <br />
                <asp:GridView ID="gvEvaluationStatusSupervisor" runat="server" Caption="Supervisor Evaluation_Employees" 
                    CssClass="table table-striped table-bordered table-condensed" 
                    onrowdatabound="gvEvaluationStatusSupervisor_RowDataBound" 
                    onselectedindexchanged="gvEvaluationStatusSupervisor_SelectedIndexChanged">
                </asp:GridView>
                <br />
                <asp:GridView ID="gvEvaluationAnswers" runat="server"
                    CssClass="table table-striped table-bordered table-condensed" 
                    Caption="Evaluation Answers">
                </asp:GridView>
                <br />
                <div class="modal-footer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" onclick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>