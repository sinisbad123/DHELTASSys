using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

//imports
using DHELTASSys.Modules;

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
	delegate void Function();	// a simple delegate for marshalling calls from event handlers to the GUI thread

	public partial class CreateAccount : Form
	{
        HRModuleBL obj = new HRModuleBL();
        
		public CreateAccount()
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


        





        private void EnrollButton_Click(object sender, EventArgs e)
        {
            EnrollmentForm Enroller = new EnrollmentForm();
            Enroller.OnTemplate += this.OnTemplate;
            Enroller.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            //Assign values to respective properties of the HRModule
            obj.Last_name = txtLastname.Text;
            obj.First_name = txtFirstName.Text;
            obj.Middle_name = txtMiddleName.Text;
            obj.Position_name = cmbPosition.SelectedValue.ToString();
            obj.Company_name = cmbCompany.SelectedValue.ToString();
            obj.Password = txtTempPassword.Text;
            obj.Department_name = cmbDepartment.SelectedValue.ToString();
            obj.Shift_id = int.Parse(cmbShift.SelectedValue.ToString());
            obj.From_date = dateFrom.Value.ToString("yyyy-MM-dd");
            obj.To_date = dateTo.Value.ToString("yyyy-MM-dd");

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
                //If password doesn't match
                if (txtTempPassword.Text != txtConfirmTempPassword.Text)
                {

                    MessageBox.Show("Password does not match", "Password Mismatch",
                        MessageBoxButtons.OK);
                }
                //proceed with streaming and serializing fingerprint template
                else
                {

                    MemoryStream fingerprintData = new MemoryStream();
                    Template.Serialize(fingerprintData);
                    fingerprintData.Position = 0;
                    BinaryReader br = new BinaryReader(fingerprintData);
                    byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);



                    obj.Biometric_code = bytes;
                    obj.AddAccountSetTempPassword();
                    obj.AssignEmployeeShift();

                    DataTable dtLeaveType = obj.SelectAllLeaveType();
                    if (dtLeaveType.Rows.Count >= 1)
                    {
                        for (int leaveType = 0; leaveType < dtLeaveType.Rows.Count; leaveType++)
                        {
                            obj.Leave_type_id = int.Parse(dtLeaveType.Rows[leaveType][0].ToString());
                            obj.AddLeaveBalance();
                        }
                    }

                    MessageBox.Show("Account Created for " + txtLastname.Text + "," + txtFirstName.Text);

                    txtConfirmTempPassword.Text = "";
                    txtFirstName.Text = "";
                    txtLastname.Text = "";
                    txtMiddleName.Text = "";
                    txtTempPassword.Text = "";
                    cmbCompany.Text = "";
                    cmbDepartment.Text = "";
                    cmbPosition.Text = "";

                }
            }
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            VerificationForm Verifier = new VerificationForm();
            Verifier.Verify(Template);
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            //Fill up ze combo boxes LIKE A BOWWZZZ
            cmbCompany.DataSource = obj.GetCompanyForDropdown();
            cmbCompany.DisplayMember = "company_name";
            cmbCompany.ValueMember = "company_name";

            cmbDepartment.DataSource = obj.GetDepartmentForDropdown();
            cmbDepartment.DisplayMember = "department_name";
            cmbDepartment.ValueMember = "department_name";

            cmbPosition.DataSource = obj.GetPositionForDropdown();
            cmbPosition.DisplayMember = "position_name";
            cmbPosition.ValueMember = "position_name";

            cmbShift.DataSource = obj.SelectShift();
            cmbShift.DisplayMember = "Shift";
            cmbShift.ValueMember = "ID";

            cmbCompany.Text = "";
            cmbDepartment.Text = "";
            cmbPosition.Text = "";
        }
	}
}