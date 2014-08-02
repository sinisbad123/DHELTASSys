using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using DHELTASSys.DataHandling;
using DHELTASSYS.DataAccess;
using DHELTASSys.Modules;



namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        DHELTASSysDataHandling dataHandling = new DHELTASSysDataHandling();
        TransferModuleBL transfer = new TransferModuleBL();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {

                if (Session["Position"].ToString() != "HR Manager")
                {
                    Response.Redirect(@"~/404.aspx");
                }
                else
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    if (!IsPostBack)
                    {
                        DataTable dtPosition = dataHandling.SelectAllPosition();
                        /*dpPosition.DataSource = dtPosition;
                        dpPosition.DataTextField = "position_name";
                        dpPosition.DataValueField = "position_name";
                        dpPosition.DataBind();*/

                       /* dpPosition.Items.Insert(0, new ListItem("All Position", "All"));
                        for (int i = 0; i < dtPosition.Rows.Count; i++)
                        {
                            dpPosition.Items.Insert(i + 1, new ListItem(dtPosition.Rows[i]["position_name"].ToString()));
                        }
                        dpPosition.DataBind();*/

                        dataHandling.Company_id = int.Parse(Session["CompanyID"].ToString());
                        dataHandling.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvEmployee.DataSource = dataHandling.SelectAllPositionTransfer();
                        gvEmployee.DataBind();
                    }
                }
            }
        }

        /*protected void dpPosition_SelectedIndexChanged(object sender, EventArgs e)
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
           /* else if (dpPosition.SelectedItem.Text == "Supervisor")
            {
                gvEmployee.DataSource = transfer.ViewEmployeeRequest();
                gvEmployee.DataBind();
            }
            else if (dpPosition.SelectedItem.Text == "Vice President")
            {
                gvEmployee.DataSource = transfer.ViewEmployeeRequest();
                gvEmployee.DataBind();

            }*/
           /* else
            {
                gvEmployee.DataSource = transfer.ViewEmployeeRequest();
                gvEmployee.DataBind();
            }
        }*/

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
            lblEmpID.Text = gvEmployee.SelectedRow.Cells[0].Text;
            lblLastName.Text = gvEmployee.SelectedRow.Cells[1].Text;
            lblFirstName.Text = gvEmployee.SelectedRow.Cells[2].Text;
            lblMiddleName.Text = gvEmployee.SelectedRow.Cells[3].Text;
            lblComName.Text = gvEmployee.SelectedRow.Cells[5].Text;
            //lblPos.Text = gvEmployee.SelectedRow.Cells[6].Text;
            lblComID.Text = gvEmployee.SelectedRow.Cells[4].Text;
            int ComID = int.Parse(Session["CompanyID"].ToString());
            lblYourCompanyID.Text = ComID.ToString();
            lblComID.Visible = false;
            lblYourCompanyID.Visible = false;
            btnSubmit.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            /*if (lblEmpID.Text == null)
            {
                Response.Write("<script>alert('Select an Employee first')</script>");
            }
            else
            {
                //You need a calendar input for this, hindi alam ng user anong format ang ilalagay dyan
                if (txtDate.Text == null)
                {
                    Response.Write("<script>alert('Please select a desired date to transfer the employee')</script>");
                }
                else
                {
                    // DateTime i;
                    /*if (DateTime.TryParse(txtDate.Text, out i))
                    {*/

            /* try
             {
                 DateTime selectedDate = DateTime.Parse(txtDate.Text);
                 if (selectedDate > DateTime.Now)
                 {

                     transfer.CompanyID = int.Parse(lblComID.Text);
                     transfer.YourComID = int.Parse(lblYourCompanyID.Text);
                     transfer.Emp_id = int.Parse(lblEmpID.Text);
                     transfer.Date_transfer = selectedDate.ToShortDateString();//txtDate.ToString();
                     transfer.ModifyRequests();

                     transfer.AddEmpRequest();
                     Response.Write("<script>alert('Successfully Added!')</script>");
                 }
                 else
                 {
                     Response.Write("<script>alert('Date should be later than now')</script>");
                 }
             }
             catch
             {
                 Response.Write("<script>alert('Please input a valid date!')</script>");
             }
         }
         /*else
         {
             Response.Write("<script>alert('Please select a desired date to transfer the employee')</script>");
         }*/

            if (lblEmpID.Text == null)
            {
                Response.Write("<script>alert('Select an Employee first')</script>");
            }
            else
            {
                //You need a calendar input for this, hindi alam ng user anong format ang ilalagay dyan
                if (txtDate.Text == null)
                {
                    Response.Write("<script>alert('Please select a desired date to transfer the employee')</script>");
                }
                else
                {
                    if (gvEmployee.Rows.Count < 0)
                    {
                        Response.Write("<script>alert('Please select a desired date to transfer the employee')</script>");
                    }
                    else
                    {

                        DateTime i;

                        if (DateTime.TryParse(txtDate.Text, out i))
                        {
                            DateTime selectedDate = DateTime.Parse(txtDate.Text);
                            if (DateTime.Parse(txtDate.Text) > DateTime.Now)
                            {

                                transfer.CompanyID = int.Parse(lblComID.Text);
                                transfer.YourComID = int.Parse(lblYourCompanyID.Text);
                                transfer.Emp_id = int.Parse(lblEmpID.Text);
                                transfer.Date_transfer = selectedDate.ToShortDateString();//DateTime.Parse(txtDate.Text);
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
        }
    }
}