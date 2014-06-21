using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

//imports
using DHELTASSys.Modules;

namespace Enrollment
{
	/* NOTE: This form is inherited from the CaptureForm,
		so the VisualStudio Form Designer may not load it properly
		(at least until you build the project).
		If you want to make changes in the form layout - do it in the base CaptureForm.
		All changes in the CaptureForm will be reflected in all derived forms 
		(i.e. in the EnrollmentForm and in the VerificationForm)
	*/
	public class VerificationForm : CaptureForm
	{
        AttendanceModuleBL attendance = new AttendanceModuleBL();

        delegate void Function();

		public void Verify()
		{
			ShowDialog();
		}

		protected override void Init()
		{
			base.Init();
			base.Text = "Fingerprint Verification";
            DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();		// Create a fingerprint template verificator
			UpdateStatus(0);
		}



		protected override void Process(DPFP.Sample Sample)
		{
            int i = 0;

            int x = 6;

            DataTable dt = attendance.GetEmployeeFingerprint();
            

            do
            {
                


                byte[] fingerprint = (byte[])dt.Rows[x][1];

                MemoryStream ms = new MemoryStream(fingerprint);

                DPFP.Template Template = new DPFP.Template();

                Template.DeSerialize(ms);

                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                

                base.Process(Sample);

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, Template, ref result);
                    UpdateStatus(result.FARAchieved);
                    if (result.Verified)
                    {
                        MakeReport("The fingerprint was VERIFIED.");

                        attendance.Emp_id = int.Parse(dt.Rows[x][0].ToString());

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

                        i++;
                    }
                    else
                    {
                        MakeReport("No matching records found.");
                        x++;
                    }
                }
            } while (i == 0);
		}

		private void UpdateStatus(int FAR)
		{
			// Show "False accept rate" value
			SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(581, 354);
            this.Name = "VerificationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

//
	}
}