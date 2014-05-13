using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//imports
using System.Data;
using DHELTASSys.Modules;
using DHELTASSys.AuditTrail;

namespace DHELTASSys
{
    public partial class FileOffense : System.Web.UI.Page
    {
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();
        DisciplineModuleBL discipline = new DisciplineModuleBL();

        void RefreshDropDownList()
        {
            drpdownOffenseCategory.DataSource = discipline.GetOffenseCategory();
            drpdownOffenseCategory.DataTextField = "offense_category_name";
            drpdownOffenseCategory.DataValueField = "offense_category_name";
            drpdownOffenseCategory.DataBind();
        }

        void RefreshOffenseType()
        {
            grdOffenseType.DataSource = discipline.DisplayOffenseType();
            grdOffenseType.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else if (position != "Supervisor")
            {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

            RefreshOffenseType();
            RefreshDropDownList();
            discipline.Company_name = Session["Company"].ToString();
            discipline.Department_name = Session["Department"].ToString();
            grdEmployeeList.DataSource = discipline.DisplayEmployeeLastNameFirstName();
            grdEmployeeList.DataBind();
        }

        protected void btnAddOffenseType_Click(object sender, EventArgs e)
        {
            if (txtOffenseInfo.Text == "")
            {
                Response.Write("<script>alert('Please fill-in the empty field.')</script>");
            }
            else
            {
                audit.Emp_id = int.Parse(Session["EmployeeID"].ToString());

                discipline.Offense_info = txtOffenseInfo.Text;
                discipline.Offense_type = drpdownOffenseType.Text;
                discipline.Offense_category_name = drpdownOffenseCategory.Text;

                discipline.AddOffenseType();
                audit.AddAuditTrail("Added Offense Type");
                RefreshOffenseType();
            }
        }

        protected void btnAddCategoryName_Click(object sender, EventArgs e)
        {
            audit.Emp_id = int.Parse(Session["EmployeeID"].ToString());
            discipline.Offense_category_name = txtCategoryName.Text;

            discipline.AddOffenseCategory();
            audit.AddAuditTrail("Added Offense Category");

            RefreshDropDownList();
        }
        
        protected void btnDisplayEmpOffenses_Click(object sender, EventArgs e)
        {
            

            if (grdEmployeeList.SelectedRow == null)
            {
                Response.Write("<script>alert('No employee selected. Please click an employee.')</script>");
            }
            else
            {
                string selectedEmployeeID = grdEmployeeList.SelectedRow.Cells[0].Text;
                Session.Add("SelectedEmployee", selectedEmployeeID);

                string selectedEmpLastName = grdEmployeeList.SelectedRow.Cells[1].Text;
                Session.Add("SelectedEmpLastName", selectedEmpLastName);

                string selectedEmpFirstName = grdEmployeeList.SelectedRow.Cells[2].Text;
                Session.Add("SelectedEmpFirstName", selectedEmpFirstName);

                Response.Redirect("DisplayEmployeeOffenses.aspx");
            }

        }

        protected void btnFileOffense_Click(object sender, EventArgs e)
        {


            if (grdEmployeeList.SelectedRow == null)
            {
                Response.Write("<script>alert('No employee selected. Please click an employee.')</script>");
            }
            else
            {
                string selectedEmployeeID = grdEmployeeList.SelectedRow.Cells[0].Text;
                Session.Add("SelectedEmployee", selectedEmployeeID);

                string selectedEmpLastName = grdEmployeeList.SelectedRow.Cells[1].Text;
                Session.Add("SelectedEmpLastName", selectedEmpLastName);

                string selectedEmpFirstName = grdEmployeeList.SelectedRow.Cells[2].Text;
                Session.Add("SelectedEmpFirstName", selectedEmpFirstName);

                Response.Redirect("OffenseFiling.aspx");
            }

        }

        //Select a row by clicking any cells of it
        protected void grdEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdEmployeeList, "Select$" + e.Row.RowIndex);
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