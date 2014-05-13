<%@ Page Title="" Language="C#" MasterPageFile="~/VP.Master" AutoEventWireup="true" CodeBehind="VPCompanyBenefit.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm23" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="containerfluid">
    <div class="mainContainer">
        <div class="viewbenefit">
            <div class="gridview">

            <h2>View Benefits For:&nbsp &nbsp 
                <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl" 
                    onselectedindexchanged="dpPosition_SelectedIndexChanged">
                </asp:DropDownList>
            </h2>

            <hr />
                <asp:GridView ID="gvBenefit" runat="server" CssClass="table table-striped table-bordered table-condensed">
                </asp:GridView>
            </div>
        </div>
    </div>
</div>

</asp:Content>
