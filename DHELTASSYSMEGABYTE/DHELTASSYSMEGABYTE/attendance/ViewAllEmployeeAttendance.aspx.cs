using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//imports
using DHELTASSys.Modules;
using System.Data;

namespace DHELTASSys
{
    public partial class ViewAllEmployeeAttendance : System.Web.UI.Page
    {
        AttendanceModuleBL attendance = new AttendanceModuleBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            
            else if(position != "HR Manager" || position != "Supervisor") {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

            attendance.Company_name = Session["Company"].ToString();

            grdviewAllSummary.DataSource = attendance.GetEmployeesForAttendanceViewing();
            grdviewAllSummary.DataBind();
            
        }

        protected void btnSummary_Click(object sender, EventArgs e)
        {
            if (grdviewAllSummary.SelectedRow == null)
            {
                Response.Write("<script>alert('No employee selected. Please click an employee.')</script>");
            }
            else
            {
                string selectedEmployeeID = grdviewAllSummary.SelectedRow.Cells[0].Text;
                Session.Add("SelectedEmployee", selectedEmployeeID);

                string selectedEmpLastName = grdviewAllSummary.SelectedRow.Cells[1].Text;
                Session.Add("SelectedEmpLastName", selectedEmpLastName);

                string selectedEmpFirstName = grdviewAllSummary.SelectedRow.Cells[2].Text;
                Session.Add("SelectedEmpFirstName", selectedEmpFirstName);

                Response.Redirect("AttendanceSummaryOfEmployeeSelected.aspx");
            }
        }

        protected void grdviewAllSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdviewAllSummary, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}