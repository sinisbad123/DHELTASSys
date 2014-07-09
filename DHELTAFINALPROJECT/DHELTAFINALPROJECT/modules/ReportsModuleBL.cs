using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using DHELTASSYS.DataAccess;
using DHELTASSys.AuditTrail;

namespace DHELTASSys.modules
{
    public class ReportsModuleBL
    {
        #region Getters & Setters
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private string eval_quarter;
        public string Eval_quarter
        {
            get { return eval_quarter; }
            set { eval_quarter = value; }
        }

        private int eval_year;
        public int Eval_year
        {
            get { return eval_year; }
            set { eval_year = value; }
        }

        private int eval_month;
        public int Eval_month
        {
            get { return eval_month; }
            set { eval_month = value; }
        }

        #endregion

        #region Process
        public DataTable SelectGenerateReportDate()
        {
            string viewActiveEmployeesQuery = "EXECUTE SelectGenerateReportDate'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewActiveEmployeesQuery);
        }

        public DataTable ViewActiveEmployees()
        {
            string viewActiveEmployeesQuery = "EXECUTE ViewActiveEmployees'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewActiveEmployeesQuery);
        }

        public DataTable ViewCurrentEmployeeLeaveBalance()
        {
            string viewCurrentEmployeeLeaveBalanceQuery = "EXECUTE ViewCurrentEmployeeLeaveBalance'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewCurrentEmployeeLeaveBalanceQuery);
        }

        public DataTable ViewEmployeeOffenses()
        {
            string ViewEmployeeOffensesQuery = "EXECUTE ViewEmployeeOffenses '" +
                Emp_id + "','" +
                Eval_year + "'";
            ;
            return DHELTASSysDataAccess.Select(ViewEmployeeOffensesQuery);
        }

        public DataTable ViewOffensesCount()
        {
            string viewOffensesCountQuery = "EXECUTE ViewOffensesCount'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewOffensesCountQuery);
        }

        public DataTable ViewOffensesCountDate()
        {
            string viewOffensesCountDateQuery = "EXECUTE ViewOffensesCountDate'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewOffensesCountDateQuery);
        }

        public DataTable ViewDaysPresentCount()
        {
            string viewDaysPresentCountQuery = "EXECUTE ViewDaysPresentCount'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewDaysPresentCountQuery);
        }

        public DataTable ViewDaysPresentCountDate()
        {
            string viewDaysPresentCountDateQuery = "EXECUTE ViewDaysPresentCountDate'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewDaysPresentCountDateQuery);
        }

        public DataTable ViewDaysLateCount()
        {
            string viewDaysLateCountQuery = "EXECUTE ViewDaysLateCount'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewDaysLateCountQuery);
        }

        public DataTable ViewDaysLateCountDate()
        {
            string viewDaysLateCountDateQuery = "EXECUTE ViewDaysLateCountDate'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewDaysLateCountDateQuery);
        }

        public DataTable ViewAttendanceCount()
        {
            string viewAttendanceCountQuery = "EXECUTE ViewAttendanceCount'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewAttendanceCountQuery);
        }

        public DataTable ViewAttendanceCountDate()
        {
            string viewAttendanceCountDateQuery = "EXECUTE ViewAttendanceCountDate'" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewAttendanceCountDateQuery);
        }

        public DataTable ViewEvaluationEmployees()
        {
            string viewEvaluationEmployeeQuery = "EXECUTE ViewEvaluationEmployees'" +
                Emp_id + "','" +
                Eval_quarter + "','" +
                Eval_year + "'";
            return DHELTASSysDataAccess.Select(viewEvaluationEmployeeQuery);
        }

        #endregion
    }
}