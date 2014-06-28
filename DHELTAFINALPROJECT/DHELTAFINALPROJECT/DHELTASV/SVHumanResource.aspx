<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTASV/Supervisor.Master" AutoEventWireup="true" CodeBehind="SVHumanResource.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTASV.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="attendance">
                <div class="greetings">
                    <h4>Employees in you Department</h4>
                </div>
                <hr />
                <div class="mainBody">
                    <div class="greetings">
                        <asp:GridView ID="grdviewAllSummary" runat="server" 
                            CssClass="table table-hover table-striped" >
                         </asp:GridView>
                         <hr />
                        <asp:Button ID="btnEvaluate" runat="server" Text="Evaluate Employee" class="btn btn-primary" />
                     </div>
               </div>
           </div>
        </div>
    </div>
</div>

</asp:Content>
