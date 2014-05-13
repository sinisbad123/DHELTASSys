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
    public partial class ViewOffense : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmployeeID"] == null)
                {
                    Response.Redirect(@"~/index.aspx");
                }

                discipline.Emp_id = int.Parse(Session["EmployeeID"].ToString());

                grdviewEmployeeOffense.DataSource = discipline.GetEmployeeOffense();
                grdviewEmployeeOffense.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["MainPage"].ToString());
            //Return to Homepage
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/discipline/DisciplinaryHome.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}