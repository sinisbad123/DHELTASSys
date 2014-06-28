<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRAddEmployeeBenefit.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm6" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="greetings">
                <h4>List of Employees:</h4>
            </div>

            <hr />

            <div class="mainBody">
                <asp:GridView ID="gvEmployee" runat="server"  
                    CssClass="table table-striped table-bordered table-condensed" 
                    onrowdatabound="gvEmployee_RowDataBound" 
                    onselectedindexchanged="gvEmployee_SelectedIndexChanged">
                </asp:GridView>

                <hr />

                <asp:LinkButton ID="lbModal" runat="server" data-toggle="modal"  href="#filterModal">Add Benefit</asp:LinkButton>

                <hr />
                <div class="greetings">
                    <asp:Label ID="lblBenefit" runat="server" Text="List of Employees' Benefit"></asp:Label>
                </div>
                <hr />
                <asp:GridView ID="gvBenefit" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEmpBenefit" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
                    <asp:Button ID="btnRemove" runat="server" Text="Remove Benefit" 
                    class="btn btn-primary" onclick="btnRemove_Click" />
            </div>

        </div>
    </div>
</div>

<div class="modal fade" id="filterModal" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Add Benefit</h4>
              </div>
              <div class="modal-body">
              <table style="width: 100%;">
                        <tr class="addbenefit">
                            <td align="right">
                                <p class="modifybenefit"><b>Employee ID:</b></p>
                            </td>
                            <td align="justify">
                               <asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr class="addbenefit">
                            <td align="right">
                               <p class="modifybenefit"><b>Last Name:</b></p>
                            </td>
                            <td align="justify">
                               <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr class="addbenefit">
                            <td align="right">
                               <p class="modifybenefit"><b>First Name:</b></p>
                            </td>
                            <td align="justify">
                               <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>

                        <tr class="addbenefit">
                            <td align="right">
                               <p class="modifybenefit"><b>Position:</b></p>
                            </td>
                            <td align="justify">
                               <asp:Label ID="lblPos" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>


                        <tr class="addbenefit">
                            <td align="right">
                               <p class="modifybenefit"><b>Department:</b></p>
                            </td>
                            <td align="justify">
                               <asp:Label ID="lblDept" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>

                        <tr class="addbenefit">
                            <td align="right">
                               <p class="modifybenefit"><b>Benefit:</b></p>
                            </td>
                            <td align="justify">
                                <asp:DropDownList ID="dpBenefit" runat="server" class="ddl">
                                </asp:DropDownList>
                        </tr>

                        </table>
               </div>
              <div class="modal-footer">
                  <asp:Button ID="btnSubmit" runat="server" Text="Add Benefit" 
                    class="btn btn-primary" onclick="btnSubmit_Click"/>
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

</asp:Content>
