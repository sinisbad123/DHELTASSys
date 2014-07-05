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

namespace DHELTASSYSMEGABYTE
{
    public partial class SVEmployeeEvalForm : System.Web.UI.Page
    {
        EvaluationModuleBL viewEvalForm = new EvaluationModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;
        int Evaluated_EmployeeID;
        string userPosition;

        DataTable dtQuestions = new DataTable();
        DataTable dtEvaluated_Employee = new DataTable();
        RadioButtonList rbtn = new RadioButtonList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "Supervisor")
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    userPosition = Session["Position"].ToString();
                    Evaluated_EmployeeID = int.Parse(Session["Evaluated_EmployeeID"].ToString());
                    viewEvalForm.Emp_evaluating_id = userSession;
                    viewEvalForm.Emp_evaluated_id = Evaluated_EmployeeID;

                    if (!IsPostBack)
                    {
                        dtEvaluated_Employee = viewEvalForm.SelectCompanyEmployeeForEvaluation();

                        lblEvaluated_EmpID.Text = dtEvaluated_Employee.Rows[0][0].ToString();
                        lblName.Text = dtEvaluated_Employee.Rows[0][1].ToString() + "," + dtEvaluated_Employee.Rows[0][2].ToString() + " " + dtEvaluated_Employee.Rows[0][3].ToString();
                        lblPosition.Text = dtEvaluated_Employee.Rows[0][4].ToString();
                        lblDepartment.Text = dtEvaluated_Employee.Rows[0][5].ToString();
                        lblDate.Text = DateTime.Now.Date.ToLongDateString();

                        dtQuestions = viewEvalForm.ViewEvaluationFormEmployee();
                        gvEmployeeEvalForm.DataSource = dtQuestions;
                        gvEmployeeEvalForm.DataBind();
                    }
                    if (DateTime.Now.Month <= 03)
                    {
                        viewEvalForm.Eval_quarter = "First";
                    }
                    else if (DateTime.Now.Month >= 03 && DateTime.Now.Month <= 06)
                    {
                        viewEvalForm.Eval_quarter = "Second";
                    }
                    else if (DateTime.Now.Month >= 06 && DateTime.Now.Month <= 09)
                    {
                        viewEvalForm.Eval_quarter = "Third";
                    }
                    else
                    {
                        viewEvalForm.Eval_quarter = "Fourth";
                    }
                    lblQuarter.Text = viewEvalForm.Eval_quarter + ", " + DateTime.Now.Year.ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvEmployeeEvalForm.Rows.Count; i++)
            {
                viewEvalForm.Emp_evaluating_id = userSession;
                viewEvalForm.Emp_evaluated_id = Evaluated_EmployeeID;

                RadioButtonList rbl = (RadioButtonList)gvEmployeeEvalForm.Rows[i].Cells[0].FindControl("rbtnRatings");
                viewEvalForm.Eval_question = gvEmployeeEvalForm.Rows[i].Cells[1].Text;

                if (rbl.SelectedValue != null)
                {
                    viewEvalForm.Eval_answer = rbl.SelectedValue;
                    viewEvalForm.AddEvaluationAnswers();
                }
                else
                {
                    Response.Write("<script>alert('Ratings must not be left unchecked.')</script>");
                }
            }
            viewEvalForm.AddEvaluationStatusEmployee();
            Session.Remove("Evaluated_EmployeeID");

            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully completed the evaluation!');window.location='SVMainPage.aspx';</script>'");        
        }
    }
}