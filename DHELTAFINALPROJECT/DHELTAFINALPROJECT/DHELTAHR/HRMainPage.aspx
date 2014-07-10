<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRMainPage.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
           <li class="sidebarmenu">
                 <asp:HyperLink ID="lnkAssess" runat="server" href="HRAssessPersonnel.aspx" class="benefit">Assess Personnel</asp:HyperLink>
            </li>

            <li class="sidebarmenu">
                 <asp:HyperLink ID="lnkEvalQuestion" runat="server" href="HREvaluationQuestion.aspx" class="benefit">View Evaluation Question</asp:HyperLink>
            </li>

            <li class="sidebarmenu">
                 <asp:HyperLink ID="lnkTransferRequest" runat="server" href="HREmployeeTransfer.aspx" class="benefit">Transfer Request</asp:HyperLink>
            </li>
        </ul>
    </div>
</div>

<div class="containerFluid">
    <div class="mainContainer">
        <div class="greetings">
            <h4>Good Day, <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>! What do you like to do today?</h4>
        </div>
        <hr />

            <div class="mainBody">
                <div class="btnRequests">
                    <a data-toggle="modal" href="#filterModal" class="btn">Call in Sick</a>
                    <a data-toggle="modal" href="#filterModal" class="btn">Schedule a Vacation</a>
                </div>
                
                <hr />
                
                <div class="pendingRequest">
                   <h4> <asp:Label ID="Label1" runat="server" Text="Request(s) Made:"></asp:Label></h4><br />
                    <asp:Label ID="lblPending" runat="server" Text="No Pending Request"></asp:Label>
                    <asp:GridView ID="gvRequests" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
                </div>
            </div>
    </div>
</div>


<div class="modal fade" id="filterModal" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Leave Request</h4>
              </div>
              <div class="modal-body">
                <div class="leaverequest">
                    <p class="requestLeave">Type of Leave:&nbsp&nbsp 
                        <asp:DropDownList ID="dpLeaveType" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </p>
                    <p class="requestLeave">Starting Date:&nbsp&nbsp
                       <asp:TextBox ID="txtStartingDate" runat="server" TextMode="Date"></asp:TextBox></p>
                    <p class="requestLeave">Ending Date:&nbsp &nbsp 
                        <asp:TextBox ID="txtEndingDate" runat="server" TextMode="Date"></asp:TextBox></p>
                    <p class="requestLeave">Reason:&nbsp &nbsp 
                        <asp:TextBox ID="txtReason" runat="server" Width="100%" Height="100px"></asp:TextBox>
                    </p>

                </div>

                <hr />

                <div>
                    <asp:GridView ID="gvBalance" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-primary" 
                    onclick="btnSave_Click"/>
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
                
              </div>
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
                    <asp:Button ID="btnAddEvalutaionQuestion" runat="server" Text="Submit" 
                    class="btn btn-primary" onclick="btnAddEvalutaionQuestion_Click"/>
                    <asp:Button ID="Button3" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
            </div>
        </div>
    </div>

</asp:Content>
