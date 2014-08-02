using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using DHELTASSys.Modules;
using DHELTASSys.modules;
using DHELTASSYS.DataAccess;

namespace DHELTAFINALPROJECT.DHELTAEMP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        HRModuleBL hr = new HRModuleBL();
        BenefitsModuleBL benefit = new BenefitsModuleBL();
        AttendanceModuleBL attendance = new AttendanceModuleBL();
        DisciplineModuleBL discipline = new DisciplineModuleBL();
        ShiftModuleBL shift = new ShiftModuleBL();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {

                if (Session["Position"].ToString() != "Employee")
                {
                    Response.Redirect(@"~/404.aspx");
                }
                else
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    if (!IsPostBack)
                    {
                        lblIDNumber.Text = (string)(Session["EmployeeID"].ToString());
                        lblFullName.Text = (string)(Session["LastName"].ToString()) + ", " + (Session["FirstName"].ToString());
                        lblPosition.Text = "(" + (string)(Session["Position"].ToString()) + ")";
                        lblLastName.Text = (string)(Session["LastName"].ToString());
                        lblFirstName.Text = (string)(Session["FirstName"].ToString());
                        lblMiddleName.Text = (string)(Session["MiddleName"].ToString());
                        lblPosinfo.Text = (string)(Session["Position"].ToString());
                        lblCompanyName.Text = (string)(Session["CompanyName"].ToString());
                        lblSSSNumber.Text = (string)(Session["SSS"].ToString());
                        lblPhilHealthNumber.Text = (string)(Session["PhilHealth"].ToString());

                        txtIDNumber.Text = lblIDNumber.Text;
                        txtLastName.Text = lblLastName.Text;
                        txtFirstName.Text = lblFirstName.Text;
                        txtMiddleName.Text = lblMiddleName.Text;
                        lblEditPosition.Text = lblPosinfo.Text;
                        lblEditCompanyName.Text = lblCompanyName.Text;
                        txtSSSNumber.Text = lblSSSNumber.Text;
                        txtPhilHealthNumber.Text = lblPhilHealthNumber.Text;

                        benefit.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvEmployee.DataSource = benefit.ViewEmployeeBenefits();
                        gvEmployee.DataBind();

                        gvDepedent.DataSource = benefit.ViewDependents();
                        gvDepedent.DataBind();

                        attendance.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvAttendanceSummary.DataSource = attendance.GetPersonalAttendanceRecord();
                        gvAttendanceSummary.DataBind();

                        discipline.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvOffenses.DataSource = discipline.DisplayOffense();
                        gvOffenses.DataBind();

                        shift.Emp_id = int.Parse(Session["EmployeeID"].ToString());
                        gvShiftSummary.DataSource = shift.ViewEmployeeShift();
                        gvShiftSummary.DataBind();

                        hr.Company_name = Session["CompanyName"].ToString();
                        hr.Department_name = Session["Department"].ToString();
                        gvSupervisor.DataSource = hr.GetEmployeeSupervisor();
                        gvSupervisor.DataBind();
                   }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!(txtFirstName.Text == String.Empty || txtLastName.Text == String.Empty || txtMiddleName.Text == String.Empty))
            {
                try
                {
                    UpdateProfile();
                }
                catch
                {
                    Response.Write("<script>alert('Make sure all fields are filled-up in the correct format and there should be no empty fields except SSS and Philhealth');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Last name, First name and Middle name must not be empty.');</script>");
            }
        }


        //Gets the information at PostBack
        void RefreshProfile()
        {

            //Assign session values to respective labels
            lblIDNumber.Text = (string)(Session["EmployeeID"].ToString());
            lblFullName.Text = (string)(Session["LastName"].ToString()) + ", " + (Session["FirstName"].ToString());
            lblPosition.Text = "(" + (string)(Session["Position"].ToString()) + ")";
            lblLastName.Text = (string)(Session["LastName"].ToString());
            lblFirstName.Text = (string)(Session["FirstName"].ToString());
            lblMiddleName.Text = (string)(Session["MiddleName"].ToString());
            lblPosinfo.Text = (string)(Session["Position"].ToString());
            lblCompanyName.Text = (string)(Session["CompanyName"].ToString());
            lblSSSNumber.Text = (string)(Session["SSS"].ToString());
            lblPhilHealthNumber.Text = (string)(Session["PhilHealth"].ToString());

            //assign values to the update panel
            txtIDNumber.Text = lblIDNumber.Text;
            txtLastName.Text = lblLastName.Text;
            txtFirstName.Text = lblFirstName.Text;
            txtMiddleName.Text = lblMiddleName.Text;
            lblEditPosition.Text = lblPosinfo.Text;
            lblEditCompanyName.Text = lblCompanyName.Text;
            txtSSSNumber.Text = lblSSSNumber.Text;
            txtPhilHealthNumber.Text = lblPhilHealthNumber.Text;

            benefit.Emp_id = int.Parse(Session["EmployeeID"].ToString());
            gvEmployee.DataSource = benefit.ViewEmployeeBenefits();
            gvEmployee.DataBind();

            gvDepedent.DataSource = benefit.ViewDependents();
            gvDepedent.DataBind();

            attendance.Emp_id = int.Parse(Session["EmployeeID"].ToString());
            gvAttendanceSummary.DataSource = attendance.GetPersonalAttendanceRecord();
            gvAttendanceSummary.DataBind();

            txtIDNumber.Enabled = false;
        }

        //Update employee information
        void UpdateProfile()
        {
            hr.Emp_id = int.Parse(txtIDNumber.Text);
            hr.Last_name = txtLastName.Text.Trim().Replace("<", "").Replace(">", "");
            hr.First_name = txtFirstName.Text.Trim().Replace("<", "").Replace(">", "");
            hr.Middle_name = txtMiddleName.Text.Trim().Replace("<", "").Replace(">", "");
            hr.Sss_Number = int.Parse(txtSSSNumber.Text);
            hr.Philhealth_number = int.Parse(txtPhilHealthNumber.Text);

            hr.UpdateProfile();

            //set datatabe for retrieving data
            DataTable dtUser = hr.LogIn();

            string updatedLastname = dtUser.Rows[0][2].ToString();
            string updatedFirstname = dtUser.Rows[0][3].ToString();
            string updatedMiddlename = dtUser.Rows[0][4].ToString();
            string updatedCompanyID = dtUser.Rows[0][7].ToString();
            string updatedDepartment = dtUser.Rows[0][5].ToString();
            string updatedPosition = dtUser.Rows[0][6].ToString();
            string updatedCompanyname = dtUser.Rows[0][8].ToString();
            string updatedEmailadd = dtUser.Rows[0][9].ToString();
            string updatedSSS = dtUser.Rows[0][16].ToString();
            string updatedPhilhealth = dtUser.Rows[0][17].ToString();

            //Set sessions for updating sessions employee information
            Session.Add("EmployeeID", dtUser.Rows[0][0].ToString());
            Session.Add("LastName", dtUser.Rows[0][2].ToString());
            Session.Add("FirstName", updatedFirstname);
            Session.Add("MiddleName", dtUser.Rows[0][4].ToString());
            Session.Add("CompanyID", updatedCompanyID);
            Session.Add("Department", updatedDepartment);
            Session.Add("Position", updatedPosition);
            Session.Add("CompanyName", updatedCompanyname);
            Session.Add("EmailAdd", updatedEmailadd);
            Session.Add("Gender", dtUser.Rows[0][10].ToString());
            Session.Add("Address", dtUser.Rows[0][11].ToString());
            Session.Add("Contact", dtUser.Rows[0][12].ToString());
            Session.Add("Birthdate", dtUser.Rows[0][15].ToString());
            Session.Add("SSS", updatedSSS);
            Session.Add("PhilHealth", updatedPhilhealth);


            //Assign new updated data to respective labels
            lblIDNumber.Text = dtUser.Rows[0][0].ToString();
            lblFullName.Text = updatedLastname + ", " + updatedFirstname;
            lblPosition.Text = updatedPosition;
            lblLastName.Text = updatedLastname;
            lblFirstName.Text = updatedFirstname;
            lblMiddleName.Text = updatedMiddlename;
            lblPosinfo.Text = updatedPosition;
            lblCompanyName.Text = updatedCompanyname;
            lblSSSNumber.Text = updatedSSS;
            lblPhilHealthNumber.Text = updatedPhilhealth;

            //assign values to the update panel
            txtIDNumber.Text = lblIDNumber.Text;
            txtLastName.Text = lblLastName.Text;
            txtFirstName.Text = lblFirstName.Text;
            txtMiddleName.Text = lblMiddleName.Text;
            lblEditPosition.Text = lblPosinfo.Text;
            lblEditCompanyName.Text = lblCompanyName.Text;
            txtSSSNumber.Text = lblSSSNumber.Text;
            txtPhilHealthNumber.Text = lblPhilHealthNumber.Text;

        }

        protected void btnAddDedepent_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/AddDependent.aspx");
        }
    }
}