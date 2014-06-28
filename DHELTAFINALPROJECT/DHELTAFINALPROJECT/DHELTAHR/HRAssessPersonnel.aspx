<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRAssessPersonnel.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm10" %>
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
                 <a data-toggle="modal" href="#filterModal2" class="benefit">View Evalutaion Question</a>
            </li>
        </ul>
    </div>
</div>

<div class="containerFluid">
    <div class="mainContainer">
        <div class="greetings">
        <h4>Employee(s) in the Company</h4>
        </div>

        <div class="mainBody">
        
        </div>

    </div>
</div>

</asp:Content>
