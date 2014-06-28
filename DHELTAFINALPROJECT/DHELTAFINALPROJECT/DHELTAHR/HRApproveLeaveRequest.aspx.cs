using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;
using DHELTASSys.AuditTrail;


namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm9 : System.Web.UI.Page
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
                if (Session["Position"].ToString() == "HR Manager")
                {
                    if (!IsPostBack)
                    {
                        leave.Emp_id = userSession;
                        gvPendingRequest.DataSource = leave.ViewHRLeaveRequest();
                        gvPendingRequest.DataBind();
                        if (gvPendingRequest.Rows.Count <= 0)
                        {
                            //lblNoHRPending.Visible = true;
                            dpHRDecision.Enabled = false;
                            btnSubmit.Enabled = false;
                        }
                        else
                        {
                            //lblNoHRPending.Visible = false;
                        }
                    }
                }
                else if (Session["Position"].ToString() == "Vice President")
                {
                    Response.Redirect(@"~/VicePresident.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvPendingRequest.Rows.Count; i++)
            {
                CheckBox chkHRSelected = (CheckBox)gvPendingRequest.Rows[i].Cells[0].FindControl("chkRequests");
                if (chkHRSelected.Checked)
                {
                    if (dpHRDecision.SelectedItem.Text == "Approve")
                    {
                        leave.Leave_req_id = int.Parse(gvPendingRequest.Rows[i].Cells[1].Text);
                        leave.Hr_manager_decision = dpHRDecision.SelectedValue.ToString();
                        leave.EmployeeLeaveHRDecision();

                        auditTrail.Emp_id = userSession;
                        auditTrail.AddAuditTrail("Approved " + gvPendingRequest.Rows[i].Cells[2].Text + " Leave Request");
                    }
                    else
                    {
                        leave.Leave_req_id = int.Parse(gvPendingRequest.Rows[i].Cells[1].Text);//int.Parse(gr.Cells[1].Text);  int.Parse(dgvHRDecision.SelectedRow.Cells[1].Text)
                        leave.Hr_manager_decision = dpHRDecision.SelectedValue.ToString();
                        leave.EmployeeLeaveHRDecision();

                        leave.Vp_decision = dpHRDecision.SelectedValue.ToString();
                        leave.EmployeeLeaveVPDecision();

                        auditTrail.Emp_id = userSession;
                        auditTrail.AddAuditTrail("Declined " + gvPendingRequest.Rows[i].Cells[2].Text + " Leave Request");
                    }
                }
            }
            Response.Redirect("HRApproveLeaveRequest.aspx");
        }
    }
}