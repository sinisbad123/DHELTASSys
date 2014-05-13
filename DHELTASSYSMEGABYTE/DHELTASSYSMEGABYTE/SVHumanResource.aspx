<%@ Page Title="" Language="C#" MasterPageFile="~/SV.Master" AutoEventWireup="true" CodeBehind="SVHumanResource.aspx.cs" Inherits="DHELTASSYSMEGABYTE.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
        <div class="content">
            <div class="mainContent">
                <div class="evaluate">
                    <h2>Employees in your Department:</h2><br />
                        <div class="gridview">
                            <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped table-bordered table-condensed">
                            </asp:GridView>
                        </div>
               </div>

               <hr />
               <div class="buttons">
                <asp:Button ID="btnEvaluate" runat="server" Text="Evaluate Employee" 
                       class="btn btn-primary" onclick="btnEvaluate_Click"/>
                </div>

            </div>
        </div>
</div>

</asp:Content>
