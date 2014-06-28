using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

//imports
using DHELTASSYS.DataAccess;
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

        public DataTable GetPersonalAttendanceRecord()
        {
            string cmd = "EXECUTE GetPersonalAttendanceRecord"
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

    }
}