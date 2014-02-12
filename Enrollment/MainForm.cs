using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

//imports
using DHELTASSys.AuditTrail;
using DHELTASSys.Modules;

namespace Enrollment
{
	delegate void Function();	// a simple delegate for marshalling calls from event handlers to the GUI thread

	public partial class MainForm : Form
	{
        HRModuleBL obj = new HRModuleBL();
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();
        
        
		public MainForm()
		{
			InitializeComponent();
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void OnTemplate(DPFP.Template template)
		{
			this.Invoke(new Function(delegate()
			{
				Template = template;
				VerifyButton.Enabled = SaveButton.Enabled = (Template != null);
				if (Template != null)
					MessageBox.Show("The fingerprint template is ready for verification and saving", "Fingerprint Enrollment");
				else
					MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
			}));
		}

		private DPFP.Template Template;

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void EnrollButton_Click(object sender, EventArgs e)
        {
            EnrollmentForm Enroller = new EnrollmentForm();
            Enroller.OnTemplate += this.OnTemplate;
            Enroller.ShowDialog();
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            VerificationForm Verifier = new VerificationForm();
            Verifier.Verify(Template);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            obj.Last_name = txtLastname.Text;
            obj.First_name = txtFirstName.Text;
            obj.Middle_name = txtMiddleName.Text;
            obj.Position_name = cmbPosition.Text;
            obj.Company_name = cmbCompany.Text;
            obj.Password = txtTempPassword.Text;

            if (txtTempPassword.Text != txtConfirmTempPassword.Text)
            {

                MessageBox.Show("Password does not match", "Password Mismatch",
                    MessageBoxButtons.OK);
            }
            else
            {
                MemoryStream fingerprintData = new MemoryStream();
                Template.Serialize(fingerprintData);
                fingerprintData.Position = 0;
                BinaryReader br = new BinaryReader(fingerprintData);
                Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);

                obj.Biometric_code = bytes;
                obj.AddAccountSetTempPassword();
            }
        }







	}
}