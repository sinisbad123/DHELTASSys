using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Imports
using System.Data;
using DHELTASSYS.DataAccess;

namespace DHELTASSys
{
    namespace DataHandling
    {
        public class DHELTASSysDataHandling
        {
            #region Getters & Setters


            private int department_id;
            public int Department_id
            {
                get { return department_id; }
                set { department_id = value; }
            }

            private int company_id;
            public int Company_id
            {
                get { return company_id; }
                set { company_id = value; }
            }
            private int emp_id;
            public int Emp_id
            {
                get { return emp_id; }
                set { emp_id = value; }
            }

            private int selected_emp_id;
            public int Selected_emp_id
            {
                get { return selected_emp_id; }
                set { selected_emp_id = value; }
            }

            private string position_name;
            public string Position_name
            {
                get { return position_name; }
                set { position_name = value; }
            }

            private string department_name;
            public string Department_name
            {
                get { return department_name; }
                set { department_name = value; }
            }

            //private string company_name;
            //public string Company_name
            //{
            //    get { return company_name; }
            //    set { company_name = value; }
            //}

            #endregion

            #region Process
            public DataTable SelectAllPosition()
            {
                string selectAllPositionQuery = "EXECUTE SelectAllPosition";
                return DHELTASSysDataAccess.Select(selectAllPositionQuery);
            }

            public DataTable SelectAllPositionTransfer()
            {
                string selectAllPositionTransfer = "EXECUTE ViewAllEmployeePositionTransfer'" + Emp_id + "','" + Company_id + "'";
                return DHELTASSysDataAccess.Select(selectAllPositionTransfer);
            }
            
            public DataTable SelectAllDepartment()
            {
                string selectAllDepartmentQuery = "EXECUTE SelectAllDepartment";
                return DHELTASSysDataAccess.Select(selectAllDepartmentQuery);
            }
            
            public DataTable SelectCompanyEmployees()
            {
                string selectCompanyEmployeesQuery = "EXECUTE SelectCompanyEmployees '" + Emp_id + "'";
                return DHELTASSysDataAccess.Select(selectCompanyEmployeesQuery);
            }

            public DataTable SelectCompanyEmployeesEmployeeID()
            {
                string selectCompanyEmployeesEmployeeIDQuery = "EXECUTE SelectCompanyEmployeesEmployeeID '" + Emp_id + "','" + Selected_emp_id + "'";
                return DHELTASSysDataAccess.Select(selectCompanyEmployeesEmployeeIDQuery);
            }

            public DataTable SelectCompanyEmployeesPosition()
            {
                string selectCompanyEmployeesPositionQuery = "EXECUTE SelectCompanyEmployeesPosition '" + Emp_id + "','" + Position_name + "'";
                return DHELTASSysDataAccess.Select(selectCompanyEmployeesPositionQuery);
            }

            public DataTable SelectCompanyEmployeesDepartment()
            {
                string selectCompanyEmployeesDepartmentQuery = "EXECUTE SelectCompanyEmployeesDepartment '" + Emp_id + "','" + Department_name + "'";
                return DHELTASSysDataAccess.Select(selectCompanyEmployeesDepartmentQuery);
            }

            //public DataTable SelectUserCompany()
            //{
            //    string selectUserCompanyQuery = "EXECUTE SelectUserCompany '" + Emp_id + "'";
            //    return DHELTASSysDataAccess.Select(selectUserCompanyQuery);
            //}

            public DataTable SelectEmployeeCompany()
            {
                string select = "EXECUTE SelectEmployeeCompany'" + Company_id + "'";
                return DHELTASSysDataAccess.Select(select);
            }

            public DataTable SelectDepartment()
            {
                string select = "EXECUTE SelectUnderSuperVisor'" + Department_name + "'";
                return DHELTASSysDataAccess.Select(select);
            }
            #endregion
        }
    }
}