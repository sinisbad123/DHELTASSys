using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//imports
using DHELTASSys.Modules;
using System.Data;
using DHELTASSys.AuditTrail;

namespace DHELTASSys
{
    public partial class EvaluateOffense : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();

        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            } else if(position != "HR Manager" || Session["OffenseID"] == null)
            {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

           

            discipline.Offense_emp_id = int.Parse(Session["OffenseID"].ToString());

            DataTable offense = discipline.GetOffense();
            lblOffenseID.Text = offense.Rows[0][0].ToString();
            lblEmpFiled.Text = offense.Rows[0][1].ToString();
            lblSupervisor.Text = offense.Rows[0][2].ToString();
            lblOffenseType.Text = offense.Rows[0][3].ToString();
            lblOffenseInfo.Text = offense.Rows[0][4].ToString();
            lblOffenseCategory.Text = offense.Rows[0][5].ToString();
            lblOffenseDate.Text = offense.Rows[0][6].ToString();
            lblSupervisorStatement.Text = offense.Rows[0][7].ToString();
            

            DataTable proof = discipline.GetProof();

            if (proof.Rows.Count == 0)
            {
                Label9.Visible = false;
                imgProof.Visible = false;
            }
            else
            {
                imgProof.ImageUrl = @"~/Uploads_Proofs/" + proof.Rows[0][0].ToString();
            }
        }



        protected void btnEvaluate_Click(object sender, EventArgs e)
        {
            discipline.Offense_emp_id = int.Parse(Session["OffenseID"].ToString());
            discipline.Decision = drpDecision.Text;

            discipline.AddOffenseDecision();

            audit.Emp_id = int.Parse(Session["EmployeeID"].ToString());
            audit.AddAuditTrail(drpDecision.Text + "ed the offense of the employee.");
            Response.Redirect("EvaluateSuccess.aspx");

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Remove("OffenseID");
            Response.Redirect("PendingOffense.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}