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
using DHELTASSys.AuditTrail;
using System.Globalization;

namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class HRAssessReport : System.Web.UI.Page
    {
        ReportsModuleBL report = new ReportsModuleBL();
        LeaveModuleBL leave = new LeaveModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        DateTime currentDate = DateTime.Now;
        int userSession;
        string quarter;

        DataTable dtReportStatus = new DataTable();
        DataTable dtActiveEmployees = new DataTable();
        DataTable dtEmployeeLeave = new DataTable();
        DataTable dtEmployeeEvaluation = new DataTable();
        DataTable dtEmployeeOffense = new DataTable();
        DataTable dtEmployeePresent = new DataTable();
        DataTable dtEmployeeAttendanceRating = new DataTable();
        DataSet dsReport = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "HR Manager")
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    report.Emp_id = userSession;
                    if (currentDate.Month == 3 || currentDate.Month == 6 || currentDate.Month == 9 || currentDate.Month == 12)
                    {
                        if (currentDate.Month == 3)
                        {
                            quarter = "First";
                        }
                        if (currentDate.Month == 6)
                        {
                            quarter = "Second";
                        }
                        if (currentDate.Month == 9)
                        {
                            quarter = "Third";
                        }
                        if (currentDate.Month == 12)
                        {
                            quarter = "Fourth";
                        }
                        report.Report_quarter = quarter;
                    }

                    report.Report_year = DateTime.Now.Year;

                    //Report Status
                    dtReportStatus = report.ViewReportStatusHRManager();
                    if (dtReportStatus.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No available report to be assessed!');window.location='HRMainPage.aspx';</script>'");                       
                    }
                    else
                    {
                        gvReportStatus.DataSource = dtReportStatus;
                        gvReportStatus.DataBind();
                    }
                }
                else if (Session["Position"].ToString() == "Vice President")
                {
                    Response.Redirect("VPMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Supervisor")
                {
                    Response.Redirect("SVMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Employee")
                {
                    Response.Redirect("EmployeeMainPage.aspx");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void gvReportStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            report.Supervisor_id = int.Parse(gvReportStatus.SelectedRow.Cells[3].Text);

            //Active Employee under the Supervisor
            dtActiveEmployees = report.ViewActiveEmployees();
            gvActiveEmployees.DataSource = dtActiveEmployees;
            gvActiveEmployees.DataBind();

            //Employees' Leave Details            
            dtEmployeeLeave = report.ViewCurrentEmployeeLeaveBalance();
            gvEmployeeLeave.DataSource = dtEmployeeLeave;
            gvEmployeeLeave.DataBind();

            //Employees' Evaluation ratings
            dtEmployeeEvaluation = report.ViewEvaluationEmployees();
            gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
            gvEmployeeEvaluation.DataBind();

            //Employees' Offenses Details
            dtEmployeeOffense = report.ViewEmployeeOffenses();
            gvEmployeeOffense.DataSource = dtEmployeeOffense;
            gvEmployeeOffense.DataBind();

            //Employees' Present
            dtEmployeePresent = report.ViewDaysPresentCount();
            gvEmployeePresent.DataSource = dtEmployeePresent;
            gvEmployeePresent.DataBind();
        }

        protected void gvReportStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvReportStatus, "Select$" + e.Row.RowIndex);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvReportStatus.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Please select one from the list for the assessment.');window.location='HRAssessReport.aspx';</script>'");
            }
            else
            {
                if (dtReportStatus.Rows[0][6].ToString() != "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The selected report has already been assessed.');window.location='HRAssessReport.aspx';</script>'");
                }
                else
                {
                    report.Report_id = int.Parse(gvReportStatus.SelectedRow.Cells[0].Text);
                    report.AddReportStatusHRManager();
                    auditTrail.Emp_id = userSession;
                    auditTrail.AddAuditTrail("Assess Report");
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully completed the assessment of the report!');window.location='HRMainPage.aspx';</script>'");
                }
            }
        }
    }
}