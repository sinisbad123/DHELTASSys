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
using Marcucu;

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
        NetworkUtility network = new NetworkUtility();

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
            try
            {
                int i = 0;

                int x = 0;

                //Get DataTable containing fingerprint and Employee ID
                DataTable dt = attendance.GetEmployeeFingerprint();

                //Number of rows retrieved
                int count = dt.Rows.Count;


                do
                {


                    //Current fingerprint of the row
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
                    //If there's a fingerprint template
                    if (features != null)
                    {
                        // Compare the feature set with our template
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verificator.Verify(features, Template, ref result);
                        UpdateStatus(result.FARAchieved);

                        //if the fingerprint matched any record
                        if (result.Verified)
                        {
                            MakeReport("The fingerprint was VERIFIED.");

                            attendance.Emp_id = int.Parse(dt.Rows[x][0].ToString());
                            try
                            {
                                //check if the employee hasn't timed in
                                if (attendance.CheckIfEmployeeHasLoggedIn().Rows.Count == 0)
                                {
                                    DateTime timeIn = DateTime.Parse(attendance.GetTimeInOfEmployee().Rows[0][0].ToString());
                                    DateTime currentTime = DateTime.Parse(DateTime.Now.ToShortTimeString());
                                    attendance.MacAddress = network.GetMacAddress();
                                    // Time him in
                                    if (!attendance.CheckIfEmployeeIsOnLeave())
                                    {
                                        if (currentTime.Subtract(timeIn).TotalMinutes <= 0)
                                        {
                                            attendance.TimeInEmployee("Present");
                                            MessageBox.Show("Successfully Timed-in.");
                                            break;
                                        }
                                        else if (currentTime.Subtract(timeIn).TotalMinutes <= 20)
                                        {
                                            attendance.TimeInEmployee("Late");
                                            MessageBox.Show("Successfully Timed-in.");
                                            break;
                                        }
                                        else if (currentTime.Subtract(timeIn).TotalMinutes > 20)
                                        {
                                            attendance.TimeInEmployee("Absent");
                                            MessageBox.Show("Successfully Timed-in.");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Employee is on leave!");
                                    }
                                }
                                else
                                {
                                    //Check if employee has time-out correctly or incorrectly using the time-out in shift table for
                                    //that employee
                                    DateTime timeOut = DateTime.Parse(attendance.GetTimeOutOfEmployee().Rows[0][0].ToString());
                                    DateTime currentTime = DateTime.Parse(DateTime.Now.ToShortTimeString());
                                    if (attendance.CheckIfEmployeeHasTimedOut().Rows.Count >= 1 && currentTime.Subtract(timeOut).TotalMinutes < -180)
                                    {
                                        MessageBox.Show("Can't allow time-out, time-out at least 3 hours before your shift.");
                                        break;
                                    }
                                    else if (attendance.CheckIfEmployeeHasTimedOut().Rows.Count >= 1 && currentTime.Subtract(timeOut).TotalMinutes >= -180)
                                    {
                                        attendance.TimeOutEmployee();
                                        MessageBox.Show("Successfully Timed-out.");
                                        break;
                                    }
                                    else if (attendance.CheckIfEmployeeHasTimedOut().Rows.Count >= 0)
                                    {
                                        MessageBox.Show("You have already timed-out.");
                                        break;
                                    }

                                }
                            }
                            catch
                            {
                                MessageBox.Show("Report to the HR Manager for your expired shift schedule.");
                            }
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.ToString());
                            //}
                            //Get out of the loop since you found the matching fingerprint or an error has occured
                            i++;
                        }
                        else // else continue
                        {
                            x++;
                        }

                        //Stop if the loop reaches the maximum row retrieved
                        if (x == count) 
                        {
                            MessageBox.Show("No records found.");
                            i++; 
                        }
                    }
                } while (i == 0);
            }
            catch(Exception ex)
            {
                //this means that there are no rows retreived
                MessageBox.Show(ex.ToString());
            }
		}

		private void UpdateStatus(int FAR)
		{
			// Show "False accept rate" value
			SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
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