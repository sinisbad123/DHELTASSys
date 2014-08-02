<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HROffenseEvaluation.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm11" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="offense">
                <div class="greetings">
                    <h4>Employees Offense</h4>
                </div>
                
                <hr />

                <div class="mainBody">
                    <asp:GridView ID="grdPedingOffense" runat="server" 
                        CssClass="table table-hover table-striped" 
                        onrowdatabound="grdPedingOffense_RowDataBound" OnSelectedIndexChanged="grdPedingOffense_SelectedIndexChanged">
                    </asp:GridView>
                </div>

                <hr />
                <asp:Image
                ID="imgProof" runat="server" Visible="False" /> 
                <hr />
                <asp:DropDownList
                ID="drpDecision" 
                runat="server" 
                    >
                    <asp:ListItem>Approve</asp:ListItem>
                    <asp:ListItem>Disapprove</asp:ListItem>
                </asp:DropDownList>
                <hr />
                <asp:Button ID="btnEval" runat="server" Text="Evaluate Offense" 
                    class="btn btn-primary" onclick="btnEval_Click" />
                            
            </div>
        </div>
    </div>
</div>

</asp:Content>
