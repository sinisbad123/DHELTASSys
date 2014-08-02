using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;

namespace DHELTASSYSMEGABYTE
{
    public partial class HREvaluationSummary : System.Web.UI.Page
    {
        EvaluationModuleBL companyPersonnel = new EvaluationModuleBL();

        int userSession;
        string evaluatedEmpPosition;
        DateTime evalDate;
        DateTime currentDate = DateTime.Now;
        DataTable dtEvaluationStatusEmployee;
        DataTable dtEvaluationStatusSupervisor;
        DataTable dtEvaluationStatusSupervisor_Group;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "HR Manager")
                {
                    //if (currentDate.Month == 3 || currentDate.Month == 6 || currentDate.Month == 9 || currentDate.Month == 12)
                    //{
                        userSession = int.Parse(Session["EmployeeID"].ToString());
                        companyPersonnel.Emp_id = userSession;
                        gvCompanyEmployees.DataSource = companyPersonnel.SelectAllCompanyPersonnel();
                        gvCompanyEmployees.DataBind();
                    //}
                    //else
                    //{
                    //    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('This page is inaccessible as of now.');window.location='HRMainPage.aspx';</script>'");
                    //}
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
                dtEvaluationStatusEmployee = companyPersonnel.ViewEvaluationStatusEmployeeAnnual();
                if (dtEvaluationStatusEmployee.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No evaluation records for the selected employee!');window.location='HREvaluationSummary.aspx';</script>'");
                }
                else
                {
                    gvEmployeeEvaluationStatus.Caption = "Assessment Status of " + gvCompanyEmployees.SelectedRow.Cells[1].Text + ", "
                        + gvCompanyEmployees.SelectedRow.Cells[2].Text;
                    gvEmployeeEvaluationStatus.DataSource = companyPersonnel.ViewEvaluationStatusEmployeeAnnual();
                    gvEmployeeEvaluationStatus.DataBind();
                    Clear_gvEvaluationStatus_Group(sender, e);
                }
            }
            else if (gvCompanyEmployees.SelectedRow.Cells[4].Text == "Supervisor")
            {
                companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
                dtEvaluationStatusSupervisor_Group = companyPersonnel.ViewEvaluationStatusSupervisor_GroupAnnual();
                if (dtEvaluationStatusSupervisor_Group.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No evaluation records for the selected supervisor!');window.location='HREvaluationSummary.aspx';</script>'");
                }
                else
                {
                    gvEvaluationStatus_Group.Caption = "Assessment Status of " + gvCompanyEmployees.SelectedRow.Cells[1].Text + ", "
                        + gvCompanyEmployees.SelectedRow.Cells[2].Text;
                    gvEvaluationStatus_Group.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor_GroupAnnual();
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
            companyPersonnel.Emp_evaluated_id = int.Parse(gvCompanyEmployees.SelectedRow.Cells[0].Text);
            companyPersonnel.Eval_quarter = gvEvaluationStatus_Group.SelectedRow.Cells[1].Text;
            companyPersonnel.Eval_year = int.Parse(gvEvaluationStatus_Group.SelectedRow.Cells[2].Text);
            gvEmployeeEvaluationStatus.Caption = "Evaluators of " + gvCompanyEmployees.SelectedRow.Cells[1].Text
                + ", " + gvCompanyEmployees.SelectedRow.Cells[2].Text + " for " + gvEvaluationStatus_Group.SelectedRow.Cells[1].Text
                + " Quarter, " + gvEvaluationStatus_Group.SelectedRow.Cells[2].Text;
            dtEvaluationStatusSupervisor = companyPersonnel.ViewEvaluationStatusSupervisor();
            gvEmployeeEvaluationStatus.DataSource = dtEvaluationStatusSupervisor;
            gvEmployeeEvaluationStatus.DataBind();
            Clear_gvEvaluationAnswers(sender, e);
            Clear();
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
            gvEmployeeEvaluationStatus.DataSource = companyPersonnel.ViewEvaluationStatusEmployeeAnnual();
            gvEmployeeEvaluationStatus.DataBind();
        }

        protected void Clear_gvEvaluationStatus_Group(object sender, EventArgs e)
        {
            companyPersonnel.Emp_selected_id = 0;
            gvEvaluationStatus_Group.DataSource = companyPersonnel.ViewEvaluationStatusSupervisor_GroupAnnual();
            gvEvaluationStatus_Group.DataBind();
            Clear();
        }

        private void Clear()
        {
            lblNotification.Text = "";
        }

        protected void gvCompanyEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvCompanyEmployees, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvEmployeeEvaluationStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeEvaluationStatus, "Select$" + e.Row.RowIndex);
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
    }
}