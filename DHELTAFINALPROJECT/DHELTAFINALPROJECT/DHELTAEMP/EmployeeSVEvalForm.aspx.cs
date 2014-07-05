using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DHELTASSys.modules;
using DHELTASSys.AuditTrail;
using DHELTASSys;

namespace DHELTASSYSMEGABYTE
{
    public partial class EmployeeSVEvalForm : System.Web.UI.Page
    {
        EvaluationModuleBL viewSVEvalForm = new EvaluationModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;
        int Evaluated_EmployeeID;
        string userPosition;
        int year;

        DataTable dtQuestions = new DataTable();
        DataTable dtEvaluated_Employee = new DataTable();
        DataTable dtEvalStatSV_Group_QuarterYEar = new DataTable();
        RadioButtonList rbtn = new RadioButtonList();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["EmployeeID"] != null && Session["Evaluated_EmployeeID"]!= null)
            {
                if (Session["Position"].ToString() == "Employee")
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    userPosition = Session["Position"].ToString();

                    viewSVEvalForm.Emp_id = userSession;
                    Evaluated_EmployeeID = int.Parse(Session["Evaluated_EmployeeID"].ToString());
                    viewSVEvalForm.Emp_evaluating_id = userSession;
                    viewSVEvalForm.Emp_evaluated_id = Evaluated_EmployeeID;

                    if (!IsPostBack)
                    {
                        dtEvaluated_Employee = viewSVEvalForm.SelectCompanyEmployeeForEvaluation();

                        lblEvaluated_EmpID.Text = dtEvaluated_Employee.Rows[0][0].ToString();
                        lblName.Text = dtEvaluated_Employee.Rows[0][1].ToString() + "," + dtEvaluated_Employee.Rows[0][2].ToString() + " " + dtEvaluated_Employee.Rows[0][3].ToString();
                        lblPosition.Text = dtEvaluated_Employee.Rows[0][4].ToString();
                        lblDepartment.Text = dtEvaluated_Employee.Rows[0][5].ToString();
                        lblDate.Text = DateTime.Now.Date.ToLongDateString();

                        dtQuestions = viewSVEvalForm.ViewEvaluationFormSupervisor();
                        gvSVEvalForm.DataSource = dtQuestions;
                        gvSVEvalForm.DataBind();
                    }

                    if (DateTime.Now.Month <= 03)
                    {
                        viewSVEvalForm.Eval_quarter = "First";
                    }
                    else if (DateTime.Now.Month >= 03 && DateTime.Now.Month <= 06)
                    {
                        viewSVEvalForm.Eval_quarter = "Second";
                    }
                    else if (DateTime.Now.Month >= 06 && DateTime.Now.Month <= 09)
                    {
                        viewSVEvalForm.Eval_quarter = "Third";
                    }
                    else
                    {
                        viewSVEvalForm.Eval_quarter = "Fourth";
                    }
                    year = int.Parse(DateTime.Now.Year.ToString());
                    viewSVEvalForm.Eval_year = year;
                    lblQuarter.Text = viewSVEvalForm.Eval_quarter + ", " + year;
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
            for (int i = 0; i < gvSVEvalForm.Rows.Count; i++)
            {
                viewSVEvalForm.Emp_evaluating_id = userSession;
                viewSVEvalForm.Emp_evaluated_id = Evaluated_EmployeeID;

                RadioButtonList rbl = (RadioButtonList)gvSVEvalForm.Rows[i].Cells[0].FindControl("rbtnRatings");
                viewSVEvalForm.Eval_question = gvSVEvalForm.Rows[i].Cells[1].Text;          
                viewSVEvalForm.Eval_answer = rbl.SelectedValue;
                viewSVEvalForm.AddEvaluationAnswers();           
            }

            dtEvalStatSV_Group_QuarterYEar = viewSVEvalForm.ViewEvalStatSV_Group_QuarterYEar();
            if (dtEvalStatSV_Group_QuarterYEar.Rows.Count != 0)
            {
                viewSVEvalForm.AddEvaluationStatusSupervisor();
            }
            else
            {
                viewSVEvalForm.AddEvaluationStatusSupervisor();
                viewSVEvalForm.AddEvaluationStatusSupervisor_Group();
            }

            //Response.Write("<script>alert('You have successfully completed the evaluation.')</script>");
            Session.Remove("Evaluated_EmployeeID");

            auditTrail.Emp_id = userSession;
            auditTrail.AddAuditTrail("Evaluate Supervisor");

            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully completed the evaluation!');window.location='EmployeeMainPage.aspx';</script>'");
        }
    }
}