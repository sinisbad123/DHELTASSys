using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//imports
using System.Data;
using DHELTASSys.Modules;

namespace DHELTASSys
{
    public partial class AttendanceSummaryOfEmployeeSelected : System.Web.UI.Page
    {
        AttendanceModuleBL attendance = new AttendanceModuleBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }

            else if (position != "HR Manager" || Session["SelectedEmployee"] == null || position != "Supervisor")
            {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

            lblEmployeeName.Text = Session["SelectedEmpLastName"].ToString() + ", " + Session["SelectedEmpFirstName"].ToString();

            attendance.Emp_id = int.Parse(Session["SelectedEmployee"].ToString());

            grdViewSummary.DataSource = attendance.GetPersonalAttendanceRecord();
            grdViewSummary.DataBind();
        }

        protected void btnEmployeesAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllEmployeeAttendance.aspx");
            //Back to Attendance Summaries of Employees
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["MainPage"].ToString());
            //Home
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}