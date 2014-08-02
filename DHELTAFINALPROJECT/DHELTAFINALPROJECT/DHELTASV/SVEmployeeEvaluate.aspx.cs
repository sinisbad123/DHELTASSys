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
        DateTime currentDate = DateTime.Now;

        EvaluationModuleBL evalEmployee = new EvaluationModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();

        DataTable dtQuestions = new DataTable();
        DataTable dtEvaluated_Employee = new DataTable();
        DataTable dtEvaluationStatusEmployee = new DataTable();
        RadioButtonList rbtn = new RadioButtonList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"]!= null)
            {
                if (Session["Position"].ToString() == "Supervisor")
                {
                    if (currentDate.Month == 3 || currentDate.Month == 6 || currentDate.Month == 9 || currentDate.Month == 12)
                    {
                        userSession = int.Parse(Session["EmployeeID"].ToString());
                        userPosition = Session["Position"].ToString();
                        evalEmployee.Emp_evaluating_id = userSession;

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

                        dtEvaluated_Employee = evalEmployee.ViewEvaluateEmployees();
                        if (dtEvaluated_Employee.Rows.Count == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You do not have existing employees!');window.location='SVMainPage.aspx';</script>'");
                        }
                        else
                        {
                            gvEmployeeEvaluate.DataSource = dtEvaluated_Employee;
                            gvEmployeeEvaluate.DataBind();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Evaluating the employees is prohibited at this time!');window.location='SVMainPage.aspx';</script>'");
                    }
                }
                else if (Session["Position"].ToString() == "Vice President")
                {
                    Response.Redirect("VPMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "HR Manager")
                {
                    Response.Redirect("HRMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Supervisor")
                {
                    Response.Redirect("SVMainPage.aspx");
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
            if (gvEmployeeEvaluate.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No selected employee to evaluate!');window.location='SVEmployeeEvaluate.aspx';</script>'");   
            }
            else
            {
                Session.Add("Evaluated_EmployeeID", gvEmployeeEvaluate.SelectedRow.Cells[0].Text);
                Response.Redirect("SVEmployeeEvalForm.aspx");
            }
        }

        protected void gvEmployeeEvaluate_SelectedIndexChanged(object sender, EventArgs e)
        {
            evalEmployee.Emp_evaluated_id = int.Parse(gvEmployeeEvaluate.SelectedRow.Cells[0].Text);

            dtEvaluationStatusEmployee = evalEmployee.ViewEvaluationStatusEmployeeID();
            if (dtEvaluationStatusEmployee.Rows.Count != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('The selected employee has already been evaluated!');window.location='SVEmployeeEvaluate.aspx';</script>'");
            }
        }

        protected void gvEmployeeEvaluate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeEvaluate, "Select$" + e.Row.RowIndex);
            }
        }
    }
}