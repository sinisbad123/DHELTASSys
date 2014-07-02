<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTASV/Supervisor.Master" AutoEventWireup="true" CodeBehind="SVFileOffense.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTASV.WebForm5" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
            <li class="sidebarmenu">
                <a data-toggle="modal" href="#filterModal4" class="benefit">View Offense Types</a>
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
            <h4>Employee(s) Under your supervision:</h4>
        </div>
        <div class="mainBody">
            <asp:GridView ID="gvEmployee" runat="server" 
                CssClass="table table-hover table-striped" 
                onrowdatabound="gvEmployee_RowDataBound" 
                onselectedindexchanged="gvEmployee_SelectedIndexChanged">
            </asp:GridView>

            <hr />

            <a data-toggle="modal" id="lnkFileOffense" href="#filterModal3" class="benefit" runat="server">File An Offense</a>

            <hr />
            <asp:Label ID="lblOffense" runat="server" Text="Offense Made by the Employee:"></asp:Label>
            <asp:GridView ID="gvOffense" runat="server" CssClass="table table-striped table-bordered table-condensed">
            </asp:GridView>
            
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
                        </asp:DropDownList>
                    <p class="offenseInfo">Offense Description:&nbsp&nbsp
                       <asp:TextBox ID="txtQuestion" runat="server" Width="100%" Height="100px"></asp:TextBox></p>
                </div>
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnAddOffenseType" runat="server" Text="Submit" 
                class="btn btn-primary" onclick="btnAddOffenseType_Click"/>
                  <asp:Button ID="Button2" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

<div class="modal fade" id="filterModal3" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Add Offense Type</h4>
              </div>
              <div class="modal-body">
                <div class="addEmployeeOffense">
                    <table style="width: 100%;">
                     <tr>
                            <td align="right">
                                <strong>Employee ID: </strong>
                            </td>
                            <td align="justify">
                               &nbsp&nbsp&nbsp&nbsp&nbsp <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Employee: </strong>
                            </td>
                            <td align="justify">
                               &nbsp&nbsp&nbsp&nbsp&nbsp <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style2">
                                <strong>Offense Made: </strong>
                            </td>
                            <td align="justify" class="style2">
                               &nbsp&nbsp&nbsp&nbsp&nbsp<asp:DropDownList ID="dpOffenseTypelist" runat="server" class="ddl">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                <strong>Offense Statement: </strong>
                            </td>
                            <td align="justify" class="style1">
                              &nbsp&nbsp&nbsp&nbsp&nbsp  <asp:TextBox ID="txtStatement" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right"><strong>Attach File: </strong></td>
                            <td align="justify">&nbsp&nbsp<asp:FileUpload ID="fileUploadProof" runat="server" class="btn btn-primary" /></td>
                        </tr>
                    </table>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnFileOffense" runat="server" Text="File Offense" 
            class="btn btn-primary" onclick="btnFileOffense_Click"/>
                  <asp:Button ID="Button5" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

    <div class="modal fade" id="filterModal4" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Offense Type</h4>
              </div>
              <div class="modal-body">
                  <asp:GridView ID="gvDisplayOffense" runat="server" CssClass="table table-striped table-bordered table-condensed">
                  </asp:GridView>     
              </div>
              <div class="modal-footer">
                  
                  <asp:Button ID="Button4" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

</asp:Content>
