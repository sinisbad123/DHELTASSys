using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Imports
using System.Data;
using DHELTASSYS.DataAccess;
using System.Data.SqlClient;
//using DHELTASSYS.AuditTrail;

namespace DHELTASSys.Modules
{
    class HRModuleBL
    {
        //DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();

        #region Getters and Setters
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

        private string department_name;
        public string Department_name
        {
            get { return department_name; }
            set { department_name = value; }
        }

        private int department_id;
        public int Department_id
        {
            get { return department_id; }
            set { department_id = value; }
        }
        #endregion
        //Methods

        //Create account and set temporary password for employee
        
        public void AddAccountSetTempPassword()
        {
            if (Position_name == "Supervisor") //If employee is supervisor
            {
                string cmd = "EXECUTE AddAccountSetTempPassword '" + Password + "',"
                + "'" + Last_name + "',"
                + "'" + First_name + "',"
                + "'" + Middle_name + "',"
                + "'" + Position_name + "',"
                + "'" + Company_name + "',"
                + "'" + Department_name + "',"
                + "'" + Biometric_code + "'";
                DHELTASSysDataAccess.Modify(cmd);

                string cmdTwo = "Execute AddSupervisor";
                DHELTASSysDataAccess.Modify(cmdTwo);
            }
            else //If employee isn't a supervisor
            {
                string cmd = "EXECUTE AddAccountSetTempPassword '" + Password + "',"
                + "'" + Last_name + "',"
                + "'" + First_name + "',"
                + "'" + Middle_name + "',"
                + "'" + Position_name + "',"
                + "'" + Company_name + "',"
                + "'" + Department_name + "',"
                + "'" + Biometric_code + "'";
                DHELTASSysDataAccess.Modify(cmd);

            }

            
            
        }


        //Employee will enter permanent password for account
        public void AddPermanentPasswordForAccount()
        {
            string cmd = "EXECUTE AddPermanentPasswordForAccount"
                + "'" + Password + "',"
                + "'" + Emp_id + "',";
            DHELTASSysDataAccess.Modify(cmd);
            //DHELTASSysAuditTrail.AddAuditTrail( "Changed password.");
        }

        //Employee adds his/her account details
        public void UpdateAccountDetails()
        {
            string cmd = "EXECUTE AddAccountDetails"
                + "'" + Email + "',"
                + "'" + Address + "',"
                + "'" + Primary_Number + "',"
                + "'" + Alternative_Number + "',"
                + "'" + City + "',"
                + "'" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(cmd);
            //DHELTASSysAuditTrail.AddAuditTrail("Account details updated.");
        }

        //Displays all employees' information
        public DataTable ViewEmployeeInformation()
        {
            string cmd = "EXECUTE ViewEmployeeInformation"
                + "'" + Company_id + "'";
            DataTable dtEmployees = DHELTASSysDataAccess.Select(cmd);
            return dtEmployees;
        }

        //Verifies account login in the forms application
        public DataTable AccountEnrollmentLogin()
        {
            string cmd = "EXECUTE AccountEnrollmentLogin"
                + "'" + Emp_id + "',"
                + "'" + Password + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        //Check if HR Manager
        public DataTable CheckIfHRManager()
        {
            string cmd = "EXECUTE CheckIfHRManager"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        //Get Position
        public DataTable GetPosition()
        {
            string cmd = "EXECUTE GetPosition"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        //Get Employee Details for Display and Update
        public DataTable GetEmployeeDetails()
        {
            string cmd = "Execute GetEmployeeDetails"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetEmployeeSupervisor()
        {
            string cmd = "EXECUTE GetEmployeeSupervisor"
                + "'" + Company_name + "',"
                + "'" + Department_name + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        //Get Company
        public DataTable GetCompany()
        {
            string cmd = "EXECUTE GetCompany"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        //Get Department
        public DataTable GetDepartment()
        {
            string cmd = "EXECUTE GetDepartment"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        //Get employee information
        public DataTable GetEmployeeInformation()
        {
            string cmd = "EXECUTE GetEmployeeInformation"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable LogIn()
        {
            string login = "EXECUTE loginUser'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(login);
            return dt;
        }

        public void UpdateProfile()
        {
            string update = "EXECUTE UpdateProfile"
                + "'" + Emp_id + "',"
                + "'" + Last_name + "',"
                + "'" + First_name + "',"
                + "'" + Middle_name + "',"
                + "'" + Sss_Number + "',"
                + "'" + Philhealth_number + "'";
            DHELTASSysDataAccess.Modify(update);
                
            
        }


        public DataTable SeleectAllEmployeeByCompany()
        {
            string selectAllEmployee = "EXECUTE SelectAllEmployee";
            DataTable dt = DHELTASSysDataAccess.Select(selectAllEmployee);
            return dt;
        }

    }
}
