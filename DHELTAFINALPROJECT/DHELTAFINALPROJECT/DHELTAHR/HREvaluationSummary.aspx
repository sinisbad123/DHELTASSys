<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HREvaluationSummary.aspx.cs" Inherits="DHELTASSYSMEGABYTE.HREvaluationSummary" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="humanresource">
                <h1>Evaluation Summary</h1>
                <hr />
                <asp:Label ID="lblNotification" runat="server"></asp:Label>
                <asp:GridView ID="gvCompanyEmployees" runat="server"
                    CssClass="table table-striped table-bordered table-condensed"
                    onselectedindexchanged="gvCompanyEmployees_SelectedIndexChanged" 
                    onrowdatabound="gvCompanyEmployees_RowDataBound" 
                    Caption="Company Personnel">
                </asp:GridView>
                    <br />
                <asp:GridView ID="gvEvaluationStatus_Group" runat="server"
                    CssClass="table table-striped table-bordered table-condensed"
                    onrowdatabound="gvEvaluationStatus_Group_RowDataBound" 
                    onselectedindexchanged="gvEvaluationStatus_Group_SelectedIndexChanged">
                </asp:GridView>
                    <br />
                <asp:GridView ID="gvEmployeeEvaluationStatus" runat="server" Caption="Evaluation Status" 
                    CssClass="table table-striped table-bordered table-condensed"
                    onrowdatabound="gvEmployeeEvaluationStatus_RowDataBound" 
                    onselectedindexchanged="gvEmployeeEvaluationStatus_SelectedIndexChanged">
                </asp:GridView>
                    <br />
                <asp:GridView ID="gvEvaluationAnswers" runat="server"
                    CssClass="table table-striped table-bordered table-condensed">
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
</asp:Content>