using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;
using DHELTASSys.DataHandling;
using DHELTASSys.AuditTrail;

namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        ShiftModuleBL shift = new ShiftModuleBL();
        DHELTASSysDataHandling dataHandling = new DHELTASSysDataHandling();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {
                userSession = int.Parse(Session["EmployeeID"].ToString());
                if (Session["Position"].ToString() == "HR Manager")
                {
                    if (!IsPostBack)
                    {
                        dataHandling.Emp_id = userSession;
                        gvEmployee.DataSource = dataHandling.SelectCompanyEmployees();
                        gvEmployee.DataBind();

                        DataTable dtShift = shift.selectShift();
                        cmbShift.DataSource = dtShift;
                        cmbShift.DataTextField = "Shift";
                        cmbShift.DataValueField = "ID";
                        cmbShift.DataBind();
                    }
                }
                else if (Session["Position"].ToString() == "Employee")
                {
                    Response.Redirect(@"~/DHELTAEMP/EmployeeMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Vice President")
                {
                    Response.Redirect(@"~/DHELTAVP/VPMainPage.aspx");
                }
                else if (Session["Position"].ToString() == "Supervisor")
                {
                    Response.Redirect(@"~/DHELTASV/SVMainPage.aspx");
                }
            }
        }

        protected void gvEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            shift.Emp_id = int.Parse(gvEmployee.SelectedRow.Cells[1].Text);
            DataTable dtEmployeeShift = shift.ViewEmployeeShift();
            if (dtEmployeeShift.Rows.Count == 1)
            {
                lblTimeIn.Text = dtEmployeeShift.Rows[0][0].ToString();
                lblTimeOut.Text = dtEmployeeShift.Rows[0][1].ToString();
                DateTime latestFromDate = DateTime.Parse(dtEmployeeShift.Rows[0][2].ToString());
                DateTime latestToDate = DateTime.Parse(dtEmployeeShift.Rows[0][3].ToString());
                lblDateFrom.Text = latestFromDate.ToShortDateString();
                lblDateTo.Text = latestToDate.ToShortDateString();

                lblDateFrom.Visible = true;
                lblDateTo.Visible = true;
            }
            else
            {
                lblTimeIn.Text = "Null";
                lblTimeOut.Text = "Null";
                lblDateFrom.Text = "Null";
                lblDateTo.Text = "Null";
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtDateFrom.Text == "" || txtDateTo.Text == "")
            {
                Response.Write("<script>alert('Please select two dates')</script>");
            }
            else
            {
                DateTime fromDate = DateTime.Parse(txtDateFrom.Text);
                DateTime toDate = DateTime.Parse(txtDateTo.Text);
                for (int employee = 0; employee < gvEmployee.Rows.Count; employee++)
                {
                    CheckBox cb = (CheckBox)gvEmployee.Rows[employee].Cells[0].FindControl("chckbxShift");
                    if (cb.Checked)
                    {
                        shift.Emp_id = int.Parse(gvEmployee.Rows[employee].Cells[1].Text);
                        DataTable dtSelectedEmployeeShift = shift.ViewEmployeeShift();
                        if (dtSelectedEmployeeShift.Rows.Count == 1)
                        {
                            DateTime selectedEmployeeToDate = DateTime.Parse(dtSelectedEmployeeShift.Rows[0][3].ToString());
                            //lblIn.Text = selectedEmployeeToDate.ToShortDateString();
                            if (fromDate.Date > selectedEmployeeToDate.Date)
                            {
                                if (fromDate <= toDate)
                                {
                                    shift.Shift_id = int.Parse(cmbShift.SelectedValue);
                                    shift.From_date = fromDate;
                                    shift.To_date = toDate;
                                    shift.AssignNewEmployeeShift();

                                    auditTrail.Emp_id = userSession;
                                    auditTrail.AddAuditTrail("Updated shift of employee " + shift.Emp_id + "");

                                    //Response.Write("<script>alert('Shift Successfully Added.')</script>");
                                    cb.Checked = false;
                                }
                                else
                                {
                                    txtDateTo.Text = "";
                                    Response.Write("<script>alert('Date to must be the same or later than the Date from.')</script>");
                                    continue;
                                }
                            }
                            else
                            {
                                txtDateFrom.Text = "";
                                txtDateTo.Text = "";
                                Response.Write("<script>alert('Select a date from later than the current date to.')</script>");
                                continue;
                            }
                        }
                        else
                        {
                            if (fromDate.Date > DateTime.Now.Date)
                            {
                                if (fromDate <= toDate)
                                {
                                    shift.Shift_id = int.Parse(cmbShift.SelectedValue);
                                    shift.From_date = fromDate;
                                    shift.To_date = toDate;
                                    shift.AssignNewEmployeeShift();

                                    auditTrail.Emp_id = userSession;
                                    auditTrail.AddAuditTrail("Updated shift of employee " + shift.Emp_id + "");

                                    //Response.Write("<script>alert('Shift Successfully Added.')</script>");
                                    cb.Checked = false;
                                }
                                else
                                {
                                    txtDateTo.Text = "";
                                    Response.Write("<script>alert('Date to must be the same or later than the Date from.')</script>");
                                    continue;
                                }
                            }
                            else
                            {
                                txtDateFrom.Text = "";
                                txtDateTo.Text = "";
                                Response.Write("<script>alert('Select a date from later than today.')</script>");
                                continue;
                            }
                        }
                    }
                }
                Response.Redirect("HRShifting.aspx");
            }
        }
    }
}