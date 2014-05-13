<%@ Page Title="" Language="C#" MasterPageFile="~/SV.Master" AutoEventWireup="true" CodeBehind="SVProfile.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="container">
    <div class="mainContent">
        <div class="fullName">
            <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>&nbsp
            <asp:Label ID="lblPosition" runat="server" Text="" class="pos"></asp:Label>
            <a data-toggle="modal" href="#filterModal" class="update">Edit Profile</a>

        </div>

        <hr />

        <div class="profile">
            <div class="infos">
                <p class="generalinfo">Last Name: <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label></p><br />
                <p class="generalinfo">First Name: <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label></p><br />
                <p class="generalinfo">Middle Name: <asp:Label ID="lblMiddleName" runat="server" Text="Label"></asp:Label></p><br />
                <p class="generalinfo">Email Address: <asp:Label ID="lblEmailAdd" runat="server" Text="Label"></asp:Label></p><br />
                <p class="generalinfo">Birthday: <asp:Label ID="lblBirthday" runat="server" Text="Label"></asp:Label></p><br />
                <div class="company">
                    <p class="companyinfo">Position: <asp:Label ID="lblPos" runat="server" Text="Label"></asp:Label></p><br /> 
                    <p class="companyinfo">Company Name: <asp:Label ID="lblCompany" runat="server" Text="Label"></asp:Label></p><br />
                    <p class="companyinfo">Deprtament Name: <asp:Label ID="lblDepartment" runat="server" Text="Label"></asp:Label></p><br />
                    <p class="companyinfo">SSS Number: <asp:Label ID="lblSSS" runat="server" Text="Label"></asp:Label></p><br />
                    <p class="companyinfo">PhilHealth Number: <asp:Label ID="lblPhilHealth" runat="server" Text="Label"></asp:Label></p><br />  
                </div>
            </div>
        </div>

        <hr />

        <div class="shiftattendance">
            <div class="attendancesummary">
                <h2>Attendance Summary</h2>
            </div>

            <hr />

            <div class="shitsummary">
                <h2>Shift for a Week:</h2>
            </div>
            <hr />
            <div class="benefit">
                <a data-toggle="modal" href="#filterModal2" class="benefit">View Benefit</a>            
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
                <div class="editprofile">
                    <p class="updateinfo">Last Name: &nbsp&nbsp&nbsp&nbsp &nbsp&nbsp<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></p>
                    <p class="updateinfo">First Name: &nbsp&nbsp&nbsp&nbsp &nbsp&nbsp<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></p>
                    <p class="updateinfo">Middle Name: &nbsp&nbsp&nbsp<asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox></p>
                    <p class="updateinfo">Email Address: &nbsp&nbsp<asp:TextBox ID="txtEadd" runat="server"></asp:TextBox></p>
                    <p class="updateinfo">Birthdate: &nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox></p>
                    <p class="updateinfo">Position: &nbsp&nbsp&nbsp&nbsp &nbsp&nbsp &nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtPosition" runat="server"></asp:TextBox></p>
                    <p class="updateinfo">SSS Number: &nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtSSS" runat="server"></asp:TextBox></p>
                    <p class="updateinfo">PhilHealth Number: &nbsp&nbsp<asp:TextBox ID="txtPhilHealth" runat="server"></asp:TextBox></p>

                </div>
                  
              </div>
              <div class="modal-footer">
              <asp:Button ID="btnSubmit" runat="server" Text="Done" class="btn btn-primary" onclick="btnSubmit_Click" />
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

</asp:Content>
