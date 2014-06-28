using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DHELTASSys.AuditTrail;
using DHELTASSys.modules;

namespace DHELTAFINALPROJECT
{
    public partial class AddDependent : System.Web.UI.Page
    {
        BenefitsModuleBL benefits = new BenefitsModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;
        string userPosition;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            else
            {
                userSession = int.Parse(Session["EmployeeID"].ToString());
                userPosition = Session["Position"].ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtContactNumber.Text == "" || dpRelationship.Text == "")
            {
                Response.Write("<script>alert('Please fill up all the fields')</script>");
            }
            else
            {
                benefits.Emp_id = userSession;
                benefits.Dependent_name = txtName.Text;
                benefits.Contact_number = txtContactNumber.Text;
                benefits.Relation = dpRelationship.Text;
                benefits.AddDependents();
                //Response.Write("<script>alert('Dependent Added Successfully')</script>");

                auditTrail.Emp_id = userSession;
                auditTrail.AddAuditTrail(benefits.Emp_id.ToString() + " added new dependent");

                txtName.Text = "";
                txtContactNumber.Text = "";
                dpRelationship.Text = "";

                if (userPosition == "Employee")
                {
                    Response.Redirect("DHELTAEMP/EmployeeProfile.aspx");
                }
                else if (userPosition == "HR Manager")
                {
                    Response.Redirect("DHLETAHR/HRProfile.aspx");
                }
                else if (userPosition == "Supervisor")
                {
                    Response.Redirect("DHELTASV/SVProfile.aspx");
                }
                else if (userPosition == "Vice President")
                {
                    Response.Redirect("DHELTAVP/VPProfile.aspx");
                }
            }
        }
    }
}