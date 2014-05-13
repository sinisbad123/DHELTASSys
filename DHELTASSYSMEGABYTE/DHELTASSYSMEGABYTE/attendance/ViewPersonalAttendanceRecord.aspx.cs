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
    public partial class ViewPersonalAttendanceRecord : System.Web.UI.Page
    {
        AttendanceModuleBL attendance = new AttendanceModuleBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }

            attendance.Emp_id = int.Parse(Session["EmployeeID"].ToString());

            grdViewPersonalAttendance.DataSource = attendance.GetPersonalAttendanceRecord();
            grdViewPersonalAttendance.DataBind();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
            //Home
        }

        protected void btnAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/attendance/AttendanceHome.aspx");
            //Attendance Module
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }


    }
}