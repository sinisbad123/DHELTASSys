<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="HRAddEmployeeBenefit.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm27" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
            <li class="sidebarmenu">
                <asp:HyperLink ID="lnkAssess" runat="server" href="HRCompanyBenefit.aspx">Company Benefit</asp:HyperLink>
            </li>
            <li class="sidebarmenu">
                <a data-toggle="modal" href="#filterModal">Add Benefit</a>
            </li>

            

        </ul>
    </div>
</div>
    
<div class="containerfluid">
    <div class="mainContainer">
       <div class="viewbenefit">
            <div class="gridview">

               <br />
                <h2>Add Employee(s) Benefit:</h2>

                <br />
                
                <asp:GridView ID="gvEmployee"  
                    CssClass="table table-striped table-bordered table-condensed" runat="server" 
                    Height="178px" onrowdatabound="gvEmployee_RowDataBound" 
                    onselectedindexchanged="gvEmployee_SelectedIndexChanged" Width="500px">
                </asp:GridView>
            </div>
            <hr />
            <div class="addempbenefit">
                <p>Employee ID: 
                    <asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label></p>
                <p>Last Name: 
                    <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label></p>
                <p>First Name: 
                    <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label></p>
                <p>Position: 
                    <asp:Label ID="lblPos" runat="server" Text="Label"></asp:Label></p>
                <p>Department: 
                    <asp:Label ID="lblDept" runat="server" Text="Label"></asp:Label></p>
                <p>Benefit: 
                    <asp:DropDownList ID="dpBenefit" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </p>

                <br />

                <asp:Button ID="btnSubmit" runat="server" Text="Add Benefit"  
                    class="btn btn-primary" onclick="btnSubmit_Click" />

            </div>
            <br />
            <div class="removebenefit">
                <asp:GridView ID="gvBenefit" runat="server" 
                    CssClass="table table-striped table-bordered table-condensed">
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
                <div class="addBenefit">
                    <p class="benefitinfo">For Position:&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </p>
                    <p class="benefitinfo">Benefit Type:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                       <asp:TextBox ID="txtBenefitType" runat="server"></asp:TextBox></p>
                     <p class="benefitinfo">Benefit Information:&nbsp&nbsp
                       <asp:TextBox ID="txtBenefitInfo" runat="server"></asp:TextBox></p>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnDone" runat="server" Text="Submit" class="btn btn-primary" 
                    onclick="btnDone_Click" />
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>
</asp:Content>
