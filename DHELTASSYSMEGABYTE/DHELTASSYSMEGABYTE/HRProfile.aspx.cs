using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using DHELTASSys.Modules;
using DHELTASSys.modules;
using DHELTASSYS.DataAccess;

namespace DHELTASSYSMEGABYTE
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        HRModuleBL hr = new HRModuleBL();
        BenefitsModuleBL benefit = new BenefitsModuleBL();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

                if (Session["Position"].ToString() != "HR Manager")
                {
                    Response.Write("<script>alert('You're not allowed to access this page')</script>");
                }
                else
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    if (!IsPostBack)
                    {
                        lblFullName.Text = (string)(Session["LastName"].ToString()) +", "  + (Session["FirstName"].ToString());
                        lblPosition.Text = "(" +(string)(Session["Position"].ToString()) + ")";
                        lblLastName.Text = (string)(Session["LastName"].ToString());
                        lblFirstName.Text = (string)(Session["FirstName"].ToString());
                        lblMiddleName.Text = (string)(Session["MiddleName"].ToString());
                        lblEmailAdd.Text = (string)(Session["EmailAdd"].ToString());
                        lblBirthday.Text = (string)(Session["Birthdate"].ToString());
                        lblPos.Text = (string)(Session["Position"].ToString());
                        lblCompany.Text = (string)(Session["CompanyName"].ToString());
                        lblDepartment.Text = (string)(Session["Department"].ToString());
                        lblSSS.Text = (string)(Session["SSS"].ToString());
                        lblPhilHealth.Text = (string)(Session["PhilHealth"].ToString());

                        txtLastName.Text = lblLastName.Text;
                        txtFirstName.Text = lblFirstName.Text;
                        txtMiddleName.Text = lblMiddleName.Text;
                        txtEadd.Text = lblEmailAdd.Text;
                        txtBirthday.Text = lblBirthday.Text;
                        txtPosition.Text = lblPos.Text;
                        txtSSS.Text = lblSSS.Text;
                        txtPhilHealth.Text = lblPhilHealth.Text;

                        benefit.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvEmployee.DataSource = benefit.ViewEmployeeBenefits();
                        gvEmployee.DataBind();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}