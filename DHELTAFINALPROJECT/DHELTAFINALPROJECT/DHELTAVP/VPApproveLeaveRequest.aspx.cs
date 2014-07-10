using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DHELTASSys.modules;
using DHELTASSYS.DataAccess;
using DHELTASSys.AuditTrail;

namespace DHELTAFINALPROJECT.DHELTAVP
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        LeaveModuleBL leave = new LeaveModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {
                userSession = int.Parse(Session["EmployeeID"].ToString());
                if (Session["Position"].ToString() == "Vice President")
                {
                    if (!IsPostBack)
                    {
                        leave.Emp_id = userSession;
                        leave.Date_from = DateTime.Now.ToShortDateString();
                        gvPendingRequest.DataSource = leave.ViewVPLeaveRequest();
                        gvPendingRequest.DataBind();
                        if (gvPendingRequest.Rows.Count <= 0)
                        {
                            //lblNoVPPending.Visible = true;
                            dpHRDecision.Enabled = false;
                            btnSubmit.Enabled = false;
                        }
                        else
                        {
                            //lblNoVPPending.Visible = false;
                        }
                    }
                }
                else if (Session["Position"].ToString() == "HR Manager")
                {
                    Response.Redirect("HRMainPage.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvPendingRequest.Rows.Count; i++)
            {
                CheckBox chkVPSelected = (CheckBox)gvPendingRequest.Rows[i].Cells[0].FindControl("chkRequests");
                if (chkVPSelected.Checked)
                {
                    if (dpHRDecision.SelectedItem.Text == "Approve")
                    {
                        leave.Leave_req_id = int.Parse(gvPendingRequest.Rows[i].Cells[1].Text);
                        leave.Vp_decision = dpHRDecision.SelectedValue.ToString();
                        leave.EmployeeLeaveVPDecision();
                        //leave.Emp_id = int.Parse(gvPendingRequest.Rows[i].Cells[2].Text);
                        leave.Emp_id = int.Parse(leave.viewLeaveRequestEmployeeID().Rows[0][0].ToString());
                        leave.UpdateLeaveBalance();
                        auditTrail.Emp_id = userSession;
                        auditTrail.AddAuditTrail("Approved " + gvPendingRequest.Rows[i].Cells[2].Text + " Leave Request");
                    }
                    else
                    {
                        leave.Leave_req_id = int.Parse(gvPendingRequest.Rows[i].Cells[1].Text);
                        leave.Vp_decision = dpHRDecision.SelectedValue.ToString();
                        leave.EmployeeLeaveVPDecision();
                        auditTrail.Emp_id = userSession;
                        auditTrail.AddAuditTrail("Declined " + gvPendingRequest.Rows[i].Cells[2].Text + " Leave Request");
                    }
                }
            }
            Response.Redirect("VPApproveLeaveRequest.aspx");
        }
    }
}