using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;
using DHELTASSys.DataHandling;
using DHELTASSys.AuditTrail;

namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        BenefitsModuleBL benefits = new BenefitsModuleBL();
        DHELTASSysDataHandling dataHandling = new DHELTASSysDataHandling();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRemove.Visible = false;
            lblBenefit.Visible = false;
            lbModal.Visible = false;
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
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
                lbModal.Visible = true;
            }
            else
            {
                btnRemove.Visible = true;
                lbModal.Visible = true;
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

                    auditTrail.Emp_id = userSession;
                    auditTrail.AddAuditTrail("Added " + dpBenefit.Text + " to " + benefits.Emp_id + "");
                    Response.Redirect("HRAddEmployeeBenefit.aspx");
                }
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

                    auditTrail.Emp_id = userSession;
                    auditTrail.AddAuditTrail("Removed benefit from " + benefits.Emp_id + "");
                    Response.Redirect("HRAddEmployeeBenefit.aspx");
                }
            }
        }
    }
}