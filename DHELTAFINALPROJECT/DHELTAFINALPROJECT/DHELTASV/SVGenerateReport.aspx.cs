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

        int attendance;
        float present;
        float late;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "Supervisor")
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
                        report.Eval_quarter = quarter;
                        
                    }

                    if (report.SelectGenerateReportDate().Rows.Count >= 1)
                    {
                        DateTime latestReport = DateTime.Parse(report.SelectGenerateReportDate().Rows[0][0].ToString());
                        if (latestReport.ToString("MM-yyyy") == currentDate.ToString("MM-yyyy"))
                        {
                            btnGenerateReport.Enabled = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "Redit", "alert('Already generated a quarterly report!'); window.location='" +
                                Request.ApplicationPath + "SVMainPage.aspx';", true);
                        }
                    }

                    dtEmployeeAttendanceRating.Columns.Add("Employee ID");
                    dtEmployeeAttendanceRating.Columns.Add("Attendance Rating");

                    report.Eval_year = DateTime.Now.Year;
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

                    if (report.SelectGenerateReportDate().Rows.Count >= 1)
                    {
                        //dtEmployeeOffense = report.ViewEmployeeOffenses();
                        dtEmployeePresent = report.ViewDaysPresentCountDate();
                        //gvEmployeeOffense.DataSource = dtEmployeeOffense;
                        gvEmployeePresent.DataSource = dtEmployeePresent;

                        if (report.ViewAttendanceCountDate().Rows.Count >= 1)
                        {
                            for (int employees = 0; employees < report.ViewAttendanceCountDate().Rows.Count; employees++)
                            {
                                attendance = int.Parse(report.ViewAttendanceCountDate().Rows[employees][1].ToString());

                                for (int empPresent = 0; empPresent < report.ViewDaysPresentCountDate().Rows.Count; empPresent++)
                                {
                                    if (report.ViewDaysPresentCountDate().Rows[empPresent][0].ToString() == report.ViewAttendanceCountDate().Rows[employees][0].ToString())
                                    {
                                        present = float.Parse(report.ViewDaysPresentCountDate().Rows[empPresent][1].ToString());
                                        break;
                                    }
                                    present = 0;
                                }

                                for (int empLate = 0; empLate < report.ViewDaysLateCountDate().Rows.Count; empLate++)
                                {
                                    if (report.ViewDaysLateCountDate().Rows[empLate][0].ToString() == report.ViewAttendanceCountDate().Rows[employees][0].ToString())
                                    {
                                        late = float.Parse(report.ViewDaysLateCountDate().Rows[empLate][1].ToString());
                                        break;
                                    }
                                    late = 0;
                                }

                                double rating = (((present + (late / 2)) / attendance) * 100);

                                dtEmployeeAttendanceRating.Rows.Add(report.ViewAttendanceCountDate().Rows[employees][0].ToString(), rating + "%");
                            }

                            gvEmployeeAttendance.DataSource = dtEmployeeAttendanceRating;
                        }

                        //gvEmployeeOffense.DataBind();
                        gvEmployeePresent.DataBind();
                        gvEmployeeAttendance.DataBind();
                    }
                    else
                    {
                        //dtEmployeeOffense = report.ViewOffensesCount();
                        dtEmployeePresent = report.ViewDaysPresentCount();
                        //gvEmployeeOffense.DataSource = dtEmployeeOffense;
                        gvEmployeePresent.DataSource = dtEmployeePresent;

                        if (report.ViewAttendanceCount().Rows.Count >= 1)
                        {
                            for (int employees = 0; employees < report.ViewAttendanceCount().Rows.Count; employees++)
                            {
                                attendance = int.Parse(report.ViewAttendanceCount().Rows[employees][1].ToString());

                                for (int empPresent = 0; empPresent < report.ViewDaysPresentCount().Rows.Count; empPresent++)
                                {
                                    if (report.ViewDaysPresentCount().Rows[empPresent][0].ToString() == report.ViewAttendanceCount().Rows[employees][0].ToString())
                                    {
                                        present = float.Parse(report.ViewDaysPresentCount().Rows[empPresent][1].ToString());
                                        break;
                                    }
                                    present = 0;
                                }

                                for (int empLate = 0; empLate < report.ViewDaysLateCount().Rows.Count; empLate++)
                                {
                                    if (report.ViewDaysLateCount().Rows[empLate][0].ToString() == report.ViewAttendanceCount().Rows[employees][0].ToString())
                                    {
                                        late = float.Parse(report.ViewDaysLateCount().Rows[empLate][1].ToString());
                                        break;
                                    }
                                    late = 0;
                                }

                                double rating = (((present + (late / 2)) / attendance) * 100);

                                dtEmployeeAttendanceRating.Rows.Add(report.ViewAttendanceCount().Rows[employees][0].ToString(), rating + "%");
                            }
                            gvEmployeeAttendance.DataSource = dtEmployeeAttendanceRating;
                        }
                        //gvEmployeeOffense.DataBind();
                        gvEmployeePresent.DataBind();
                        gvEmployeeAttendance.DataBind();
                    }
                    //gvEmployeeEvaluation.DataBind();
                    //gvActiveEmployees.DataBind();
                    //gvEmployeeLeave.DataBind();
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
            dtEmployeeAttendanceRating.TableName = "Employee Attendance Rating";
            dsReport.Tables.Add(dtActiveEmployees);
            dsReport.Tables.Add(dtEmployeeLeave);
            dsReport.Tables.Add(dtEmployeeEvaluation);
            dsReport.Tables.Add(dtEmployeeOffense);
            dsReport.Tables.Add(dtEmployeePresent);
            dsReport.Tables.Add(dtEmployeeAttendanceRating);
            string path = "" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "";
            //ExcelLibrary.DataSetHelper.CreateWorkbook(path + @"\" + quarter + " Quarter " + currentDate.Year + " Employee Report.xls", dsReport);

            //auditTrail.Emp_id = userSession;
            //auditTrail.AddAuditTrail("Generate Report");
            ScriptManager.RegisterStartupScript(this, this.GetType(), 
                "Redit", "alert('Successfully generated a quarterly report!'); window.location='" + 
                Request.ApplicationPath + "SVMainPage.aspx';", true);
            //Response.Write("<script>alert('File saved at "+ path + @" \ " + quarter + " Quarter " + currentDate.Year + " Employee Report.xls')</script>");
        }
    }
}