using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DHELTASSYS.DataAccess;
using DHELTASSys.Modules;

namespace DHELTASSYSMEGABYTE
{
    public partial class index : System.Web.UI.Page
    {

        HRModuleBL hr = new HRModuleBL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                hr.Emp_id = int.Parse(txtEmployeeID.Text);
                hr.Password = txtPassword.Text;

                int i;
                if (int.TryParse(txtEmployeeID.Text, out i))
                {
                    hr.Emp_id = int.Parse(txtEmployeeID.Text);
                    DataTable dtUser = hr.LogIn();
                    DataTable dtCompanyName = hr.GetCompany();


                    if (dtUser.Rows[0][1].ToString() == txtPassword.Text && dtUser.Rows[0][0].Equals(int.Parse(txtEmployeeID.Text)))
                    {
                        Response.Write(dtUser.Rows[0][1].ToString());

                        Session.Add("EmployeeID", dtUser.Rows[0][0].ToString());
                        Session.Add("LastName", dtUser.Rows[0][2].ToString());
                        Session.Add("FirstName", dtUser.Rows[0][3].ToString());
                        Session.Add("MiddleName", dtUser.Rows[0][4].ToString());
                        Session.Add("CompanyID", dtUser.Rows[0][7].ToString());
                        Session.Add("Department", dtUser.Rows[0][5].ToString());
                        Session.Add("Position", dtUser.Rows[0][6].ToString());
                        Session.Add("CompanyName", dtUser.Rows[0][8].ToString());
                        Session.Add("EmailAdd", dtUser.Rows[0][9].ToString());
                        Session.Add("Gender", dtUser.Rows[0][10].ToString());
                        Session.Add("Address", dtUser.Rows[0][11].ToString());
                        Session.Add("Contact", dtUser.Rows[0][12].ToString());
                        Session.Add("Birthdate", dtUser.Rows[0][15].ToString());
                        Session.Add("SSS", dtUser.Rows[0][16].ToString());
                        Session.Add("PhilHealth", dtUser.Rows[0][17].ToString());
                        Session.Add("Company", dtCompanyName.Rows[0][0].ToString());

                        if (dtUser.Rows[0][6].ToString() == "Employee")
                        {
                            Session.Add("MainPage", @"~/EmployeeMainPage.aspx");
                            Response.Redirect("EmployeeMainPage.aspx");
                        }
                        else if (dtUser.Rows[0][6].ToString() == "Supervisor")
                        {
                            Session.Add("MainPage", @"~/SVMainPage.aspx");
                            Response.Redirect("SVMainPage.aspx");
                        }
                        else if (dtUser.Rows[0][6].ToString() == "Vice President")
                        {
                            Session.Add("MainPage", @"~/VPMainPage.aspx");
                            Response.Redirect("VPMainPage.aspx");
                        }
                        else if (dtUser.Rows[0][6].ToString() == "HR Manager")
                        {
                            Session.Add("MainPage", @"~/HRMainPage.aspx");
                            Response.Redirect("HRMainPage.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Incorrect ID Number or Password')</script");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Incorrect ID Number or Password')</script");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Incorrect ID Number or Password')</script");
                }
            }
            catch
            {
                Response.Write("<script>alert('Invalid Inputs')</script");
            }
        }
    }
}
