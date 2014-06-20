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
    public partial class DisplayEmployeeOffenses : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }

            else if (position != "Supervisor" || Session["SelectedEmployee"] == null)
            {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

            discipline.Emp_id = int.Parse(Session["SelectedEmployee"].ToString());

            lblEmpFirstName.Text = Session["SelectedEmpFirstName"].ToString();
            lblEmpLastName.Text = Session["SelectedEmpLastName"].ToString();

            grdDisplayOffense.DataSource = discipline.DisplayOffense();
            grdDisplayOffense.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Remove("SelectedEmpFirstName");
            Session.Remove("SelectedEmpLastName");
            Session.Remove("SelectedEmployee");

            Response.Redirect(@"~/discipline/FileOffense.aspx");
        }
    }
}