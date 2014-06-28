using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

using DHELTASSys.Modules;
using DHELTASSYS.DataAccess;

namespace DHELTAFINALPROJECT.DHELTAVP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        TransferModuleBL transfer = new TransferModuleBL();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmpRequest.Visible = false;
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {

                if (Session["Position"].ToString() != "Vice President")
                {
                    Response.Redirect(@"~/index.aspx");
                }
                else
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    if (!IsPostBack)
                    {
                        int ComID = int.Parse(Session["CompanyID"].ToString());
                        lblCompanyIDRequesting.Text = ComID.ToString();
                        lblCompanyIDRequesting.Visible = false;
                        transfer.CompanyID = int.Parse(lblCompanyIDRequesting.Text);
                        gvEmployee.DataSource = transfer.ViewVPRequestEmployee();
                        gvEmployee.DataBind();
                        btnSubmit.Visible = true;
                        dpApproval.Visible = true;

                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvEmployee.Rows.Count; i++)
            {
                CheckBox chkTransferRequest = (CheckBox)gvEmployee.Rows[i].Cells[0].FindControl("chckbxTransfer");
                if (chkTransferRequest.Checked)
                {

                    if (dpApproval.SelectedItem.Text == "Approve")
                    {
                        transfer.VpRequestingDecision = dpApproval.SelectedValue.ToString();
                        transfer.TransferRequestID = int.Parse(gvEmployee.Rows[i].Cells[1].Text);
                        transfer.UpdateVPRequestingDecision();
                        transfer.AddEmployeeReceive();

                    }
                    else
                    {
                        transfer.VpRequestingDecision = dpApproval.SelectedValue.ToString();
                        transfer.TransferRequestID = int.Parse(gvEmployee.Rows[i].Cells[1].Text);
                        transfer.DenyEmployeeRequest();

                    }
                }
            }
            Response.Redirect("VPHRTransferRequest.aspx");
        }
    }
}