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
using BAHV.Common.Cryptography;

namespace DHELTAFINALPROJECT
{
    public partial class index : System.Web.UI.Page
    {
        HRModuleBL hr = new HRModuleBL();
        AESEncryption aes = new AESEncryption();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            //try
            //{
                    hr.Emp_id = int.Parse(txtEmployeeID.Text);
                    DataTable dtUser = hr.LogIn();

                    //Response.Write(dtUser.Rows[0][1].ToString() + "<br>");
                    ////Response.Write(password);
                    //string hashed = "$2a$10$pGr0pdnzM2Cr2C519Vp2weifyEGKx1v8FLCWS.bT0UtMfFBXBqVOS";
                    //string notHashed = "12345";

                    //if (BCryptEncryption.BCrypt.CheckPassword(notHashed, hashed))
                    //{
                    //    Response.Write("<script>alert('Right!')</script");
                    //}
                    //else
                    //{
                    //    Response.Write("<script>alert('Wrong!')</script");
                    //}
                    string hashing = aes.DecryptString(dtUser.Rows[0][1].ToString());

                    if ( hashing == txtPassword.Text && dtUser.Rows[0][0].Equals(int.Parse(txtEmployeeID.Text)))
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


                        if (dtUser.Rows[0][6].ToString() == "Employee")
                        {
                            Session.Add("MainPage", @"~/DHELTAEMP/EmployeeMainPage.aspx");
                            Response.Redirect(@"~/DHELTAEMP/EmployeeMainPage.aspx");
                        }
                        else if (dtUser.Rows[0][6].ToString() == "Supervisor")
                        {
                            Session.Add("MainPage", @"~/DHELTASV/SVMainPage.aspx");
                            Response.Redirect(@"~/DHELTASV/SVMainPage.aspx");
                        }
                        else if (dtUser.Rows[0][6].ToString() == "Vice President")
                        {
                            Session.Add("MainPage", @"~/DHELTAVP/VPMainPage.aspx");
                            Response.Redirect(@"~/DHELTAVP/VPMainPage.aspx");
                        }
                        else if (dtUser.Rows[0][6].ToString() == "HR Manager")
                        {
                            Session.Add("MainPage", @"~/DHELTAHR/HRMainPage.aspx");
                            Response.Redirect(@"~/DHELTAHR/HRMainPage.aspx");
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

                
            //}
            //catch
            //{
            //    Response.Write("<script>alert('Invalid Inputs')</script>");
            //}
        }
    }
}