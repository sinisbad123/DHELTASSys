using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

//imports
using DHELTASSys.DataAccess;
using DHELTASSys.Modules;
using DHELTASSys.AuditTrail;


/* * * * * *  * * *  * * *  * * *  * * *  * * *  * * *  * * *  * * *  * * * 
 * 
 * Developed by: Marcus Ang                                                 
 * With the help of: Michael del Rosario, Mack Sola and Karol Alambra
 * 
 * DHELTASSys Accouunt Enrollment module
 * Finished: June 21, 2014
 * 
 * 
 * 
 * 
 * 
 * 
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace Enrollment
{
    public partial class HRLogin : Form
    {
        HRModuleBL obj = new HRModuleBL();
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();

        
        public HRLogin()
        {
            InitializeComponent();
        }



        private void txtLogin_Click(object sender, EventArgs e)
        {
            //check if account is admin account
            if (txtEmpID.Text == "superadmin" && txtPassword.Text == "admin12345")
            {
                CreateAccount frm = new CreateAccount();

                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

                txtEmpID.Text = "";
                txtPassword.Text = "";

                frm.Show();
                this.Hide();
            }
            else
            {

                try
                {
                    obj.Emp_id = int.Parse(txtEmpID.Text);
                    obj.Password = txtPassword.Text;
                }
                catch
                {
                    MessageBox.Show("Invalid input type, please input numerical values.");
                }

                //if account logged in is a valid account 
                if (obj.AccountEnrollmentLogin().Rows.Count >= 1)
                {
                    if (obj.CheckIfHRManager().Rows.Count == 0)
                    {
                        MessageBox.Show("You are not allowed to access this system!");
                    }
                    else
                    {
                        CreateAccount frm = new CreateAccount();

                        frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

                        txtEmpID.Text = "";
                        txtPassword.Text = "";

                        frm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Username and Password is incorrect!");
                }
            }
            
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
