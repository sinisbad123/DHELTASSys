<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRProfile.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 857px;
        }
        .style5
        {
            width: 214px;
         font-weight: 700;
     }
        .style6
        {
            width: 215px;
        }
        .style7
        {
            width: 214px;
            height: 17px;
        }
        .style8
        {
            width: 215px;
            height: 17px;
        }
        .style9
        {
            width: 214px;
            font-weight: bold;
        }
     .style11
     {
         width: 214px;
     }
     .style12
     {
         width: 112px;
         font-weight: bold;
     }
     .style13
     {
         width: 112px;
         font-weight: 700;
     }
     .style14
     {
         width: 112px;
         height: 17px;
     }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
           <li class="sidebarmenu">
                 <a data-toggle="modal" href="#filterModal2" class="benefit">View Benefit</a>
            </li>

            <li class="sidebarmenu">
                 <a data-toggle="modal" href="#filterModal3" class="benefit">View Offense</a>
            </li>

            <li class="sidebarmenu">
                 <a data-toggle="modal" href="#filterModal4" class="benefit">View Dependent</a>
            </li>
        </ul>
    </div>
</div>

<div class="containerFluid">
    <div class="mainContainer">
        <div class="profile">
            <div class="fullname">
                <strong><asp:Label ID="lblFullName" runat="server" Text="Label"></asp:Label></strong> &nbsp
                <asp:Label ID="lblPosition" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <hr />
        <div class="employeeinformation">
        <div class="editprofile">
            <a data-toggle="modal" href="#filterModal" class="btn">Edit Profile</a>
        </div>
            <div class="basicInfo">
                <table class="style1" width="100%">
                    <tr>
                        <td align="right" class="style9">
                            ID Number:</td>
                        <td class="style5">
                            &nbsp;
                            &nbsp;
                            <asp:Label ID="lblIDNumber" runat="server" Text="Label"></asp:Label>
                            
                        </td>
                        <td align="right" class="style5">
                            <strong>Position:</strong></td>
                        <td class="style6">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblPosinfo" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style5">
                            <strong>Last Name:</strong></td>
                        <td class="style5">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="right" class="style5">
                            <strong>Company Name:</strong></td>
                        <td class="style6">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style7">
                            <strong>First Name:</strong></td>
                        <td class="style7">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="right" class="style7">
                            <strong>SSS Number:</strong></td>
                        <td class="style8">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblSSSNumber" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style5">
                            <strong>Middle Name:</strong></td>
                        <td class="style5">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblMiddleName" runat="server" Text="Label"></asp:Label>
                            &nbsp;</td>
                        <td align="right" class="style5">
                            <strong>PhilHealth Number:</strong></td>
                        <td class="style6">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblPhilHealthNumber" runat="server" Text="Label"></asp:Label>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>

        <hr />

        <div class="attendanceSummary">
            <div class="attendance">
                <h4>Attendance Summary</h4>
                <hr />
                <asp:GridView ID="gvAttendanceSummary" runat="server" CssClass="table table-striped table-bordered table-condensed">
                </asp:GridView>
            </div>
            <hr />

            <div class="shiftSummary">
                <h4>Shift Summary</h4>
                <hr />
                <asp:GridView ID="gvShiftSummary" runat="server" CssClass="table table-striped table-bordered table-condensed">
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
                <h4 class="modal-title">Edit Profile</h4>
              </div>
              <div class="modal-body">
               <div class="updateprofile">
                   <table class="style1" width="100%">
                    <tr class="update">
                        <td align="right" class="style12">
                            ID Number:</td>
                        <td class="style11">
                            &nbsp;
                            &nbsp;
                            <asp:TextBox ID="txtIDNumber" runat="server"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr class="update">
                        <td align="right" class="style13">
                            <strong>Last Name:</strong></td>
                        <td class="style11">
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="update">
                        <td align="right" class="style14">
                            <strong>First Name:</strong></td>
                        <td class="style7">
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="update">
                        <td align="right" class="style13">
                            <strong>Middle Name:</strong></td>
                        <td class="style11">
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr class="update">
                        <td align="right" class="style13">
                            Position:</td>
                        <td class="style11">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblEditPosition" runat="server" Text="Label"></asp:Label>
                            
                            &nbsp;</td>
                    </tr>
                    <tr class="update">
                        <td align="right" class="style13">
                            Company Name:</td>
                        <td class="style11">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblEditCompanyName" runat="server" Text="Label"></asp:Label>
                            
                            &nbsp;</td>
                    </tr>
                    <tr class="update">
                        <td align="right" class="style13">
                            SSS Number:</td>
                        <td class="style11">
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSSSNumber" runat="server"></asp:TextBox>
                            
                            &nbsp;</td>
                    </tr>
                    <tr class="update">
                        <td align="right" class="style13">
                            PhilHealth Number:</td>
                        <td class="style11">
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtPhilHealthNumber" runat="server"></asp:TextBox>
                            
                            &nbsp;</td>
                    </tr>
                </table> 
              </div>
              <div class="modal-footer">
             <asp:Button ID="btnSubmit" runat="server" Text="Done" class="btn btn-primary"/>
              <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
            </div>
        </div>
    </div>
 </div>

 <div class="modal fade" id="filterModal2" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">View Benefit</h4>
              </div>
              <div class="modal-body">
                <div class="viewBenefit">
                    <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="Button2" runat="server" Text="Close" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

    
    <div class="modal fade" id="filterModal3" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">View Offense</h4>
              </div>
              <div class="modal-body">
                <div class="viewBenefit">
                    <asp:GridView ID="gvOffense" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="Button3" runat="server" Text="Close" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

     <div class="modal fade" id="filterModal4" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">View Depedent</h4>
              </div>
              <div class="modal-body">
                <div class="viewBenefit">
                    <asp:GridView ID="gvDepedent" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnAddDedepent" runat="server" Text="Add Dependent" 
        class="btn btn-primary" onclick="btnAddDedepent_Click"/>
                  <asp:Button ID="Button1" runat="server" Text="Close" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

</asp:Content>
