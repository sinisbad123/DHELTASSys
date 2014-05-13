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
    public partial class OffenseApproval : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else if (position!= "HR Manager")
            {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

            discipline.Company_name = Session["Company"].ToString();
            grdPendingOffenses.DataSource = discipline.DisplayPendingEmployeeOffenses();
            grdPendingOffenses.DataBind();
        }

        protected void btnEvaluate_Click(object sender, EventArgs e)
        {
            if (grdPendingOffenses.SelectedRow == null)
            {
                Response.Write("<script>alert('Please select offense to be evaluated.')</script>");
            }
            else
            {
                string offenseID = grdPendingOffenses.SelectedRow.Cells[0].Text;

                Session.Add("OffenseID", offenseID);

                Response.Redirect("EvaluateOffense.aspx");
            }
        }

        protected void grdPendingOffenses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdPendingOffenses, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["MainPage"].ToString());
        }
    }
}