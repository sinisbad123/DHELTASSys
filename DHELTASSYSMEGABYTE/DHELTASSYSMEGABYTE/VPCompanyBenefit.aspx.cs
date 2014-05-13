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
    public partial class WebForm23 : System.Web.UI.Page
    {
        DHELTASSysDataHandling dataHandling = new DHELTASSysDataHandling();
        BenefitsModuleBL benefits = new BenefitsModuleBL();
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
                if (Session["Position"].ToString() == "Vice President")
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

                        dpPosition.Items.Insert(0, new ListItem("All Position", "All"));
                        for (int i = 0; i < dtPosition.Rows.Count; i++)
                        {
                            dpPosition.Items.Insert(i + 1, new ListItem(dtPosition.Rows[i]["position_name"].ToString()));
                        }
                        dpPosition.DataBind();
                    }
                }
            }
        }

        protected void dpPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            benefits.Emp_id = userSession;
            if (dpPosition.SelectedValue == "All")
            {
                DataTable dtBenefits = benefits.ViewBenefits();
                dtBenefits.Columns.Remove("ID");
                gvBenefit.DataSource = dtBenefits;
                gvBenefit.DataBind();
            }
            else
            {
                benefits.Position_name = dpPosition.Text;
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