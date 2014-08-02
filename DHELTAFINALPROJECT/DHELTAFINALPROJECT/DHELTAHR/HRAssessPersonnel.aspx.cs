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
        string evaluatedPosition;
        string quarter;
        float evalScore;
        float evalScore_Sum;
        float evalScore_Total;
        float evalTotalQuestions;
        float evalTotalAverageScore;
        DateTime evalDate;
        DateTime currentDate = DateTime.Now;
        DataTable dtEvaluationStatusEmployee;
        DataTable dtEvaluationStatusSupervisor;
        DataTable dtEvaluationStatusSupervisor_Group;
        DataTable dtEvaluationAnswersEmployee;
        DataTable dtEvaluationAnswersSupervisor;
        DataTable dtSelectEmployeeID_Supervisor;
        DataTable dtEvaluatedPosition;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "HR Manager")
                {
                    if (currentDate.Month == 3 || currentDate.Month == 6 || currentDate.Month == 9 || currentDate.Month == 12)
                    {

                        userSession = int.Parse(Session["EmployeeID"].ToString());
                        companyPersonnel.Emp_id = userSession;

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

                        companyPersonnel.Eval_quarter = quarter;
                        companyPersonnel.Eval_year = DateTime.Now.Year;

                        dtEvaluationStatusEmployee = companyPersonnel.ViewEvaluationStatusEmployee_Assess();

                        dtEvaluationStatusSupervisor_Group = companyPersonnel.ViewEvaluationStatusSupervisor_Group_Assess();

                        if (dtEvaluationStatusEmployee.Rows.Count == 0 && dtEvaluationStatusSupervisor_Group.Rows.Count == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No pending evaluation to be assessed!');window.location='HRMainPage.aspx';</script>'");
                        }
                        else
                        {
                            gvEvaluationStatus_Group.Caption = "Supervisor Evaluation";
                            gvEvaluationStatus_Group.DataSource = dtEvaluationStatusSupervisor_Group;
                            gvEvaluationStatus_Group.DataBind();

                            gvEvaluationStatusEmployee.Caption = "Employee Evaluation";
                            gvEvaluationStatusEmployee.DataSource = dtEvaluationStatusEmployee;
                            gvEvaluationStatusEmployee.DataBind();

                            //gvCompanyEmployees.DataSource = companyPersonnel.SelectAllCompanyPersonnel();
                            //gvCompanyEmployees.DataBind();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Assessing the evaluation is prohibited at this time!');window.location='HRMainPage.aspx';</script>'");
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


        protected void gvEvaluationStatusEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[3].Text);
            companyPersonnel.Emp_evaluating_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[5].Text);
            companyPersonnel.Eval_date = DateTime.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[6].Text);

            dtEvaluatedPosition = companyPersonnel.SelectEmployee_Position();
            evaluatedPosition = dtEvaluatedPosition.Rows[0][0].ToString();

            gvEvaluationAnswers.Caption = "Evaluation Answers made for " + gvEvaluationStatusEmployee.SelectedRow.Cells[4].Text;
            gvEvaluationAnswers.DataSource = companyPersonnel.ViewEvaluationAnswersEmployee();
            gvEvaluationAnswers.DataBind();
            Clear_gvEvaluationStatusSupervisor(sender, e);
        }

        protected void gvEvaluationStatus_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[3].Text);

            dtEvaluatedPosition = companyPersonnel.SelectSupervisor_Position();
            evaluatedPosition = dtEvaluatedPosition.Rows[0][0].ToString();

            gvEvaluationStatusSupervisor.Caption = "Employees under the supervision of " + gvEvaluationStatus_Group.SelectedRow.Cells[4].Text;
            gvEvaluationStatusSupervisor.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor();
            gvEvaluationStatusSupervisor.DataBind();
            Clear_gvEvaluationAnswers(sender, e);
        }

        protected void gvEvaluationStatusSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[3].Text);
            companyPersonnel.Emp_evaluating_id = int.Parse(gvEvaluationStatusSupervisor.SelectedRow.Cells[3].Text);
            companyPersonnel.Eval_date = DateTime.Parse(gvEvaluationStatusSupervisor.SelectedRow.Cells[5].Text);

            gvEvaluationAnswers.DataSource = companyPersonnel.ViewEvaluationAnswersEmployee();
            gvEvaluationAnswers.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvEvaluationStatusEmployee.SelectedRow == null || gvEvaluationStatus_Group.SelectedRow == null)
            {
                if (gvEvaluationStatusEmployee.SelectedRow != null)
                {
                    companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[3].Text);
                    dtEvaluatedPosition = companyPersonnel.SelectEmployee_Position();
                    evaluatedPosition = dtEvaluatedPosition.Rows[0][0].ToString();
                    if (evaluatedPosition == "Employee")
                    {
                        companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[3].Text);
                        companyPersonnel.Emp_evaluating_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[5].Text);
                        companyPersonnel.Eval_date = DateTime.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[6].Text);
                        dtEvaluationStatusEmployee = companyPersonnel.ViewEvaluationStatusEmployee_Assess();
                        //dtEvaluationStatusEmployee = companyPersonnel.ViewEvaluationStatusEmployee();

                        if (dtEvaluationStatusEmployee.Rows[0][8].ToString() != "")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The selected employee has already been assessed!');window.location='HRAssessPersonnel.aspx';</script>'");
                        }
                        else
                        {
                            //companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[3].Text);
                            //companyPersonnel.Emp_evaluating_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[5].Text);
                            //companyPersonnel.Eval_date = DateTime.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[6].Text);

                            //string date = Session["Eval_date"].ToString();

                            //companyPersonnel.Eval_date = DateTime.Parse(date);

                            dtEvaluationAnswersEmployee = companyPersonnel.ViewEvaluationAnswersEmployee();
                            for (int index = 0; index < dtEvaluationAnswersEmployee.Rows.Count; index++)
                            {
                                evalScore = int.Parse(dtEvaluationAnswersEmployee.Rows[index][1].ToString());
                                evalScore_Sum = evalScore_Sum + evalScore;
                            }
                            evalTotalQuestions = dtEvaluationAnswersEmployee.Rows.Count;
                            evalScore_Total = evalTotalQuestions * 4;
                            evalTotalAverageScore = ((evalScore_Sum / evalScore_Total) * 100f);

                            companyPersonnel.Eval_status_id = int.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[0].Text);
                            companyPersonnel.Eval_score = evalTotalAverageScore;
                            companyPersonnel.AddAssessmentStatusEmployee();

                            auditTrail.Emp_id = userSession;
                            auditTrail.AddAuditTrail("Assess the Evaluation of the Employee");

                            Session.Remove("Evaluated_EmployeeID");
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully completed the assessment!');window.location='HRAssessPersonnel.aspx';</script>'");
                        }
                    }
                }
                else
                {
                    companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[3].Text);

                    dtEvaluatedPosition = companyPersonnel.SelectSupervisor_Position();
                    evaluatedPosition = dtEvaluatedPosition.Rows[0][0].ToString();

                    if (evaluatedPosition == "Supervisor")
                    {

                        companyPersonnel.Emp_evaluated_id = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[3].Text);

                        dtEvaluationStatusSupervisor_Group = companyPersonnel.ViewEvaluationStatusSupervisor_Group();
                        if (dtEvaluationStatusSupervisor_Group.Rows[0][5].ToString() != "")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The selected supervisor has already been assessed!');window.location='HRAssessPersonnel.aspx';</script>'");
                        }
                        else
                        {
                            //companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                            dtSelectEmployeeID_Supervisor = companyPersonnel.SelectEmployeeID_Supervisor();

                            companyPersonnel.Eval_quarter = gvEvaluationStatus_Group.SelectedRow.Cells[1].Text;
                            companyPersonnel.Eval_year = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[2].Text);
                            dtEvaluationStatusSupervisor = companyPersonnel.ViewEvaluationStatusSupervisor();

                            if (dtSelectEmployeeID_Supervisor.Rows.Count != dtEvaluationStatusSupervisor.Rows.Count)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The evaluation of the employees handled by the supervisor is still incomplete!');window.location='HRAssessPersonnel.aspx';</script>'");
                            }
                            else
                            {
                                //companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                                companyPersonnel.Eval_year = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[2].Text);
                                companyPersonnel.Eval_quarter = gvEvaluationStatus_Group.SelectedRow.Cells[1].Text;

                                dtEvaluationAnswersSupervisor = companyPersonnel.ViewEvaluationAnswersSupervisor();
                                //gvEmployeeEvaluationStatus.DataSource = companyPersonnel.ViewEvaluationAnswersSupervisor();
                                //gvEmployeeEvaluationStatus.DataBind();

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
        }

       

        protected void Clear_gvEvaluationStatusEmployee(object sender, EventArgs e)
        {
            companyPersonnel.Emp_evaluated_id = 0;
            companyPersonnel.Emp_evaluating_id = 0;
            companyPersonnel.Eval_date = DateTime.Parse(gvEvaluationStatusEmployee.SelectedRow.Cells[6].Text);
            dtEvaluationStatusEmployee = companyPersonnel.ViewEvaluationStatusEmployee_Assess();
            gvEvaluationStatusEmployee.DataSource = dtEvaluationStatusEmployee;
            gvEvaluationStatusEmployee.DataBind();
        }

        protected void Clear_gvEvaluationStatus_Group(object sender, EventArgs e)
        {
            companyPersonnel.Emp_selected_id = 0;
            gvEvaluationStatus_Group.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor_Group();
            gvEvaluationStatus_Group.DataBind();
        }

        protected void Clear_gvEvaluationStatusSupervisor(object sender, EventArgs e)
        {
            gvEvaluationStatusSupervisor.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor();
            gvEvaluationStatusSupervisor.DataBind();
        }

        protected void Clear_gvEvaluationAnswers(object sender, EventArgs e)
        {
            gvEvaluationAnswers.DataSource = companyPersonnel.ViewEvaluationAnswersEmployee();
            gvEvaluationAnswers.DataBind();
        }

        protected void gvEvaluationStatusEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEvaluationStatusEmployee, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvEvaluationStatus_Group_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEvaluationStatus_Group, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvEvaluationStatusSupervisor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEvaluationStatusSupervisor, "Select$" + e.Row.RowIndex);
        }
    }
}