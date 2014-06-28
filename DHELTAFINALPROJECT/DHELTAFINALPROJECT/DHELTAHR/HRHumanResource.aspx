<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRHumanResource.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
           <li class="sidebarmenu">
                 <a data-toggle="modal" href="#" class="benefit">Assess Personnel</a>
            </li>

            <li class="sidebarmenu">
                 <a data-toggle="modal" href="#filterModal3" class="benefit">Add Evaluation Question</a>
            </li>

            <li class="sidebarmenu">
                 <a data-toggle="modal" href="#filterModal2" class="benefit">View Evaluation Question</a>
            </li>
        </ul>
    </div>
</div>

<div class="containerFluid">
    <div class="mainContainer">
        <div class="collegues">
            <h4>Your Collegues:</h4>
            <hr />
            <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
        </div>
    </div>
</div>

<div class="modal fade" id="filterModal2" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">View Evaluation Questions</h4>
              </div>
              <div class="modal-body">
                <div class="addEvaluation">
                    <asp:GridView ID="gvEvaluationQuestion" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="button" runat="server" Text="Close" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

    <div class="modal fade" id="filterModal3" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Add Evaluation Question</h4>
              </div>
              <div class="modal-body">
                <div class="addEvaluation">
                    <p class="evalForm">Category:&nbsp&nbsp 
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </p>
                    <p class="evalForm">Question:&nbsp&nbsp
                       <asp:TextBox ID="txtQuestion" runat="server" Width="100%" Height="100px"></asp:TextBox></p>
                    <p class="evalForm">Position:&nbsp&nbsp 
                        <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </p>
                    

                </div>
                  
              </div>
              <div class="modal-footer">
                    <asp:Button ID="btnAddEvalutaionQuestion" runat="server" Text="Submit" class="btn btn-primary"/>
                    <asp:Button ID="Button3" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
            </div>
        </div>
    </div>

</asp:Content>
