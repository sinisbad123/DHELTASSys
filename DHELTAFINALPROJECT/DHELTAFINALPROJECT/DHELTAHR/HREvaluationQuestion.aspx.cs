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

        DataTable dtEvaluationQuestion = new DataTable();
        DataTable dtEvaluationQuestionSort = new DataTable();

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

                    if (evalQuestion.Eval_question_id == 0)
                    {
                        pnlEditQuestion.Visible = false;
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
            if (txtQuestion.Text == "" || dpQuestionStatus.Text == "" || dpPosition.Text == "")
            {
                Response.Write("<script>alert('Please fill up all the fields')</script>");
            }
            else
            {
                evalQuestion.Emp_id = userSession;
                evalQuestion.Eval_question = txtQuestion.Text;
                evalQuestion.Position_name = dpPosition.SelectedItem.Text;
                evalQuestion.Eval_question_Status = dpQuestionStatus.SelectedItem.Text;

                dtEvaluationQuestion = evalQuestion.SelectEvaluationQuestionID();

                if (dtEvaluationQuestion.Rows.Count >= 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('There is already an existing question made!');window.location='HREvaluationQuestion.aspx';</script>'");
                }
                else
                {
                    evalQuestion.AddEvaluationQuestions();

                    auditTrail.Emp_id = userSession;
                    auditTrail.AddAuditTrail("Add Evaluation Question");

                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully added an evaluation question!');window.location='HREvaluationQuestion.aspx';</script>'");        
                }
            }
        }

        protected void gvEvaluationQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlEditQuestion.Visible = true;

            txtQuestionID_Edit.Text = gvEvaluationQuestion.SelectedRow.Cells[0].Text;
            txtQuestion_Edit.Text = gvEvaluationQuestion.SelectedRow.Cells[1].Text;
            txtPosition_Edit.Text = gvEvaluationQuestion.SelectedRow.Cells[2].Text;
        }

        protected void btnEditQuestion_Click(object sender, EventArgs e)
        {
            evalQuestion.Eval_question_id = int.Parse(gvEvaluationQuestion.SelectedRow.Cells[0].Text);
            evalQuestion.Eval_question_Status = dpQuesionStatus_Edit.SelectedItem.Text;

            evalQuestion.UpdateEvaluationQuestion();
            evalQuestion.Eval_question_id = 0;

            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have successfully edited an evaluation question!');window.location='HREvaluationQuestion.aspx';</script>'");
        }

        protected void btnSortQuestion_Click(object sender, EventArgs e)
        {
            evalQuestion.Question_position = dpSortQuestionPosition_Item.SelectedItem.Text;
            evalQuestion.Question_status = dpSortQuestionStatus_Item.SelectedItem.Text;

            if (dpSortQuestionPosition_Item.SelectedItem.Text == "All" &&
                dpSortQuestionStatus_Item.SelectedItem.Text == "All")
            {
                Response.Redirect("HREvaluationQuestion.aspx");
            }
            else if (dpSortQuestionPosition_Item.SelectedItem.Text != "All" &&
                dpSortQuestionStatus_Item.SelectedItem.Text == "All")
            {
                dtEvaluationQuestionSort = evalQuestion.ViewEvaluationQuestionPosition();               
            }
            else if (dpSortQuestionPosition_Item.SelectedItem.Text == "All" &&
                dpSortQuestionStatus_Item.SelectedItem.Text != "All")
            {
                dtEvaluationQuestionSort = evalQuestion.ViewEvaluationQuestionStatus();
            }            
            else
            {
                dtEvaluationQuestionSort = evalQuestion.ViewEvaluationQuestionSort();
            }
            gvEvaluationQuestion.DataSource = dtEvaluationQuestionSort;
            gvEvaluationQuestion.DataBind();
        }

        protected void gvEvaluationQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEvaluationQuestion, "Select$" + e.Row.RowIndex);
            }
        }
    }
}