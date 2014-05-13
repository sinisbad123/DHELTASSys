<%@ Page Title="" Language="C#" MasterPageFile="~/SV.Master" AutoEventWireup="true" CodeBehind="SVPerformance.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
            <li class="sidebarmenu">
                <asp:HyperLink ID="lnkShift" runat="server" href="SVFileOffense.aspx">File an Offense</asp:HyperLink>
            </li>

            <li class="sidebarmenu">
                <a data-toggle="modal" href="#filterModal">Add Offense Type</a>
            </li>

        </ul>
    </div>
</div>

<div class="containerfluid">
    <div class="mainContainer">
        <div class="performance">
            <div class="gridview">
                <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped table-bordered table-condensed">
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
                <h4 class="modal-title">Add Offense Type</h4>
              </div>
              <div class="modal-body">
                <div class="addOffense">
                    <p class="offenseInfo">Offense Type:&nbsp&nbsp 
                        <asp:DropDownList ID="dpOffenseType" runat="server" CssClass="ddl">
                        </asp:DropDownList>
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
                  <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" onclick="btnSubmit_Click" />
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

</asp:Content>
