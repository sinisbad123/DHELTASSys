using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHELTASSys
{
    public partial class EvaluateSuccess : System.Web.UI.Page
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
                else if (position != "HR Manager" || Session["OffenseID"] == null)
                {
                    Response.Redirect(@"~/AccessDenied.aspx");
                }
                Session.Remove("OffenseID");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["MainPage"].ToString());
            //Homepage
        }

        protected void btnPendingOffense_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendingOffense.aspx");
        }

        protected void btnDiscipline_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/discipline/DisciplineHome.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}