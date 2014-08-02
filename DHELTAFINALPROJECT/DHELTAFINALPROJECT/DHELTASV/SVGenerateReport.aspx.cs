
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;
using DHELTASSys.AuditTrail;

namespace DHELTASSys
{
    public partial class GenerateReport : System.Web.UI.Page
    {
        ReportsModuleBL report = new ReportsModuleBL();
        LeaveModuleBL leave = new LeaveModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        DateTime currentDate = DateTime.Now;
        int userSession;
        string quarter;

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
                if (Session["Position"].ToString() == "Supervisor")
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    report.Emp_id = userSession;
                    report.Supervisor_id = userSession;

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

                    if (report.SelectGenerateReportDate().Rows.Count != 0)
                    {
                        DateTime latestReport = DateTime.Parse(report.SelectGenerateReportDate().Rows[0][0].ToString());
                        
                        if (latestReport.Month.ToString() == currentDate.Month.ToString() &&
                            latestReport.Year.ToString() == currentDate.Year.ToString())
                        {
                            btnGenerateReport.Enabled = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('Already generated a quarterly report!'); window.location='" + Request.ApplicationPath + "DHELTASV/SVMainPage.aspx';", true);
                        }
                    }
                    else
                    {
                        

                        report.Report_year = DateTime.Now.Year;

                        //Active Employee under the Supervisor
                        dtActiveEmployees = report.ViewActiveEmployees();

                        //Employees' Leave Details            
                        dtEmployeeLeave = report.ViewCurrentEmployeeLeaveBalance();

                        //Employees' Evaluation ratings
                        dtEmployeeEvaluation = report.ViewEvaluationEmployees();

                        //Employees' Offenses Details
                        dtEmployeeOffense = report.ViewEmployeeOffenses();

                        //Employees' Present
                        dtEmployeePresent = report.ViewDaysPresentCount();
                        

                        if (dtActiveEmployees.Rows.Count == 0 || dtEmployeeLeave.Rows.Count == 0 ||
                            dtEmployeeEvaluation.Rows.Count == 0 || dtEmployeeOffense.Rows.Count == 0 ||
                            dtEmployeePresent.Rows.Count == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The required details needed for the generation of the reports are not complete yet!');window.location='SVMainPage.aspx';</script>'");
                        }
                        else
                        {
                            gvActiveEmployees.DataSource = dtActiveEmployees;
                            gvActiveEmployees.DataBind();

                            gvEmployeeLeave.DataSource = dtEmployeeLeave;
                            gvEmployeeLeave.DataBind();

                            gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
                            gvEmployeeEvaluation.DataBind();

                            gvEmployeeOffense.DataSource = dtEmployeeOffense;
                            gvEmployeeOffense.DataBind();

                            gvEmployeePresent.DataSource = dtEmployeePresent;
                            gvEmployeePresent.DataBind();
                        }
                    }
                }
                else if (Session["Position"].ToString() == "Vice President")
                {
                    Response.Redirect("VPMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "HR Manager")
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

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            dtActiveEmployees.TableName = "Active Employees";
            dtEmployeeLeave.TableName = "Employee Leave Balance";
            dtEmployeeEvaluation.TableName = "Employee Evaluation";
            dtEmployeeOffense.TableName = "Employee Offense";
            dtEmployeePresent.TableName = "Employee Present Count";
            dsReport.Tables.Add(dtActiveEmployees);
            dsReport.Tables.Add(dtEmployeeLeave);
            dsReport.Tables.Add(dtEmployeeEvaluation);
            dsReport.Tables.Add(dtEmployeeOffense);
            dsReport.Tables.Add(dtEmployeePresent);
            string path = "" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "";
            ExcelLibrary.DataSetHelper.CreateWorkbook(path + @"\" + quarter + " Quarter " + currentDate.Year + " Employee Report.xls", dsReport);
            
            report.AddReportStatusSupervisor();

            auditTrail.Emp_id = userSession;
            auditTrail.AddAuditTrail("Generate Report");
            ScriptManager.RegisterStartupScript(this, this.GetType(), 
                "Redit", "alert('Successfully generated a quarterly report!'); window.location='" + 
                Request.ApplicationPath + "DHELTASV/SVMainPage.aspx';", true);
            Response.Write("<script>alert('File saved at "+ path + @" \ " + quarter + " Quarter " + currentDate.Year + " Employee Report.xls')</script>");
            leave.Emp_id = userSession;
            leave.ResetLeaveBalance();
        }
    }
}