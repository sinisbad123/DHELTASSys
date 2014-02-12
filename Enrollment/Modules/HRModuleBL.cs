using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Imports
using System.Data;
using DHELTASSys.DataAccess;
using DHELTASSys.AuditTrail;

namespace DHELTASSys.Modules
{
    class HRModuleBL
    {
        
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string last_name;
        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        private string first_name;
        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }

        private string middle_name;
        public string Middle_name
        {
            get { return middle_name; }
            set { middle_name = value; }
        }

        private string position_name;
        public string Position_name
        {
            get { return position_name; }
            set { position_name = value; }
        }

        private string company_name;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string primary_Number;
        public string Primary_Number
        {
            get { return primary_Number; }
            set { primary_Number = value; }
        }

        private string alternative_Number;
        public string Alternative_Number
        {
            get { return alternative_Number; }
            set { alternative_Number = value; }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        private int sss_Number;
        public int Sss_Number
        {
            get { return sss_Number; }
            set { sss_Number = value; }
        }

        private int philHealth_number;
        public int Philhealth_number
        {
            get { return philHealth_number; }
            set { philHealth_number = value; }
        }

        private Byte[] biometric_code;
        public Byte[] Biometric_code
        {
            get { return biometric_code; }
            set { biometric_code = value; }
        }

        private string employee_status;
        public string Employee_status
        {
            get { return employee_status; }
            set { employee_status = value; }
        }

        private int company_id;
        public int Company_id
        {
            get { return company_id; }
            set { company_id = value; }
        }

        //Methods

        //Create account and set temporary password for employee
        
        public void AddAccountSetTempPassword()
        {
            string cmd = "EXECUTE AddAccountSetTempPassword '" + Password + "',"
                + "'" + Last_name + "',"
                + "'" + First_name + "',"
                + "'" + Middle_name + "',"
                + "'" + Position_name + "',"
                + "'" + Company_name + "',"
                + "'" + Biometric_code + "'";
            DHELTASSysDataAccess.Modify(cmd);
            //DHELTASSysAuditTrail.AddAuditTrail("Created account for '" + First_name + "', '" + Last_name + "'.");
            
        }


        public void AddPermanentPasswordForAccount()
        {
            string cmd = "EXECUTE AddPermanentPasswordForAccount"
                + "'" + Password + "',"
                + "'" + Emp_id + "',";
            DHELTASSysDataAccess.Modify(cmd);
            //DHELTASSysAuditTrail.AddAuditTrail( "Changed password.");
        }

        public void AddAccountDetails()
        {
            string cmd = "EXECUTE AddAccountDetails"
                + "'" + Email + "',"
                + "'" + Gender + "',"
                + "'" + Address + "',"
                + "'" + Primary_Number + "',"
                + "'" + Alternative_Number + "',"
                + "'" + City + "',"
                + "'" + Birthdate + "',"
                + "'" + Sss_Number + "',"
                + "'" + Philhealth_number + "',"
                + "'" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(cmd);
            //DHELTASSysAuditTrail.AddAuditTrail("Account details updated.");
        }

        public void EnrollBiometricCode()
        {
            string cmd = "EXECUTE EnrollBiometricCode"
                + "'" + Biometric_code + "',"
                + "'" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(cmd);
            //DHELTASSysAuditTrail.AddAuditTrail("Fingerprint Enrolled.");
        }

        public DataTable ViewEmployeeInformation()
        {
            string cmd = "EXECUTE ViewEmployeeInformation"
                + "'" + Company_id + "'";
            DataTable dtEmployees = DHELTASSysDataAccess.Select(cmd);
            return dtEmployees;
        }

        public DataTable SelectPositions()
        {
            string cmd = "EXECUTE SelectPositions";
            DataTable dtPositions = DHELTASSysDataAccess.Select(cmd);
            return dtPositions;
        }


    }
}
