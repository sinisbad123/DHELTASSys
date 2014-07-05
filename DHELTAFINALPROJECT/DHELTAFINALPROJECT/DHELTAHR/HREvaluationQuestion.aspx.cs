using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//imports
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DHELTASSys.DataHandling;
using DHELTASSYS.DataAccess;
using DHELTASSys.modules;
using DHELTASSys.AuditTrail;

namespace DHELTASSYSMEGABYTE
{
    public partial class HREvaluationQuestion : System.Web.UI.Page
    {
        EvaluationModuleBL evalQuestion = new EvaluationModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                if (Session["Position"].ToString() == "HR Manager")
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    evalQuestion.Emp_id = userSession;
                    gvEvaluationQuestion.DataSource = evalQuestion.ViewEvaluationQuestion();
                    gvEvaluationQuestion.DataBind();

                    if (!IsPostBack)
                    {
                        DataTable dtCategory = evalQuestion.SelectAllEvaluationCategory();
                        dpEvaluationCategory.DataSource = dtCategory;
                        dpEvaluationCategory.DataTextField = "eval_category";
                        dpEvaluationCategory.DataValueField = "eval_category";
                        dpEvaluationCategory.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {      
            if (txtQuestion.Text == "" || dpEvaluationCategory.Text == "" || dpPosition.Text == "")
            {
                Response.Write("<script>alert('Please fill up all the fields')</script>");
            }
            else
            {
                evalQuestion.Eval_question = txtQuestion.Text;
                evalQuestion.Eval_category = dpEvaluationCategory.SelectedItem.Text;
                evalQuestion.Emp_id = userSession;
                evalQuestion.Position_name = dpPosition.SelectedItem.Text;
                evalQuestion.AddEvaluationQuestions();

                auditTrail.Emp_id = userSession;
                auditTrail.AddAuditTrail("Add Evaluation Question");

                Response.Redirect("HREvaluationQuestion.aspx");
            }
        }
    }
}