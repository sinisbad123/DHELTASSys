using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHELTASSys
{
    public partial class OffenseFilingSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                Session.Remove("SelectedEmployee");
                Session.Remove("SelectedEmpLastName");
                Session.Remove("SelectedEmpFirstName");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/discipline/FileOffense.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["MainPage"].ToString());
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}