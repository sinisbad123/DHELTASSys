using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

//imports
using DHELTASSys.DataAccess;
using DHELTASSys.AuditTrail;

namespace DHELTASSys.Modules
{
    public class AttendanceModuleBL
    {
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private string company_name;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string macAddress;
        public string MacAddress
        {
            get { return macAddress; }
            set { macAddress = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        private string terminalName;
        public string TerminalName
        {
            get { return terminalName; }
            set { terminalName = value; }
        }

        public DataTable AccountEnrollmentLogin()
        {
            string cmd = "EXECUTE AccountEnrollmentLogin"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public void AddTerminal()
        {
            string cmd = "EXECUTE AddTerminal"
                + "'" + Company_name + "',"
                + "'" + TerminalName + "',"
                + "'" + MacAddress + "'";
            DHELTASSysDataAccess.Modify(cmd);
        }

        public DataTable CheckIfEmployeeHasLoggedIn()
        {
            string cmd = "EXECUTE CheckIfEmployeeHasLoggedIn"
                + "'" + Emp_id + "',"
                + "'" + DateTime.Now.ToString("MM-dd-yyyy") + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable CheckIfEmployeeHasTimedOut()
        {
            string cmd = "EXECUTE CheckIfEmployeeHasTimedOut"
                + "'" + Emp_id + "',"
                + "'" + DateTime.Now.ToString("MM-dd-yyyy") + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable CheckIfMacAddressRegistered()
        {
            string cmd = "EXECUTE CheckIfMacAddressRegistered"
                + "'" + MacAddress + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetCompanyForDropdown()
        {
            string cmd = "EXECUTE GetCompanyForDropdown";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetEmployeeFingerprint()
        {
            string cmd = "EXECUTE GetEmployeeFingerprint";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetPersonalAttendanceRecord()
        {
            string cmd = "EXECUTE GetPersonalAttendanceRecord"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetTimeInOfEmployee()
        {
            string cmd = "EXECUTE GetTimeInOfEmployee"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetTimeOutOfEmployee()
        {
            string cmd = "EXECUTE GetTimeOutOfEmployee"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetEmployeesForAttendanceViewing()
        {
            string cmd = "EXECUTE GetEmployeesForAttendanceViewing"
                + "'" + Company_name + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public void TimeInEmployee(string status)
        {
            string cmd = "EXECUTE TimeInEmployee"
                + "'" + Emp_id + "',"
                + "'" + DateTime.Now.ToShortTimeString() + "',"
                + "'" + MacAddress + "',"
                + "'" + DateTime.Now.ToString("MM-dd-yyyy") + "',"
                + "'" + status + "'";
            DHELTASSysDataAccess.Modify(cmd);
        }

        public void TimeOutEmployee()
        {
            string cmd = "EXECUTE TimeOutEmployee"
                + "'" + Emp_id + "',"
                + "'" + DateTime.Now.ToShortTimeString() + "',"
                + "'" + DateTime.Now.ToString("MM-dd-yyyy") + "',"
                + "'" + MacAddress + "'";
            DHELTASSysDataAccess.Modify(cmd);
        }

    }
}