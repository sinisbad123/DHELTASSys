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

namespace DHELTASSYSMEGABYTE
{
    public partial class HRAssessPersonnel : System.Web.UI.Page
    {
        EvaluationModuleBL companyPersonnel = new EvaluationModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();

        int userSession;
        string evaluatedEmpPosition;
        float evalScore;
        float evalScore_Sum;
        float evalScore_Total;
        float evalTotalQuestions;
        float evalTotalAverageScore;
        DateTime evalDate;

        DataTable dtEvaluationStatusEmployee;
        DataTable dtEvaluationStatusSupervisor_Group;
        DataTable dtEvaluationAnswersEmployee;
        DataTable dtEvaluationAnswersSupervisor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "HR Manager")
                {
                    
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    companyPersonnel.Emp_id = userSession;
                    gvCompanyEmployees.DataSource = companyPersonnel.SelectAllCompanyPersonnel();
                    gvCompanyEmployees.DataBind();
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

        protected void gvCompanyEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
            
            if (gvCompanyEmployees.SelectedRow.Cells[4].Text == "Employee")
            {
                companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                dtEvaluationStatusEmployee = companyPersonnel.ViewEvaluationStatusEmployee();
                if (dtEvaluationStatusEmployee.Rows.Count == 0)
                {
                    Response.Write("<script>alert('No evaluation made yet for the selected employee!')</script>");
                }
                else
                {
                    gvEmployeeEvaluationStatus.Caption = "Assessment Status of " + gvCompanyEmployees.SelectedRow.Cells[1].Text + ", "
                        + gvCompanyEmployees.SelectedRow.Cells[2].Text;
                    gvEmployeeEvaluationStatus.DataSource = companyPersonnel.ViewEvaluationStatusEmployee();
                    gvEmployeeEvaluationStatus.DataBind();
                    Clear_gvEvaluationStatus_Group(sender, e);
                }
            }
            else if (gvCompanyEmployees.SelectedRow.Cells[4].Text == "Supervisor")
            {
                companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                dtEvaluationStatusSupervisor_Group = companyPersonnel.ViewEvaluationStatusSupervisor_Group();
                if (dtEvaluationStatusSupervisor_Group.Rows.Count == 0)
                {
                    Response.Write("<script>alert('No evaluation made yet for the selected supervisor!')</script>");
                }
                else
                {
                    gvEvaluationStatus_Group.Caption = "Assessment Status of " + gvCompanyEmployees.SelectedRow.Cells[1].Text + ", "
                        + gvCompanyEmployees.SelectedRow.Cells[2].Text;
                    gvEvaluationStatus_Group.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor_Group();
                    gvEvaluationStatus_Group.DataBind();
                    Clear_gvEmployeeEvaluationStatus(sender, e);
                }
            }
            Clear_gvEvaluationAnswers(sender, e);
        }

        protected void gvEmployeeEvaluationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            evaluatedEmpPosition = gvCompanyEmployees.SelectedRow.Cells[4].Text;
            if (evaluatedEmpPosition == "Employee")
            {
                gvEvaluationAnswers.Caption = "Evaluation Answers made by " + gvEmployeeEvaluationStatus.SelectedRow.Cells[3].Text
                    + " for " + gvEmployeeEvaluationStatus.SelectedRow.Cells[1].Text + " Quarter, " + gvEmployeeEvaluationStatus.SelectedRow.Cells[2].Text;
                evalDate = DateTime.Parse(gvEmployeeEvaluationStatus.SelectedRow.Cells[6].Text);

                companyPersonnel.Emp_evaluating_id = int.Parse(gvEmployeeEvaluationStatus.SelectedRow.Cells[4].Text);
            }
            else if (evaluatedEmpPosition == "Supervisor")
            {
                gvEvaluationAnswers.Caption = "Evaluation Answers made by " + gvEmployeeEvaluationStatus.SelectedRow.Cells[2].Text;
                evalDate = DateTime.Parse(gvEmployeeEvaluationStatus.SelectedRow.Cells[5].Text);
                companyPersonnel.Emp_evaluating_id = int.Parse(gvEmployeeEvaluationStatus.SelectedRow.Cells[3].Text);
            }
            string converted = evalDate.ToString("M-d-yyyy hh:mm:ss");
            evalDate = DateTime.Parse(converted);

            Session.Add("Eval_date", evalDate);

            companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
            companyPersonnel.Eval_date = evalDate;
            gvEvaluationAnswers.DataSource = companyPersonnel.ViewEvaluationAnswersEmployee();
            gvEvaluationAnswers.DataBind();
        }

        protected void gvEvaluationStatus_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyPersonnel.Eval_quarter = gvEvaluationStatus_Group.SelectedRow.Cells[1].Text;
            companyPersonnel.Eval_year = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[2].Text);
            gvEmployeeEvaluationStatus.Caption = "Evaluators of " + gvCompanyEmployees.SelectedRow.Cells[1].Text
                + ", " + gvCompanyEmployees.SelectedRow.Cells[2].Text + " for " + gvEvaluationStatus_Group.SelectedRow.Cells[1].Text
                + " Quarter, " + gvEvaluationStatus_Group.SelectedRow.Cells[2].Text;
            gvEmployeeEvaluationStatus.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor();
            gvEmployeeEvaluationStatus.DataBind();
            Clear_gvEvaluationAnswers(sender, e);
            Clear();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvCompanyEmployees.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Please select first a personnel for the assessment.');window.location='HRAssessPersonnel.aspx';</script>'");   
            }
            else
            {
                evaluatedEmpPosition = gvCompanyEmployees.SelectedRow.Cells[4].Text;
                companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                if (evaluatedEmpPosition == "Employee")
                {
                    if (gvEmployeeEvaluationStatus.SelectedRow == null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Please select first the assessment status of the employee.');window.location='HRAssessPersonnel.aspx';</script>'");   
                    }
                    else
                    {
                        dtEvaluationStatusEmployee = companyPersonnel.ViewEvaluationStatusEmployee();
                        if (dtEvaluationStatusEmployee.Rows[0][7].ToString() != "" &&
                            dtEvaluationStatusEmployee.Rows[0][8].ToString() != "" &&
                            dtEvaluationStatusEmployee.Rows[0][9].ToString() != "")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The selected employee has already been assessed!');window.location='HRAssessPersonnel.aspx';</script>'");   
                        }
                        else
                        {
                            companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                            companyPersonnel.Emp_evaluating_id = int.Parse(gvEmployeeEvaluationStatus.SelectedRow.Cells[4].Text);
                            companyPersonnel.Eval_date = DateTime.Parse(gvEmployeeEvaluationStatus.SelectedRow.Cells[6].Text);

                            string date = Session["Eval_date"].ToString();

                            companyPersonnel.Eval_date = DateTime.Parse(date);

                            dtEvaluationAnswersEmployee = companyPersonnel.ViewEvaluationAnswersEmployee();
                            for (int index = 0; index < dtEvaluationAnswersEmployee.Rows.Count; index++)
                            {
                                evalScore = int.Parse(dtEvaluationAnswersEmployee.Rows[index][1].ToString());
                                evalScore_Sum = evalScore_Sum + evalScore;
                            }
                            evalTotalQuestions = dtEvaluationAnswersEmployee.Rows.Count;
                            evalScore_Total = evalTotalQuestions * 4;
                            evalTotalAverageScore = ((evalScore_Sum / evalScore_Total) * 100f);

                            companyPersonnel.Eval_status_id = int.Parse(gvEmployeeEvaluationStatus.SelectedRow.Cells[0].Text);
                            companyPersonnel.Eval_score = evalTotalAverageScore;
                            companyPersonnel.AddAssessmentStatusEmployee();

                            auditTrail.Emp_id = userSession;
                            auditTrail.AddAuditTrail("Assess the Evaluation of the Employee");

                            Session.Remove("Evaluated_EmployeeID");
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully completed the assessment!');window.location='HRAssessPersonnel.aspx';</script>'");
                        }
                    }
                }
                else if (evaluatedEmpPosition == "Supervisor")
                {
                    if (gvEvaluationStatus_Group.SelectedRow == null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Please select first the assessment status of the supervisor.');window.location='HRAssessPersonnel.aspx';</script>'");   
                    }
                    else
                    {
                        dtEvaluationStatusSupervisor_Group = companyPersonnel.ViewEvaluationStatusSupervisor_Group();
                        if (dtEvaluationStatusSupervisor_Group.Rows[0][3].ToString() != "" &&
                            dtEvaluationStatusSupervisor_Group.Rows[0][4].ToString() != "" &&
                            dtEvaluationStatusSupervisor_Group.Rows[0][5].ToString() != "")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The selected supervisor has already been assessed!');window.location='HRAssessPersonnel.aspx';</script>'");   
                        }
                        else
                        {
                            companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                            companyPersonnel.Eval_year = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[2].Text);
                            companyPersonnel.Eval_quarter = gvEvaluationStatus_Group.SelectedRow.Cells[1].Text;

                            dtEvaluationAnswersSupervisor = companyPersonnel.ViewEvaluationAnswersSupervisor();
                            gvEmployeeEvaluationStatus.DataSource = companyPersonnel.ViewEvaluationAnswersSupervisor();
                            gvEmployeeEvaluationStatus.DataBind();

                            for (int index = 0; index < dtEvaluationAnswersSupervisor.Rows.Count; index++)
                            {
                                evalScore = int.Parse(dtEvaluationAnswersSupervisor.Rows[index][1].ToString());
                                evalScore_Sum = evalScore_Sum + evalScore;
                            }
                            evalTotalQuestions = int.Parse(dtEvaluationAnswersSupervisor.Rows.Count.ToString());
                            evalScore_Total = evalTotalQuestions * 4;
                            evalTotalAverageScore = ((evalScore_Sum / evalScore_Total) * 100);

                            companyPersonnel.Eval_status_id = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[0].Text);
                            companyPersonnel.Eval_score = evalTotalAverageScore;

                            companyPersonnel.AddAssessmentStatusSupervisor_Group();

                            auditTrail.Emp_id = userSession;
                            auditTrail.AddAuditTrail("Assess the Evaluation of the Supervisor");

                            Session.Remove("Evaluated_EmployeeID");
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully completed the assessment!');window.location='HRAssessPersonnel.aspx';</script>'");
                        }
                    }
                }
            }
        }

        protected void Clear_gvCompanyEmployees(object sender, EventArgs e)
        {
            companyPersonnel.Emp_id = 0;
            gvCompanyEmployees.DataSource = companyPersonnel.SelectAllCompanyPersonnel();
            gvCompanyEmployees.DataBind();
        }

        protected void Clear_gvEvaluationAnswers(object sender, EventArgs e)
        {
            companyPersonnel.Emp_evaluated_id = 0;
            companyPersonnel.Emp_evaluating_id = 0;
            gvEvaluationAnswers.DataSource = companyPersonnel.ViewEvaluationAnswersEmployee();
            gvEvaluationAnswers.DataBind();
        }

        protected void Clear_gvEmployeeEvaluationStatus(object sender, EventArgs e)
        {
            companyPersonnel.Emp_selected_id = 0;
            gvEmployeeEvaluationStatus.DataSource = companyPersonnel.ViewEvaluationStatusEmployee();
            gvEmployeeEvaluationStatus.DataBind();
        }

        protected void Clear_gvEvaluationStatus_Group(object sender, EventArgs e)
        {
            companyPersonnel.Emp_selected_id = 0;
            gvEvaluationStatus_Group.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor_Group();
            gvEvaluationStatus_Group.DataBind();
            Clear();
        }

        private void Clear()
        {
            lblNotification.Text = "";
            btnSubmit.Visible = true;
        }

        protected void gvCompanyEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvCompanyEmployees, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvEmployeeEvaluationStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeEvaluationStatus, "Select$" + e.Row.RowIndex);
        }

        protected void gvEvaluationStatus_Group_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEvaluationStatus_Group, "Select$" + e.Row.RowIndex);
        }
    }
}