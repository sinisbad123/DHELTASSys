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

	public partial class CreateAccount : Form
	{
        HRModuleBL obj = new HRModuleBL();
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();
        
		public CreateAccount(int emp_id)
		{
			InitializeComponent();
            audit.Emp_id = emp_id;
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


        





        private void EnrollButton_Click(object sender, EventArgs e)
        {
            EnrollmentForm Enroller = new EnrollmentForm();
            Enroller.OnTemplate += this.OnTemplate;
            Enroller.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            obj.Last_name = txtLastname.Text;
            obj.First_name = txtFirstName.Text;
            obj.Middle_name = txtMiddleName.Text;
            obj.Position_name = cmbPosition.Text;
            obj.Company_name = cmbCompany.Text;
            obj.Password = txtTempPassword.Text;
            obj.Department_name = cmbDepartment.Text;

            if (obj.Last_name == string.Empty) //Validation for empty texts
            {
                MessageBox.Show("Last name can't be empty!");
            } else if (obj.First_name == string.Empty) 
            {
                MessageBox.Show("First name can't be empty!");
            }
            else if (obj.Middle_name == string.Empty)
            {
                MessageBox.Show("Middle name can't be empty!");
            }
            else if (obj.Position_name == string.Empty)
            {
                MessageBox.Show("Position name can't be empty!");
            }
            else if (obj.Department_name == string.Empty)
            {
                MessageBox.Show("Deparment can't be empty!");
            }
            else if (obj.Company_name == string.Empty)
            {
                MessageBox.Show("Company name can't be empty!");
            }
            else if (obj.Password == string.Empty)
            {
                MessageBox.Show("Password can't be empty!");
            }
            else if (txtConfirmTempPassword.Text == string.Empty)
            {
                MessageBox.Show("Please verify your input password!");
            }
            else
            {

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
                    audit.AddAuditTrail("Created account for " + obj.First_name + " " + obj.Last_name + ".");
                }
            }
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            VerificationForm Verifier = new VerificationForm();
            Verifier.Verify(Template);
        }
	}
}