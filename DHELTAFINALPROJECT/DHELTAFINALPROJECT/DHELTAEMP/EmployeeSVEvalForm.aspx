<%@ Page Language="C#" MasterPageFile="~/DHELTAEMP/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeSVEvalForm.aspx.cs" Inherits="DHELTASSYSMEGABYTE.EmployeeSVEvalForm" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="humanresource">
                <br />
                <h1>Evaluation Form</h1>
                <hr />
                <asp:Label ID="Label1" runat="server">ID Number: </asp:Label>
                <asp:Label ID="lblEvaluated_EmpID" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server">Name: </asp:Label>
                <asp:Label ID="lblName" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server">Position: </asp:Label>
                <asp:Label ID="lblPosition" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server">Department: </asp:Label>
                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server">Quarter: </asp:Label>
                <asp:Label ID="lblQuarter" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server">Date: </asp:Label>
                <asp:Label ID="lblDate" runat="server"></asp:Label>
                <br />
                <br />
                <p style="text-align:center;">
                INSTRUCTION: Complete the evaluation by answering the following questions. Please check the answer that best describes your satisfaction with your supervisor.
                <br>
                <br>
                Ratings:<br>
                <i>SA - Strongly Agree</i><br>
                <i>A - Agree</i><br>
                <i>D - Disagree</i><br>
                <i>SD - Strongly Disagree</i><br>
                <br>
                </p>
                <asp:GridView ID="gvSVEvalForm" runat="server" CssClass="table table-striped table-bordered table-condensed">
                    <Columns>
                        <asp:TemplateField HeaderText="Ratings">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbtnRatings" runat="server" 
                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="SA" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="A" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="D" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="SD" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator runat="server" ID="genderRequired" Display="Dynamic"
                                ControlToValidate="rbtnRatings" ErrorMessage="Answers must not be left unchecked." ForeColor="Red">*
                                </asp:RequiredFieldValidator>                                        
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="modal-footer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" onclick="btnSubmit_Click"  />
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
