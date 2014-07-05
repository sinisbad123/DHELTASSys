<%@ Page Language="C#" MasterPageFile="~/DHELTAEMP/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeSVEvaluate.aspx.cs" Inherits="DHELTASSYSMEGABYTE.EmployeeSVEvaluate" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerfluid">
    <div class="mainContainer">
        <div class="humanresource">
        <br />
            <h1>Your Supervisor for Evaluation</h1>
            <hr />
            <asp:GridView ID="gvSVEvaluate" runat="server"
            CssClass="table table-striped table-bordered table-condensed" 
                onrowdatabound="gvSVEvaluate_RowDataBound" >
            </asp:GridView>
                    <br />
                <asp:LinkButton ID="btnEvaluate" runat="server" Text="Evaluate" CssClass="search"
                data-toggle="modal" href="#filterModal" ></asp:LinkButton>
                <br />
            <br />
        </div>
    </div>
</div>

<div class="modal fade" id="filterModal" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Evaluate Supervisor</h4>
              </div>
              <div class="modal-body">
                <div class="addEvaluation">      
                    <asp:Label runat="server">Are you sure you want to proceed?</asp:Label>
                    <div class="modal-footer">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
                    </div>
                </div>                 
              </div>
            </div>
        </div>
    </div>
</asp:Content>
