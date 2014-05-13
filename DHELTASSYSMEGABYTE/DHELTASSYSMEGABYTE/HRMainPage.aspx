<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="HRMainPage.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
        <div class="content">
            <div class="mainContent">
               <div class="greetings">
                    <h2 class="hello">Good Day, 
                      <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>! What do you like to do today?</h2>
               </div>

               <div class="btnLeave">
                    <a data-toggle="modal" href="#filterModal" class="btn">Call in Sick</a>
                    <a data-toggle="modal" href="#filterModal" class="btn">Schedule a Vacation</a>  
               </div>

               <hr />

               <div class="requests">
               <h2 class="hello">Pending Requests(s):</h2><br />
                   <asp:Label ID="lblRequests" runat="server" Text="No Pending Requests at the moment"></asp:Label>
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
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnSave" runat="server" Text="Submit"  class="btn btn-primary" 
                      onclick="btnSave_Click"/>
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
                
              </div>
            </div><!-- /.modal-content -->
          </div><!-- /.modal-dialog -->
        </div><!-- /.modal -->


</asp:Content>
