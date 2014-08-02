<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HREvaluationQuestion.aspx.cs" Inherits="DHELTASSYSMEGABYTE.HREvaluationQuestion" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="humanresource">
            <br />
            <h1>Evaluation Questions</h1>
            <hr />
            <asp:Panel ID="pnlEditQuestion" runat="server">
            <div id="tblEditQuestion">
            <table id="tbl" align="center" class="style3">
            <tr>
                  <td align="center" class="style2" colspan="2">
            <asp:Label ID="lblEditQuestionTag" runat="server">Edit Evaluation Question</asp:Label>
                </td>
            </tr>
                <tr>
                    <td align="right" class="style15">
                        <asp:Label ID="lblQuestionID" runat="server">Question ID:</asp:Label>
                    </td>
                    <td align="left" class="style11">
                        <asp:TextBox ID="txtQuestionID_Edit" runat="server" Enabled="false" 
                            Width="250px"></asp:TextBox>
                    </td>
                </tr>
            <tr>
                <td align="right" class="style15">
                    <asp:Label ID="lblQuestion" runat="server">Question:</asp:Label>
                </td>
                <td align="left" class="style11">
                    <asp:TextBox ID="txtQuestion_Edit" runat="server" Enabled="false" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style15">
                    <asp:Label ID="lblPosition" runat="server">Position:</asp:Label>
                </td>
                <td align="left" class="style11">
                    <asp:TextBox ID="txtPosition_Edit" runat="server" Enabled="false" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style15">
                    <asp:Label ID="lblShow" runat="server">Question Status:</asp:Label>
                </td>
                <td align="left" class="style11">
                    <asp:DropDownList ID="dpQuesionStatus_Edit" runat="server" 
                        Width="250px">
                        <asp:ListItem Text="Publish"></asp:ListItem>
                        <asp:ListItem Text="Unpublish"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
                <tr>
                    <td align="center" class="style13" colspan="2">
                        <asp:Button ID="btnEditQuestion" runat="server" class="btn btn-primary" 
                            onclick="btnEditQuestion_Click" Text="Edit Question" />
                    </td>
                </tr>
            </table>
            </div>
            </asp:Panel> 
            <table>
            <tr>
                  <td align="center" colspan="3">
            <asp:Label ID="Label1" runat="server">Sort By</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style14" align="right">
                    Position:</td>
                <td align="left">

            <asp:DropDownList ID="dpSortQuestionPosition_Item" runat="server" Width="125px" >
                <asp:ListItem Text="All"></asp:ListItem>                
                <asp:ListItem Text="Employee"></asp:ListItem>
                <asp:ListItem Text="Supervisor"></asp:ListItem>
            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style14" align="right">
                    Question Status:</td>
                <td align="left">
            <asp:DropDownList ID="dpSortQuestionStatus_Item" runat="server" Width="125px" >
                <asp:ListItem Text="All"></asp:ListItem>                    
                <asp:ListItem Text="Publish"></asp:ListItem>
                <asp:ListItem Text="Unpublish"></asp:ListItem>
            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style14" align="center" colspan="3">
                <asp:Button ID="Button1" runat="server" Text="Sort Question" 
                class="btn btn-primary" onclick="btnSortQuestion_Click" />
                </td>
            </tr>
            </table>
            
            <br />
            <asp:GridView ID="gvEvaluationQuestion" runat="server" 
                CssClass="table table-striped table-bordered table-condensed"
                onselectedindexchanged="gvEvaluationQuestion_SelectedIndexChanged" 
                onrowdatabound="gvEvaluationQuestion_RowDataBound">
            </asp:GridView>
            <div class="modal-footer">
                    <asp:LinkButton ID="btnAddQuestion" runat="server" Text="Add Question" CssClass="search"
                data-toggle="modal" href="#filterModal"></asp:LinkButton>
              </div>
                <br />
                <br />
            </div>
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
                    <p class="evalForm">Position:&nbsp&nbsp 
                        <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl">
                            <asp:ListItem Text="Employee"></asp:ListItem>
                            <asp:ListItem Text="Supervisor"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p class="evalForm">Question Status: &nbsp&nbsp 
                        <asp:DropDownList ID="dpQuestionStatus" runat="server" CssClass="ddl">
                            <asp:ListItem Text="Publish"></asp:ListItem>
                            <asp:ListItem Text="Unpublish"></asp:ListItem>
                        </asp:DropDownList>
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
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style2
        {            height: 18px;
        }
        .style3
        {
            width: 883px;
            height: 156px;
        }
        .style11
        {
            width: 442px;
            height: 20px;
        }
        .style13
        {
            height: 20px;
        }
        .style14
        {
        }
        .style15
        {
            width: 441px;
            height: 20px;
        }
    </style>
</asp:Content>
