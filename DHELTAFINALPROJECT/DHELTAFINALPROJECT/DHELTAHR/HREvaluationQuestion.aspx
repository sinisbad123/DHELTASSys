<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HREvaluationQuestion.aspx.cs" Inherits="DHELTASSYSMEGABYTE.HREvaluationQuestion" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="containerfluid">
    <div class="mainContainer">
        <div class="humanresource">
        <br />
            <h1>Evaluation Questions</h1>
            <hr />
            <asp:GridView ID="gvEvaluationQuestion" runat="server" 
                CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            <br />
            <div class="modal-footer">
                    <asp:LinkButton ID="btnAddQuestion" runat="server" Text="Add Question" CssClass="search"
                data-toggle="modal" href="#filterModal"></asp:LinkButton>
              </div>
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
                <h4 class="modal-title">Add Evaluation Question</h4>
              </div>
              <div class="modal-body">
                <div class="addEvaluation">                    
                    <p class="evalForm">Question:&nbsp&nbsp
                       <asp:TextBox ID="txtQuestion" runat="server" Width="100%" Height="100px"></asp:TextBox>
                    </p>
                    <p class="evalForm">Category:&nbsp&nbsp 
                        <asp:DropDownList ID="dpEvaluationCategory"  DataTextField="eval_category" DataValueField="eval_category" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </p>
                    <p class="evalForm">Position:&nbsp&nbsp 
                        <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl">
                            <asp:ListItem Text="Employee"></asp:ListItem>
                            <asp:ListItem Text="Supervisor"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </div>
                  
              </div>
              <div class="modal-footer">
                    <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-primary" onclick="btnSave_Click" />
                    <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
            </div>
        </div>
    </div>
</asp:Content>