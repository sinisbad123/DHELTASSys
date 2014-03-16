using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//imports
using DHELTASSys.Modules;

namespace DHELTASSys_Attendance
{
    public partial class RegisterTerminal : Form
    {
        AttendanceModuleBL attendance = new AttendanceModuleBL();

        public string macAddress;

        public RegisterTerminal(string mac_address)
        {
            InitializeComponent();

            DataTable dt = attendance.GetCompanyForDropdown();


            cmbCompany.DataSource = dt;
            cmbCompany.ValueMember = "company_name";
            cmbCompany.DisplayMember = "company_name";
            macAddress = mac_address;
        }

        

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtTerminalName.Text == String.Empty)
            {
                MessageBox.Show("Please input Terminal Name.");
            }
            else
            {
                attendance.Company_name = cmbCompany.Text;
                attendance.TerminalName = txtTerminalName.Text;
                attendance.MacAddress = macAddress;

                attendance.AddTerminal();

                MessageBox.Show("Terminal Successfully Registered!");
                this.Close();
            }
        }
    }
}
