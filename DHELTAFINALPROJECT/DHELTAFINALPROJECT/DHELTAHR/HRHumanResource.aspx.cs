using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using DHELTASSYS.DataAccess;
using DHELTASSys.Modules;
namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        HRModuleBL hr = new HRModuleBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {

            }
            else
            {
                hr.Company_id = int.Parse(Session["CompanyID"].ToString());
                gvEmployee.DataSource = hr.SeleectAllEmployeeByCompany();
                gvEmployee.DataBind();
            }
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
            hr.Emp_id = emp_id;
            //-----------------------------
            Label2.Text = gvEmployee.SelectedRow.Cells[0].Text;
            Label4.Text = gvEmployee.SelectedRow.Cells[1].Text;
            Label6.Text = gvEmployee.SelectedRow.Cells[2].Text;
            Label8.Text = gvEmployee.SelectedRow.Cells[3].Text;
            Label10.Text = gvEmployee.SelectedRow.Cells[4].Text;
            Label12.Text = gvEmployee.SelectedRow.Cells[5].Text;
            Label14.Text = hr.GetEmployeeInformation().Rows[0][0].ToString();
            Label16.Text = hr.GetEmployeeInformation().Rows[0][1].ToString();
            Label18.Text = hr.GetEmployeeInformation().Rows[0][2].ToString();
            Label20.Text = hr.GetEmployeeInformation().Rows[0][3].ToString();
            Label22.Text = hr.GetEmployeeInformation().Rows[0][4].ToString();
            Label24.Text = hr.GetEmployeeInformation().Rows[0][5].ToString();
            Label26.Text = hr.GetEmployeeInformation().Rows[0][6].ToString();
            Label28.Text = hr.GetEmployeeInformation().Rows[0][7].ToString();

        }
    }
}