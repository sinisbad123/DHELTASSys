using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DHELTASSys.Modules;
using System.Data;

namespace DHELTAFINALPROJECT.DHELTASV
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        AttendanceModuleBL attendance = new AttendanceModuleBL();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAttendance.Visible = false;
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }

            else if (position == "HR Manager" || position == "Supervisor")
            {
                attendance.Company_name = Session["CompanyName"].ToString();

                grdviewAllSummary.DataSource = attendance.GetEmployeesForAttendanceViewing();
                grdviewAllSummary.DataBind();



            }
            else
            {
                Response.Redirect(@"~/404.aspx");
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

        protected void grdviewAllSummary_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployeeID = grdviewAllSummary.SelectedRow.Cells[0].Text;
            Session.Add("SelectedEmployee", selectedEmployeeID);

            string selectedEmpLastName = grdviewAllSummary.SelectedRow.Cells[1].Text;
            Session.Add("SelectedEmpLastName", selectedEmpLastName);

            string selectedEmpFirstName = grdviewAllSummary.SelectedRow.Cells[2].Text;
            Session.Add("SelectedEmpFirstName", selectedEmpFirstName);

            lblAttendance.Visible = true;
            lblEmployeeName.Text = Session["SelectedEmpLastName"].ToString() + ", " + Session["SelectedEmpFirstName"].ToString();

            attendance.Emp_id = int.Parse(Session["SelectedEmployee"].ToString());

            grdViewSummary.DataSource = attendance.GetPersonalAttendanceRecord();
            grdViewSummary.DataBind();
        }   
    }
}