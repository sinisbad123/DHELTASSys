using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DHELTASSys.Modules;
using System.Data;
using DHELTASSys.AuditTrail;

namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();
        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else if (position != "HR Manager")
            {
                Response.Redirect(@"~/404.aspx");
            }
            discipline.Company_name = Session["CompanyName"].ToString();
                discipline.Department_name = Session["Department"].ToString();
                gvEmployee.DataSource = discipline.DisplayEmployeeLastNameFirstName();
                gvEmployee.DataBind();
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
            int emp_id = int.Parse(gvEmployee.SelectedRow.Cells[0].Text);


            discipline.Emp_id = emp_id;
            gvOffense.DataSource = discipline.DisplayOffense();
            gvOffense.DataBind();
        }
     }
}
