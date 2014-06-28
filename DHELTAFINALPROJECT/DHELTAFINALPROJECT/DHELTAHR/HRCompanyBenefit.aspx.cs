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
    public partial class WebForm5 : System.Web.UI.Page
    {
        DHELTASSysDataHandling dataHandling = new DHELTASSysDataHandling();
        BenefitsModuleBL benefits = new BenefitsModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    DataTable dtBenefits = benefits.ViewBenefits();
                    dtBenefits.Columns.Remove("ID");
                    gvBenefit.DataSource = dtBenefits;
                    gvBenefit.DataBind();
                    if (!IsPostBack)
                    {
                        DataTable dtPosition = dataHandling.SelectAllPosition();
                        dpPosition.DataSource = dtPosition;
                        dpPosition.DataTextField = "position_name";
                        dpPosition.DataValueField = "position_name";
                        dpPosition.DataBind();

                        cmbPositionFilter.Items.Insert(0, new ListItem("All Position", "All"));
                        for (int i = 0; i < dtPosition.Rows.Count; i++)
                        {
                            cmbPositionFilter.Items.Insert(i + 1, new ListItem(dtPosition.Rows[i]["position_name"].ToString()));
                        }
                        cmbPositionFilter.DataBind();
                    }
                }
                else if (Session["Position"].ToString() == "Employee")
                {
                    Response.Redirect(@"~/DHELTAEMP/EmployeeMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Vice President")
                {
                    Response.Redirect(@"~/DHELTAVP/VPMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Supervisor")
                {
                    Response.Redirect(@"~/DHELTASV/SVMainPage.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            benefits.Emp_id = userSession;
            if (txtBenefitType.Text == "" || txtBenefitInfo.Text == "" || dpPosition.Text == "")
            {
                Response.Write("<script>alert('Please fill up all the fields')</script>");
            }
            else
            {
                //Add Benefit
                benefits.Benefit_type = txtBenefitType.Text.Replace("<", "").Replace(">", "").Replace("'", "");
                benefits.Benefit_info = txtBenefitInfo.Text.Replace("<", "").Replace(">", "").Replace("'", "");
                benefits.Position_name = dpPosition.Text;
                benefits.AddBenefits();
                txtBenefitType.Text = "";
                txtBenefitInfo.Text = "";

                auditTrail.Emp_id = userSession;
                auditTrail.AddAuditTrail("Added " + benefits.Benefit_type + " benefit");
            }
        }

        protected void cmbPositionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            benefits.Emp_id = userSession;

            if (cmbPositionFilter.SelectedValue == "All")
            {
                DataTable dtBenefits = benefits.ViewBenefits();
                dtBenefits.Columns.Remove("ID");
                gvBenefit.DataSource = dtBenefits;
                gvBenefit.DataBind();
            }
            else
            {
                benefits.Position_name = cmbPositionFilter.Text;
                DataTable dtPositionBenefits = benefits.ViewPositionBenefits();
                if (dtPositionBenefits.Rows.Count >= 1)
                {
                    dtPositionBenefits.Columns.Remove("ID");
                    gvBenefit.DataSource = dtPositionBenefits;
                    gvBenefit.DataBind();
                    gvBenefit.Visible = true;
                }
                else
                {
                    gvBenefit.Visible = false;
                }
            }
        }
    }
}