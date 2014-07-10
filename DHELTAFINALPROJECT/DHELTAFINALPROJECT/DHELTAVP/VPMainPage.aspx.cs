using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using DHELTASSys.modules;
using DHELTASSYS.DataAccess;

namespace DHELTAFINALPROJECT.DHELTAVP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LeaveModuleBL leave = new LeaveModuleBL();
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
                leave.Emp_id = userSession;
                if (!IsPostBack)
                {
                    dpLeaveType.DataSource = leave.SelectEmployeeLeaveTypeEmployeeID();
                    dpLeaveType.DataTextField = "Leave Type";
                    dpLeaveType.DataValueField = "ID";
                    dpLeaveType.DataBind();

                    gvBalance.DataSource = leave.ViewLeaveBalance();
                    gvBalance.DataBind();

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtStartingDate.Text == "" || txtEndingDate.Text == "" || txtReason.Text == "")
            {
                Response.Write("<script>alert('Complete all the fields')</script>");
            }
            else
            {
                leave.Emp_id = userSession;
                DateTime dateStart = DateTime.Parse(txtStartingDate.Text);
                DateTime dateEnd = DateTime.Parse(txtEndingDate.Text);
                DataTable dtLatestLeaveRequest = leave.ViewLatestLeaveRequest();
                if (dtLatestLeaveRequest.Rows.Count >= 1)
                {
                    DateTime latestEndDate = DateTime.Parse(dtLatestLeaveRequest.Rows[0][2].ToString());
                    if (dateStart.Date > latestEndDate)
                    {
                        if (dateStart.Date <= dateEnd.Date)
                        {
                            if (dtLatestLeaveRequest.Rows[0][4].ToString() == "")
                            {
                                Response.Write("<script>alert('Still Have Pending Leave Request')</script>");
                                Response.Redirect("HRMainPage.aspx");
                            }
                            else
                            {
                                leave.Leave_type_id = int.Parse(dpLeaveType.SelectedValue);
                                leave.Emp_id = userSession;
                                leave.Date_from = dateStart.ToShortDateString();
                                leave.Date_to = dateEnd.ToShortDateString();
                                leave.Reason = txtReason.Text;
                                leave.AddLeaveRequest();

                                txtStartingDate.Text = "";
                                txtEndingDate.Text = "";
                                txtReason.Text = "";

                                Response.Redirect("HRMainPage.aspx");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('End date must be on or after the start date')</script>");
                            txtEndingDate.Text = "";
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Start date must be later than your end date on your latest leave request')</script>");
                        txtStartingDate.Text = "";
                        txtEndingDate.Text = "";
                    }

                }
                else
                {
                    if (dateStart.Date > DateTime.Now.Date)
                    {
                        if (dateStart.Date <= dateEnd.Date)
                        {

                            leave.Leave_type_id = int.Parse(dpLeaveType.SelectedValue);
                            leave.Emp_id = userSession;
                            leave.Date_from = dateStart.ToShortDateString();
                            leave.Date_to = dateEnd.ToShortDateString();
                            leave.Reason = txtReason.Text;
                            leave.AddLeaveRequest();

                            txtStartingDate.Text = "";
                            txtEndingDate.Text = "";
                            txtReason.Text = "";

                            Response.Redirect("HRMainPage.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('End date must be on or after the start date')</script>");
                            txtEndingDate.Text = "";
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Start date must be later than today')</script>");
                        txtStartingDate.Text = "";
                        txtEndingDate.Text = "";
                    }
                }
            }
        }
    }
}