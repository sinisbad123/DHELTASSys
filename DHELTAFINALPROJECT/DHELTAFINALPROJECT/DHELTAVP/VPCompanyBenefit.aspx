<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAVP/VicePresident.Master" AutoEventWireup="true" CodeBehind="VPCompanyBenefit.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAVP.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="benefit">
                <div class="greetings">
                    <h4>View Benefits For: 
                        <asp:DropDownList ID="cmbPositionFilter" runat="server" AutoPostBack="True" 
                            class="ddl" onselectedindexchanged="cmbPositionFilter_SelectedIndexChanged">
                        </asp:DropDownList>
                    </h4>
                </div>
                <hr />
                <div class="mainBody">
                    <asp:GridView ID="gvBenefit" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    </asp:GridView>
                </div>

            </div>
        </div>
    </div>
</div>

</asp:Content>
