using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DHELTASSys.DataHandling;
using DHELTASSYS.DataAccess;
using DHELTASSys.modules;
using DHELTASSys.AuditTrail;

namespace DHELTASSYSMEGABYTE
{
    public partial class SVEmployeeEvaluate : System.Web.UI.Page
    {
        DHELTASSysDataHandling dth = new DHELTASSysDataHandling();
        int userSession;
        string userPosition;
        int year;
        DataTable dtEvalStatEmp;

        EvaluationModuleBL evalEmployee = new EvaluationModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();

        DataTable dtQuestions = new DataTable();
        DataTable dtEvaluated_Employee = new DataTable();
        RadioButtonList rbtn = new RadioButtonList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"]!= null)
            {
                if (Session["Position"].ToString() == "Supervisor")
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    userPosition = Session["Position"].ToString();
                    evalEmployee.Emp_evaluating_id = userSession;
                    gvEmployeeEvaluate.DataSource = evalEmployee.ViewEvaluateEmployees();
                    gvEmployeeEvaluate.DataBind();

                    if (DateTime.Now.Month <= 03)
                    {
                        evalEmployee.Eval_quarter = "First";
                    }
                    else if (DateTime.Now.Month >= 03 && DateTime.Now.Month <= 06)
                    {
                        evalEmployee.Eval_quarter = "Second";
                    }
                    else if (DateTime.Now.Month >= 06 && DateTime.Now.Month <= 09)
                    {
                        evalEmployee.Eval_quarter = "Third";
                    }
                    else
                    {
                        evalEmployee.Eval_quarter = "Fourth";
                    }
                    year = int.Parse(DateTime.Now.Year.ToString());
                    evalEmployee.Eval_year = year;
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvEmployeeEvaluate.SelectedRow == null)
            {
                Response.Write("<script>alert('No selected employee to evaluate.')</script>");
            }
            else
            {
                evalEmployee.Emp_evaluated_id = int.Parse(gvEmployeeEvaluate.SelectedRow.Cells[0].Text);
                dtEvalStatEmp = evalEmployee.ViewEvalStatAnswers();

                if (dtEvalStatEmp.Rows.Count == 0)
                {
                    Session.Add("Evaluated_EmployeeID", gvEmployeeEvaluate.SelectedRow.Cells[0].Text);
                    Response.Redirect("SVEmployeeEvalForm.aspx");
                }
                else
                {
                    Response.Write("<script>alert('The selected employee has already been evaluated.')</script>");
                }
            }
        }

        protected void gvEmployeeEvaluate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeEvaluate, "Select$" + e.Row.RowIndex);
        }
    }
}