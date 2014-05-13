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
    public partial class DisplayAllEmployeeOffenses : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }

            else if (position != "HR Manager" || position != "Supervisor")
            {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

            string companyName = Session["Company"].ToString();

            discipline.Company_name = companyName;

            grdViewOffense.DataSource = discipline.GetAllEmployeeOffenses();
            grdViewOffense.DataBind();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["MainPage"].ToString());
            //Homepage
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}