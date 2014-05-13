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

namespace DHELTASSYSMEGABYTE
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        TransferModuleBL transfer = new TransferModuleBL();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

                if (Session["Position"].ToString() != "HR Manager")
                {
                    Response.Write("<script>alert('You're not allowed to access this page')</script>");
                }
                else
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    if (!IsPostBack)
                    {
                        dpPosition.DataSource = transfer.SelectPosition();
                        dpPosition.DataTextField = "position_name";
                        dpPosition.DataValueField = "position_id";
                        dpPosition.DataBind();
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            transfer.Emp_id = int.Parse(Session["EmployeeID"].ToString());
            transfer.CompanyID = (int.Parse(Session["CompanyID"].ToString()));
            transfer.PositionName = dpPosition.SelectedItem.Text;


            if (dpPosition.SelectedItem.Text == null)
            {
                Response.Write("<script>alert('Specify what you're looking for!')</script>");
            }
            else if (dpPosition.SelectedItem.Text == "Employee")
            {
                gvEmployee.DataSource = transfer.ViewEmployeeRequest();
                gvEmployee.DataBind();

            }
            else if (dpPosition.SelectedItem.Text == "Supervisor")
            {
                gvEmployee.DataSource = transfer.ViewEmployeeRequest();
                gvEmployee.DataBind();
            }
            else if (dpPosition.SelectedItem.Text == "Vice President")
            {
                gvEmployee.DataSource = transfer.ViewEmployeeRequest();
                gvEmployee.DataBind();

            }
            else
            {
                gvEmployee.DataSource = transfer.ViewEmployeeRequest();
                gvEmployee.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblEmpID.Text == null)
            {
                Response.Write("<script>alert('Select an Employee first')</script>");
            }
            else
            {
                if (txtDate.Text == null)
                {
                    Response.Write("<script>alert('Please select a desired date to transfer the employee')</script>");
                }
                else
                {
                    DateTime i;
                    if (DateTime.TryParse(txtDate.Text, out i))
                    {
                        if (DateTime.Parse(txtDate.Text) > DateTime.Now)
                        {

                            transfer.CompanyID = int.Parse(lblComID.Text);
                            transfer.YourComID = int.Parse(lblYourCompanyID.Text);
                            transfer.Emp_id = int.Parse(lblEmpID.Text);
                            transfer.Date_transfer = DateTime.Parse(txtDate.Text);
                            transfer.ModifyRequests();
                            transfer.AddEmpRequest();
                            Response.Write("<script>alert('Successfully Added!')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Date should be later than now')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please select a desired date to transfer the employee')</script>");
                    }
                        
                }
            }
           
        }


        protected void gvEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEmpID.Text = gvEmployee.SelectedRow.Cells[1].Text;
            lblLastName.Text = gvEmployee.SelectedRow.Cells[2].Text;
            lblFirstName.Text = gvEmployee.SelectedRow.Cells[3].Text;
            lblMiddleName.Text = gvEmployee.SelectedRow.Cells[4].Text;
            lblComName.Text = gvEmployee.SelectedRow.Cells[6].Text;
            lblPos.Text = gvEmployee.SelectedRow.Cells[7].Text;
            lblComID.Text = gvEmployee.SelectedRow.Cells[5].Text;
            int ComID = int.Parse(Session["CompanyID"].ToString());
            lblYourCompanyID.Text = ComID.ToString();
            lblComID.Visible = false;
            lblYourCompanyID.Visible = false;
            btnSubmit.Visible = true;
        }
    }
}