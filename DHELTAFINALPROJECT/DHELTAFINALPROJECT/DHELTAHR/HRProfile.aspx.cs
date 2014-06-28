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

namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        HRModuleBL hr = new HRModuleBL();
        BenefitsModuleBL benefit = new BenefitsModuleBL();
        AttendanceModuleBL attendance = new AttendanceModuleBL();
        int userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {

                if (Session["Position"].ToString() != "HR Manager")
                {
                    Response.Redirect(@"~/404.aspx");
                }
                else
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    if (!IsPostBack)
                    {
                        lblIDNumber.Text = (string)(Session["EmployeeID"].ToString());
                        lblFullName.Text = (string)(Session["LastName"].ToString()) + ", " + (Session["FirstName"].ToString());
                        lblPosition.Text = "(" + (string)(Session["Position"].ToString()) + ")";
                        lblLastName.Text = (string)(Session["LastName"].ToString());
                        lblFirstName.Text = (string)(Session["FirstName"].ToString());
                        lblMiddleName.Text = (string)(Session["MiddleName"].ToString());
                        lblPosinfo.Text = (string)(Session["Position"].ToString());
                        lblCompanyName.Text = (string)(Session["CompanyName"].ToString());
                        lblSSSNumber.Text = (string)(Session["SSS"].ToString());
                        lblPhilHealthNumber.Text = (string)(Session["PhilHealth"].ToString());

                        txtIDNumber.Text = lblIDNumber.Text;
                        txtLastName.Text = lblLastName.Text;
                        txtFirstName.Text = lblFirstName.Text;
                        txtMiddleName.Text = lblMiddleName.Text;
                        lblEditPosition.Text = lblPosinfo.Text;
                        lblEditCompanyName.Text = lblCompanyName.Text;
                        txtSSSNumber.Text = lblSSSNumber.Text;
                        txtPhilHealthNumber.Text = lblPhilHealthNumber.Text;

                        benefit.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvEmployee.DataSource = benefit.ViewEmployeeBenefits();
                        gvEmployee.DataBind();

                        gvDepedent.DataSource = benefit.ViewDependents();
                        gvDepedent.DataBind();

                        attendance.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvAttendanceSummary.DataSource = attendance.GetPersonalAttendanceRecord();
                        gvAttendanceSummary.DataBind();

                    }
                }
            }
        }

        protected void btnAddDedepent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddDependent.aspx");
        }
    }
}