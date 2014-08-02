using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;
using DHELTASSys.AuditTrail;

namespace DHELTAFINALPROJECT.DHELTASV
{
    public partial class SVGenerateQuarterlyReport : System.Web.UI.Page
    {
        ReportsModuleBL report = new ReportsModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        string report_type;
        DateTime currentDate = DateTime.Now;
        int userSession;
        string quarter;

        DataTable dtActiveEmployees = new DataTable();
        DataTable dtEmployeeEvaluation = new DataTable();
        DataTable dtSelectEmployeeID_Supervisor = new DataTable();
        DataTable dtEmployeeAttendance_Supervisor = new DataTable();
        DataTable dtEvaluationStatusSupervisor = new DataTable();
        DataTable dtEvaluationStatusEmployee = new DataTable();
        DataTable dtReportStatusSupervisor = new DataTable();
        DataTable dtReportStatusID = new DataTable();
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
                    report.Report_year = DateTime.Now.Year;
                    report_type = dpReportType.Text;

                    if (currentDate.Month == 3 || currentDate.Month == 6 || currentDate.Month == 9 || currentDate.Month == 12)
                    {
                        if (currentDate.Month == 3)
                        {
                            quarter = "First";
                            dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_1Q();
                        }
                        if (currentDate.Month == 6)
                        {
                            quarter = "Second";
                            dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_2Q();
                        }
                        if (currentDate.Month == 9)
                        {
                            quarter = "Third";
                            dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_3Q();
                        }
                        if (currentDate.Month == 12)
                        {
                            quarter = "Fourth";
                            dtEmployeeAttendance_Supervisor = report.ViewEmployeeAttendance_Supervisor_4Q();
                        }
                        report.Report_quarter = quarter;
                        report.Report_year = DateTime.Now.Year;

                        //view active employees
                        dtActiveEmployees = report.ViewActiveEmployees();
                        gvActiveEmployees.DataSource = dtActiveEmployees;
                        gvActiveEmployees.DataBind();


                        //Employees' Evaluation ratings
                        dtEmployeeEvaluation = report.ViewEvaluationEmployees();

                        gvEmployeeAttendance.DataSource = dtEmployeeAttendance_Supervisor;
                        gvEmployeeAttendance.DataBind();

                        gvActiveEmployees.DataSource = dtActiveEmployees;
                        gvActiveEmployees.DataBind();

                        gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
                        gvEmployeeEvaluation.DataBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Generation of reports is prohibited at this time!');window.location='SVMainPage.aspx';</script>'");
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
            //dtActiveEmployees.TableName = "Active Employees";
            //dtEmployeeEvaluation.TableName = "Employee Evaluation";
            //dtEmployeeAttendance_Supervisor.TableName = "Employee Attendance";
            //dsReport.Tables.Add(dtActiveEmployees);
            //dsReport.Tables.Add(dtEmployeeEvaluation);
            //dsReport.Tables.Add(dtEmployeeAttendance_Supervisor);
            //string path = "" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "";
            //ExcelLibrary.DataSetHelper.CreateWorkbook(path + @"\" + quarter + " Quarter " + currentDate.Year + " Employee Report.xls", dsReport);
            //Response.Write("<script>alert('File saved at " + path + @" \ " + quarter + " Quarter " + currentDate.Year + " Employee Report.xls')</script>");
            //dtReportStatusSupervisor = report.ViewReportStatusSupervisor();
            //if (dtReportStatusSupervisor.Rows.Count == 0)
            //{
            //generateReportDate = DateTime.Parse(dtReportStatusSupervisor.Rows[0][0].ToString());
            report.Report_type = dpReportType.SelectedItem.Text;
            report.Supervisor_id = userSession;
            dtReportStatusID = report.SelectReportStatusID();
            if (dtReportStatusID.Rows.Count != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The latest type of report generated has not been assessed.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
            }
            else
            {
                if (report_type == "Attendance")
                {
                    if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an attendance report. The employees do not have attendance records.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                    else
                    {
                        report.AddReportStatusSupervisor();
                        auditTrail.Emp_id = userSession;
                        auditTrail.AddAuditTrail("Generate Attendance Report");
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Successfully generated a quarterly report!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                }
                else if (report_type == "Evaluation")
                {
                    if (dtEmployeeEvaluation.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could generate report. There are no existing evaluation made for the employees.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                    else
                    {
                        dtSelectEmployeeID_Supervisor = report.SelectEmployeeID_Supervisor();
                        dtEvaluationStatusEmployee = report.SelectEvaluationStatusEmployeeID();
                        if (dtSelectEmployeeID_Supervisor.Rows.Count == dtEvaluationStatusEmployee.Rows.Count)
                        {
                            report.AddReportStatusSupervisor();
                            auditTrail.Emp_id = userSession;
                            auditTrail.AddAuditTrail("Generate Evaluation Report");
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Successfully generated a quarterly report!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an evalution report. The evaluation of the employees handled by the supervisor is still incomplete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                        }
                    }
                }
                else
                {
                    if (dtEmployeeAttendance_Supervisor.Rows.Count == 0 || dtEmployeeEvaluation.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate a report. Either one of the report type has no record.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                    else
                    {
                        if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an attendance report. The employees do not have attendance records.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                        }
                        else
                        {
                            dtSelectEmployeeID_Supervisor = report.SelectEmployeeID_Supervisor();

                            dtEvaluationStatusEmployee = report.SelectEvaluationStatusEmployeeID();

                            if (dtSelectEmployeeID_Supervisor.Rows.Count == dtEvaluationStatusEmployee.Rows.Count)
                            {
                                report.AddReportStatusSupervisor();
                                auditTrail.Emp_id = userSession;
                                auditTrail.AddAuditTrail("Generate Attendance and Evaluation Report");
                                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Successfully generated a quarterly report!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an evaluation report. The evaluation of the employees handled by the supervisor is still incomplete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                            }
                        }
                    }
                }
            }
            //}
            //else
            //{
                //ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Already generated a quarterly report!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
            //}
        }

        protected void dpReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            report.Report_type = dpReportType.SelectedItem.Text;
            report.Supervisor_id = userSession;
            dtReportStatusID = report.SelectReportStatusID();
            if (dtReportStatusID.Rows.Count != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The latest type of report generated has not been assessed.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
            }
            else
            {
                if (report_type == "Attendance")
                {
                    if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an attendance report. The employees do not have attendance records.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                    else
                    {
                        gvEmployeeAttendance.Visible = true;
                        gvEmployeeEvaluation.Visible = false;
                        btnGenerateAttendanceReport.Enabled = true;
                        gvEmployeeAttendance.DataSource = dtEmployeeAttendance_Supervisor;
                        gvEmployeeAttendance.DataBind();
                    }
                }
                else if (report_type == "Evaluation")
                {
                    if (dtEmployeeEvaluation.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could generate report. There is no existing evaluation made for the employees.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                    else
                    {
                        dtSelectEmployeeID_Supervisor = report.SelectEmployeeID_Supervisor();
                        dtEvaluationStatusEmployee = report.SelectEvaluationStatusEmployeeID();
                        if (dtSelectEmployeeID_Supervisor.Rows.Count == dtEvaluationStatusEmployee.Rows.Count)
                        {
                            gvEmployeeEvaluation.Visible = true;
                            gvEmployeeAttendance.Visible = false;
                            btnGenerateAttendanceReport.Enabled = true;
                            gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
                            gvEmployeeEvaluation.DataBind();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate an evalution report. The evaluation of the employees handled by the supervisor is still incomplete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                        }
                    }
                }
                else
                {
                    if (dtEmployeeAttendance_Supervisor.Rows.Count == 0 || dtEmployeeEvaluation.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate a report. Either one of the report type has no record.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                    }
                    else
                    {
                        if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate a report. The employees do not have attendance records.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                        }
                        else
                        {
                            dtSelectEmployeeID_Supervisor = report.SelectEmployeeID_Supervisor();

                            dtEvaluationStatusEmployee = report.SelectEvaluationStatusEmployeeID();

                            if (dtSelectEmployeeID_Supervisor.Rows.Count == dtEvaluationStatusEmployee.Rows.Count)
                            {
                                //employee ratings
                                dtEmployeeEvaluation = report.ViewEvaluationEmployees();
                                gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
                                gvEmployeeEvaluation.DataBind();

                                //employees' attendance
                                gvEmployeeAttendance.DataSource = dtEmployeeAttendance_Supervisor;
                                gvEmployeeAttendance.DataBind();
                                btnGenerateAttendanceReport.Enabled = true;

                                gvEmployeeAttendance.Visible = true;
                                gvEmployeeEvaluation.Visible = true;
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could not generate a report. The evaluation of the employees handled by the supervisor is still incomplete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
                            }
                        }
                    }
                }
            }
        }

            ////////////////////////////////////////////////////////////////////////


        //    if (report_type == "Attendance")
        //    {
        //        //if (dtActiveEmployees.Rows.Count == 0)
        //        //{
        //        //    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The required details needed for the generation of the reports are not yet complete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
        //        //}
        //        //else
        //        //{
        //            if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
        //            {
        //                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The employees do not have attendance for this quarter.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
        //            }
        //            else
        //            {
        //                gvEmployeeAttendance.Visible = true;
        //                gvEmployeeEvaluation.Visible = false;
        //                btnGenerateAttendanceReport.Enabled = true;
        //                gvEmployeeAttendance.DataSource = dtEmployeeAttendance_Supervisor;
        //                gvEmployeeAttendance.DataBind();
        //            }
        //        //}
        //    }
        //    else if (report_type == "Evaluation")
        //    {
        //        //Employees' Evaluation ratings
        //        dtEmployeeEvaluation = report.ViewEvaluationEmployees();
        //        if (dtEmployeeEvaluation.Rows.Count == 0)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The required details needed for the generation of the reports are not yet complete!');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
        //        }
        //        else
        //        {
        //            gvEmployeeEvaluation.Visible = true;
        //            gvEmployeeAttendance.Visible = false;
        //            btnGenerateAttendanceReport.Enabled = true;
        //            gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
        //            gvEmployeeEvaluation.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        if (dtEmployeeAttendance_Supervisor.Rows.Count == 0)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could generate a report. The employees do not have attendance records. Please select the Evaluation Report.');window.location='SVGenerateQuarterlyReport.aspx';</script>'");
        //            btnGenerateAttendanceReport.Enabled = false;
        //        }
        //        else if (dtEmployeeEvaluation.Rows.Count == 0)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Could generate report. There are no existing evaluation made for the employees. Please select the Attendance Report.');window.location='SVMainPage.aspx';</script>'");
        //            btnGenerateAttendanceReport.Enabled = false;                
        //        }
        //        else
        //        {
        //            //employee ratings
        //            dtEmployeeEvaluation = report.ViewEvaluationEmployees();
        //            gvEmployeeEvaluation.DataSource = dtEmployeeEvaluation;
        //            gvEmployeeEvaluation.DataBind();

        //            //employees' attendance
        //            gvEmployeeAttendance.DataSource = dtEmployeeAttendance_Supervisor;
        //            gvEmployeeAttendance.DataBind();
        //            btnGenerateAttendanceReport.Enabled = true;

        //            gvEmployeeAttendance.Visible = true;
        //            gvEmployeeEvaluation.Visible = true;
        //        }
        //    }
        //}
    }
}