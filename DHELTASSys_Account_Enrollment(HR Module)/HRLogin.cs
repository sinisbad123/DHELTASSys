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
            int text;

            if (int.TryParse(txtEmpID.Text, out text))
            {



                obj.Emp_id = int.Parse(txtEmpID.Text);
                audit.Emp_id = int.Parse(txtEmpID.Text);
                obj.Password = txtPassword.Text;

                if (obj.AccountEnrollmentLogin().Rows.Count == 0)
                {
                    MessageBox.Show("Username and Password is incorrect!");
                }
                else if (obj.CheckIfHRManager().Rows.Count == 0)
                {
                    MessageBox.Show("You are not allowed to access this system!");
                }
                else
                {
                    CreateAccount frm = new CreateAccount(int.Parse(txtEmpID.Text));

                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

                    audit.AddAuditTrail("Has logged in into the Fingerprint Enrollment System.");

                    txtEmpID.Text = "";
                    txtPassword.Text = "";

                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please input numerical values for Employee ID!!");
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
