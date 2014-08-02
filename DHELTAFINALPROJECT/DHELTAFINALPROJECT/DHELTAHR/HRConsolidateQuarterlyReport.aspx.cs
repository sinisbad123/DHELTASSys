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
    public partial class HRConsolidateQuarterlyReport : System.Web.UI.Page
    {
        ReportsModuleBL report = new ReportsModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        LeaveModuleBL leave = new LeaveModuleBL();
        DateTime currentDate = DateTime.Now;
        
        int userSession;
        string quarter;
        string report_type;

        DataTable dtReportStatus = new DataTable();
        DataTable dtActiveEmployees = new DataTable();
        DataTable dtEmployeeEvaluation = new DataTable();
        DataTable dtEmployeeAttendance_Supervisor = new DataTable();
        DataTable dtViewReportStatusHRManagerID = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "HR Manager")
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    report.Emp_id = userSession;
                    report.Report_year = DateTime.Now.Year;
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

                        //Report Status
                        dtReportStatus = report.ViewReportStatusHRManager();
                        if (dtReportStatus.Rows.Count == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No pending report to be assessed!');window.location='HRMainPage.aspx';</script>'");                       
                        }
                        else
                        {
                            gvReportStatus.DataSource = dtReportStatus;
                            gvReportStatus.DataBind();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Assessing the report is prohibited at this time!');window.location='HRMainPage.aspx';</script>'");
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

            report_type = gvReportStatus.SelectedRow.Cells[7].Text;
            report.Report_type = report_type;
            report.Supervisor_id = int.Parse(gvReportStatus.SelectedRow.Cells[3].Text);
            if (currentDate.Month == 3)
            {
                dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_1Q();
            }
            if (currentDate.Month == 6)
            {
                dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_2Q();
            }
            if (currentDate.Month == 9)
            {
                dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_3Q();
            }
            if (currentDate.Month == 12)
            {
                dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_4Q();
            }

            //Active Employee under the Supervisor
            dtActiveEmployees = report.ViewActiveEmployees();
            gvActiveEmployees.DataSource = dtActiveEmployees;
            gvActiveEmployees.DataBind();

            //employee ratings
            dtEmployeeEvaluation = report.ViewEvaluationEmployees();
            if (report_type == "Attendance")
            {
                if (dtActiveEmployees.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The required details needed for the generation of the reports are not yet complete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                }
                else
                {
                    if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The employees do not have attendance for this quarter!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                    else
                    {
                        gvEmployeeAttendance.Visible = true;
                        gvEmployeeEvaluation.Visible = false;
                        gvEmployeeAttendance.DataSource = dtEmployeeAttendance_Supervisor;
                        gvEmployeeAttendance.DataBind();
                    }
                }
            }
            else if (report_type == "Evaluation")
            {
                //Employees' Evaluation ratings
                dtEmployeeEvaluation = report.ViewEvaluationEmployees();
                if (dtEmployeeEvaluation.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The required details needed for the generation of the reports are not yet complete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                }
                else
                {
                    gvEmployeeEvaluation.Visible = true;
                    gvEmployeeAttendance.Visible = false;
                    gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
                    gvEmployeeEvaluation.DataBind();
                }
            }
            else
            {
                if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an attendance report. The employees do not have attendance records. Please select the Evaluation Report.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                }
                else if (dtEmployeeEvaluation.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an evaluation report. There are no existing evaluation for the employees. Please select the Attendance Report.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");               
                }
                else
                {
                    //employee ratings
                    dtEmployeeEvaluation = report.ViewEvaluationEmployees();
                    gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
                    gvEmployeeEvaluation.DataBind();

                    //employees' attendance
                    gvEmployeeAttendance.DataSource = dtEmployeeAttendance_Supervisor;
                    gvEmployeeAttendance.DataBind();

                    gvEmployeeAttendance.Visible = true;
                    gvEmployeeEvaluation.Visible = true;
                }
            }
    }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvReportStatus.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Please select one from the list for the assessment.');window.location='HRConsolidateQuarterlyReport.aspx';</script>'");
            }
            else
            {
                report.Report_id = int.Parse(gvReportStatus.SelectedRow.Cells[0].Text);
                dtViewReportStatusHRManagerID = report.ViewReportStatusHRManagerID();
                if (dtViewReportStatusHRManagerID.Rows[0][0].ToString() == "")
                {
                    report.Report_id = int.Parse(gvReportStatus.SelectedRow.Cells[0].Text);
                    report.AddReportStatusHRManager();
                    leave.Emp_id = userSession;
                    leave.ResetLeaveBalance();
                    auditTrail.Emp_id = userSession;
                    auditTrail.AddAuditTrail("Assess Quarterly Report");
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully completed the assessment of the report!');window.location='HRConsolidateQuarterlyReport.aspx';</script>'");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The selected report has already been assessed.');window.location='HRConsolidateQuarterlyReport.aspx';</script>'");

                }
            }
        }


        protected void gvReportStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvReportStatus, "Select$" + e.Row.RowIndex);
            }
        }
    }
}