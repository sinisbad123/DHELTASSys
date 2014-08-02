<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRApproveLeaveRequest.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="leaverequest">
                <div class="greetings">
                    <h4>Leave Request(s) of the Employee(s):</h4>
                </div>
                <hr />

                <div class="mainBody">
                    <asp:GridView ID="gvPendingRequest" runat="server"  CssClass="table table-striped table-bordered table-condensed">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRequests" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                     <asp:DropDownList ID="dpHRDecision" runat="server" class="ddl">
                        <asp:ListItem>Approve</asp:ListItem>
                        <asp:ListItem>Deny</asp:ListItem>
                    </asp:DropDownList>

                     <hr />

                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" 
                        onclick="btnSubmit_Click"/>

                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
