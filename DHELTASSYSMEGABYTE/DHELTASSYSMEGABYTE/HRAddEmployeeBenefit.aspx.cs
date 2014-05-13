using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;
using DHELTASSys.DataHandling;
namespace DHELTASSYSMEGABYTE
{
    public partial class WebForm27 : System.Web.UI.Page
    {
        BenefitsModuleBL benefits = new BenefitsModuleBL();
        DHELTASSysDataHandling dataHandling = new DHELTASSysDataHandling();
        int userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                userSession = int.Parse(Session["EmployeeID"].ToString());
                if (Session["Position"].ToString() == "HR Manager")
                {
                    benefits.Emp_id = userSession;
                    dataHandling.Emp_id = userSession;
                    gvEmployee.DataSource = dataHandling.SelectCompanyEmployees();
                    gvEmployee.DataBind();

                    if (!IsPostBack)
                    {
                        btnRemove.Visible = false;
                        //dpBenefit.Enabled = false;
                        DataTable dtPosition = dataHandling.SelectAllPosition();
                        dpPosition.DataSource = dtPosition;
                        dpPosition.DataTextField = "position_name";
                        dpPosition.DataValueField = "position_name";
                        dpPosition.DataBind();
                    }
                }
                else if (Session["Position"].ToString() == "Employee")
                {
                    Response.Redirect("EmployeeMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Vice President")
                {
                    Response.Redirect("VPMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Supervisor")
                {
                    Response.Redirect("SVMainPage.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblEmpID.Text == "" || lblLastName.Text == "" || lblFirstName.Text == "" || lblPos.Text == "" || lblDept.Text == "")
            {
                Response.Write("<script>alert('Please select a employee.')</script>");
            }
            else if (dpBenefit.Text == "")
            {
                Response.Write("<script>alert('Please add company benefit first.')</script>");
            }
            else
            {
                benefits.Emp_id = int.Parse(lblEmpID.Text);
                benefits.Benefit_id = int.Parse(dpBenefit.SelectedValue);
                DataTable dtEmployeeBenefitBenefitID = benefits.ViewBenefitsBenefitID();
                if (dtEmployeeBenefitBenefitID.Rows.Count >= 1)
                {
                    Response.Write("<script>alert('Benefit already added to the employee')</script>");
                }
                else
                {
                    benefits.AddEmployeeBenefits();

                    //auditTrail.Emp_id = userSession;
                    //auditTrail.AddAuditTrail("Add Employee Benefit");

                    Response.Redirect("HRAddEmployeeBenefit.aspx");
                }
            }
        }

        protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployee, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dpBenefit.Enabled = false;
            lblEmpID.Text = gvEmployee.SelectedRow.Cells[0].Text;
            lblLastName.Text = gvEmployee.SelectedRow.Cells[1].Text;
            lblFirstName.Text = gvEmployee.SelectedRow.Cells[2].Text;
            lblPos.Text = gvEmployee.SelectedRow.Cells[4].Text;
            lblDept.Text = gvEmployee.SelectedRow.Cells[5].Text;

            benefits.Emp_id = int.Parse(lblEmpID.Text);
            benefits.Position_name = lblPos.Text;
            dpBenefit.DataSource = benefits.ViewPositionBenefits();
            dpBenefit.DataValueField = "ID";
            dpBenefit.DataTextField = "Benefit Type";
            dpBenefit.DataBind();

            gvBenefit.DataSource = benefits.ViewEmployeeBenefits();
            gvBenefit.DataBind();
            if (gvBenefit.Rows.Count <= 0)
            {
                btnRemove.Visible = false;
            }
            else
            {
                btnRemove.Visible = true;
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            benefits.Emp_id = int.Parse(gvEmployee.SelectedRow.Cells[0].Text);
            for (int empBenefit = 0; empBenefit < gvBenefit.Rows.Count; empBenefit++)
            {
                CheckBox chkEmpBenefit = (CheckBox)gvBenefit.Rows[empBenefit].Cells[0].FindControl("chkEmpBenefit");
                if (chkEmpBenefit.Checked)
                {
                    benefits.Emp_benefit_id = int.Parse(gvBenefit.Rows[empBenefit].Cells[1].Text);
                    benefits.RemoveEmployeeBenefits();
                }
            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            benefits.Emp_id = userSession;
            if (txtBenefitType.Text == "" || txtBenefitInfo.Text == "" || dpPosition.Text == "")
            {
                Response.Write("<script>alert('Please fill up all the fields')</script>");
            }
            else
            {
                //Add Benefit
                benefits.Benefit_type = txtBenefitType.Text;
                benefits.Benefit_info = txtBenefitInfo.Text;
                benefits.Position_name = dpPosition.Text;
                benefits.AddBenefits();
                txtBenefitType.Text = "";
                txtBenefitInfo.Text = "";
            }
        }

    }
}