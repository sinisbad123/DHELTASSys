<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTASV/Supervisor.Master" AutoEventWireup="true" CodeBehind="SVMainPage.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTASV.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
            <li class="sidebarmenu">
                <asp:HyperLink ID="lnOffense" runat="server" href="SVFileOffense.aspx">File an Offense</asp:HyperLink>
            </li>

            <li class="sidebarmenu">
                 <a data-toggle="modal" href="#filterModal2" class="benefit">Add Offense Type</a>
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
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" 
            onclick="btnSubmit_Click"/>
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
                <h4 class="modal-title">Add Offense Type</h4>
              </div>
              <div class="modal-body">
                <div class="addOffense">
                    <p class="offenseInfo">Offense Type:&nbsp&nbsp 
                        <asp:DropDownList ID="dpOffenseType" runat="server" CssClass="ddl">
                            <asp:ListItem>Minor</asp:ListItem>
                            <asp:ListItem>Major</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <p>Offense type INFO:<asp:TextBox ID="txtOffenseInfo" runat="server"></asp:TextBox> </p>
                    </p>
                    <p class="offenseInfo">Category:&nbsp&nbsp 
                        <asp:DropDownList ID="dpCategory" runat="server" CssClass="ddl">
                        </asp:DropDownList> OR 
                        <asp:TextBox ID="txtAddCategory" runat="server" placholder="Add Category"></asp:TextBox>
                    </p>
                    <p class="offenseInfo">Offense Description:&nbsp&nbsp
                       <asp:TextBox ID="txtQuestion" runat="server" Width="100%" Height="100px"></asp:TextBox></p>
                    <p class="evalForm">Position:&nbsp&nbsp 
                        <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </p>
                    

                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnAddOffense" runat="server" Text="Submit" 
                    class="btn btn-primary" onclick="btnAddOffense_Click" />
                  <asp:Button ID="Button2" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

</asp:Content>
