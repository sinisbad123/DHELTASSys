<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRHumanResource.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm3" EnableEventValidation="false" %>
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
    <div class="mainContainer" style="border-style: none;>
        <div class="collegues">
            <h4>Your Collegues:</h4>
            <hr />
            <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped table-bordered table-condensed"
                 onrowdatabound="gvEmployee_RowDataBound" 
                 onselectedindexchanged="gvEmployee_SelectedIndexChanged">
            </asp:GridView>

            <hr />

            <table>
            <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label></td>
            <td>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="First Name"></asp:Label></td>
            <td>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Middle Name"></asp:Label></td>
            <td>
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Last Name"></asp:Label></td>
            <td>
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Position"></asp:Label></td>
            <td>
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Department"></asp:Label></td>
            <td>
                <asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Email"></asp:Label></td>
            <td>
                <asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label15" runat="server" Text="Gender"></asp:Label></td>
            <td>
                <asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Address"></asp:Label></td>
            <td>
                <asp:Label ID="Label18" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Primary Number"></asp:Label></td>
            <td>
                <asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label21" runat="server" Text="Alternative Number"></asp:Label></td>
            <td>
                <asp:Label ID="Label22" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label23" runat="server" Text="City"></asp:Label></td>
            <td>
                <asp:Label ID="Label24" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label25" runat="server" Text="SSS Number"></asp:Label></td>
            <td>
                <asp:Label ID="Label26" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label27" runat="server" Text="PhilHealth Number"></asp:Label></td>
            <td>
                <asp:Label ID="Label28" runat="server" Text=""></asp:Label></td>
            </tr>
            </table>
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
