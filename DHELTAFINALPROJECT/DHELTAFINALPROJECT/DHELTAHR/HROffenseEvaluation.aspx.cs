using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.Modules;

namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();
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
            else
            {

                discipline.Company_id = int.Parse(Session["CompanyID"].ToString());
                grdPedingOffense.DataSource = discipline.DisplayPendingEmployeeOffenses();
                grdPedingOffense.DataBind();
            }
        }

        protected void grdPedingOffense_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdPedingOffense, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnEval_Click(object sender, EventArgs e)
        {
            if (grdPedingOffense.SelectedRow == null)
            {
                Response.Write("<script>alert('Please select offense to be evaluated.')</script>");
            }
            else
            {
                string offenseID = grdPedingOffense.SelectedRow.Cells[0].Text;

                Session.Add("OffenseID", offenseID);

                Response.Redirect("HREmployeeOffense.aspx");
            }
        }
    }
}