using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

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
                        MakeReport("The fingerprint was VERIFIED.\n" + dt.Rows[x][0].ToString());
                        i++;
                    }
                    else
                    {
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




	}
}