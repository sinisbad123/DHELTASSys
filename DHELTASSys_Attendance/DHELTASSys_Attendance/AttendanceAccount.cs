using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

//imports
using DHELTASSys.AuditTrail;
using DHELTASSys.Modules;

namespace Enrollment
{
	delegate void Function();	// a simple delegate for marshalling calls from event handlers to the GUI thread

	public partial class TimeInAccount : Form
	{
        AttendanceModuleBL attendance = new AttendanceModuleBL();
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();
        
		public TimeInAccount()
		{
			InitializeComponent();
            attendance.MacAddress = GetMacAddress();

            DataTable dt = attendance.CheckIfMacAddressRegistered();

            if (dt.Rows.Count == 0)
            {
                string macAddress = GetMacAddress();
                DHELTASSys_Attendance.RegisterTerminal register = new DHELTASSys_Attendance.RegisterTerminal(macAddress);

                register.FormClosed += new FormClosedEventHandler(register_FormClosed);

                register.Show();
                this.Opacity = 0;
            }
            

		}

        public string GetMacAddress()
        {
            NetworkInterface[] ni = NetworkInterface.GetAllNetworkInterfaces();
            String macAddress = string.Empty;
            foreach (NetworkInterface adapter in ni)
            {
                if (macAddress == string.Empty)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    macAddress = adapter.GetPhysicalAddress().ToString();
                }
            }

            return macAddress;
        }

        private void btnTimeIn_Click(object sender, EventArgs e)
        {
            int text;

            if (int.TryParse(txtEmployeeID.Text, out text))
            {
                //check if the employee filled in the required fields.
                if (txtEmployeeID.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter Employee ID and Password");
                }
                else
                {
                    attendance.Emp_id = int.Parse(txtEmployeeID.Text);
                    attendance.Password = txtPassword.Text;
                    //check if valid account
                    if (attendance.AccountEnrollmentLogin().Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Employee ID or Password");
                    }
                    else
                    {
                        //check if the employee has timed-in
                        if (attendance.CheckIfEmployeeHasLoggedIn().Rows.Count == 0)
                        {
                            DateTime timeIn = DateTime.Parse(attendance.GetTimeInOfEmployee().Rows[0][0].ToString());
                            DateTime currentTime = DateTime.Parse(DateTime.Now.ToShortTimeString());
                            attendance.MacAddress = GetMacAddress();
                            // Time him in
                            if (currentTime.Subtract(timeIn).TotalMinutes <= 0)
                            {
                                attendance.TimeInEmployee("Present");
                                MessageBox.Show("Successfully Timed-in.");
                            }
                            else if (currentTime.Subtract(timeIn).TotalMinutes <= 20)
                            {
                                attendance.TimeInEmployee("Late");
                                MessageBox.Show("Successfully Timed-in.");
                            }
                            else if (currentTime.Subtract(timeIn).TotalMinutes > 20)
                            {
                                attendance.TimeInEmployee("Absent");
                                MessageBox.Show("Successfully Timed-in.");
                            }
                        }
                        else
                        {
                            //Check if employee has time-out correctly or incorrectly using the time-out in shift table for
                            //that employee
                            DateTime timeOut = DateTime.Parse(attendance.GetTimeOutOfEmployee().Rows[0][0].ToString());
                            DateTime currentTime = DateTime.Parse(DateTime.Now.ToShortTimeString());
                            if (attendance.CheckIfEmployeeHasTimedOut().Rows.Count == 0 && currentTime.Subtract(timeOut).TotalMinutes < -180)
                            {
                                MessageBox.Show("Can't allow time-out, time-out at least 3 hours before your shift.");
                            }
                            else if (attendance.CheckIfEmployeeHasTimedOut().Rows.Count == 0 && currentTime.Subtract(timeOut).TotalMinutes >= -180)
                            {
                                attendance.TimeOutEmployee();
                                MessageBox.Show("Successfully Timed-out.");
                            }
                            else if (attendance.CheckIfEmployeeHasTimedOut().Rows.Count >= 0)
                            {
                                MessageBox.Show("You have already timed-out.");
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input numerical values for Employee ID!");
            }
        }

        void register_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Opacity = 100;
        }

        private void btnLoginBiometrics_Click(object sender, EventArgs e)
        {
            VerificationForm verification = new VerificationForm();

            verification.FormClosed += new FormClosedEventHandler(verification_FormClosed);

            verification.Show();
            this.Opacity = 0;
        }

        void verification_FormClosed(object sender, EventArgs e)
        {
            this.Opacity = 100;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}