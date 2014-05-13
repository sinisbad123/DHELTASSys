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
    public class DisciplineModuleBL
    {
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private string offense_type;
        public string Offense_type
        {
            get { return offense_type; }
            set { offense_type = value; }
        }

        private string statement;
        public string Statement
        {
            get { return statement; }
            set { statement = value; }
        }

        private string proofFileName;
        public string ProofFileName
        {
            get { return proofFileName; }
            set { proofFileName = value; }
        }

        private string proofDate;
        public string ProofDate
        {
            get { return proofDate; }
            set { proofDate = value; }
        }

        private int offense_emp_id;
        public int Offense_emp_id
        {
            get { return offense_emp_id; }
            set { offense_emp_id = value; }
        }

        private string offense_info;
        public string Offense_info
        {
            get { return offense_info; }
            set { offense_info = value; }
        }

        private string offense_category_name;
        public string Offense_category_name
        {
            get { return offense_category_name; }
            set { offense_category_name = value; }
        }

        private string company_name;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string department_name;
        public string Department_name
        {
            get { return department_name; }
            set { department_name = value; }
        }

        private int filed_emp;
        public int Filed_emp
        {
            get {return filed_emp;}
            set {filed_emp = value;}
        }

        private int filing_emp;
        public int Filing_emp
        {
            get {return filing_emp;}
            set {filing_emp = value;}
        }

        private string decision;
        public string Decision
        {
            get { return decision; }
            set { decision = value; }
        }

        public DataTable DisplayOffenseType()
        {
            string cmd = "EXECUTE DisplayOffenseType";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public void AddOffense()
        {
            string cmd = "EXECUTE AddOffense"
                + "'" + Filed_emp + "',"
                + "'" + Filing_emp + "',"
                + "'" + Offense_info + "',"
                + "'" + DateTime.Now.ToString("MM-dd-yyyy") + "',"
                + "'" + Statement + "'";
            DHELTASSysDataAccess.Modify(cmd);
        }

        public void AddProof()
        {
            string cmd = "EXECUTE AddProof"
            + "'" + ProofFileName + "',"
            + "'" + DateTime.Now.ToString("MM-dd-yyyy") + "'";
            DHELTASSysDataAccess.Modify(cmd);
        }

        public void AddOffenseType()
        {
            string cmd = "EXECUTE AddOffenseType"
                + "'" + Offense_type + "',"
                + "'" + Offense_info + "',"
                + "'" + Offense_category_name + "'";
            DHELTASSysDataAccess.Modify(cmd);
        }

        public void AddOffenseCategory()
        {
            string cmd = "EXECUTE AddOffenseCategory"
                + "'" + Offense_category_name + "'";
            DHELTASSysDataAccess.Modify(cmd);
        }

        public DataTable GetOffenseCategory()
        {
            string cmd = "EXECUTE GetOffenseCategory";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable DisplayEmployeeLastNameFirstName()
        {
            string cmd = "EXECUTE DisplayEmployeeLastNameFirstName"
                + "'" + Company_name + "',"
                + "'" + Department_name + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable DisplayOffense()
        {
            string cmd = "EXECUTE DisplayOffense"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable DisplayOffenseTypeForFiling()
        {
            string cmd = "EXECUTE DisplayOffenseTypeForFiling";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable DisplayPendingEmployeeOffenses()
        {
            string cmd = "EXECUTE DisplayPendingEmployeeOffenses"
                + "'" + Company_name + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetAllEmployeeOffenses()
        {
            string cmd = "EXECUTE GetAllEmployeeOffenses"
                + "'" + Company_name + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetEmployeeOffense()
        {
            string cmd = "EXECUTE GetEmployeeOffense"
                + "'" + Emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetProof()
        {
            string cmd = "EXECUTE GetProof"
                + "'" + Offense_emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public DataTable GetOffense()
        {
            string cmd = "EXECUTE GetOffense"
                + "'" + Offense_emp_id + "'";
            DataTable dt = DHELTASSysDataAccess.Select(cmd);
            return dt;
        }

        public void AddOffenseDecision()
        {
            string cmd = "EXECUTE AddOffenseDecision"
                + "'" + Decision + "',"
                + "'" + Offense_emp_id + "'";
            DHELTASSysDataAccess.Modify(cmd);
            
        }
    }
}