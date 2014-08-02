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
        
        private int hrManager_id;
        public int Emp_id
        {
            get { return hrManager_id; }
            set { hrManager_id = value; }
        }

        private int supervisor_id;
        public int Supervisor_id
        {
            get { return supervisor_id; }
            set { supervisor_id = value; }
        }

        private string report_type;
        public string Report_type
        {
            get { return report_type; }
            set { report_type = value; }
        }

        private string report_quarter;
        public string Report_quarter
        {
            get { return report_quarter; }
            set { report_quarter = value; }
        }

        private int report_year;
        public int Report_year
        {
            get { return report_year; }
            set { report_year = value; }
        }

        private int report_month;
        public int Report_month
        {
            get { return report_month; }
            set { report_month = value; }
        }

            private int report_id;
        public int Report_id
        {
            get { return report_id; }
            set { report_id = value; }
        }

        #endregion

        public DataTable SelectEmployeeID_Supervisor()
        {
            string SelectEmployeeID_SupervisorQuery = "EXECUTE SelectEmployeeID_Supervisor'" +
                Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(SelectEmployeeID_SupervisorQuery);
        }


        public DataTable SelectEvaluationStatusEmployeeID()
        {
            string SelectEvaluationStatusEmployeeIDQuery = "EXECUTE SelectEvaluationStatusEmployeeID'" +
                Report_quarter + "','" +
                Report_year + "','" +
                Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(SelectEvaluationStatusEmployeeIDQuery);
        }

        public DataTable SelectReportStatusID()
        {
            string SelectReportStatusIDQuery = "EXECUTE SelectReportStatusID'" +
                Report_quarter + "','" +
                Report_year + "','" +
                Supervisor_id + "','" +
                Report_type + "'";
            return DHELTASSysDataAccess.Select(SelectReportStatusIDQuery);
        }

        #region Process
        public DataTable SelectGenerateReportDate()
        {
            string SelectGenerateReportDateQuery = "EXECUTE SelectGenerateReportDate'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(SelectGenerateReportDateQuery);
        }

        public DataTable SelectAssessReportDate()
        {
            string SelectAssessReportDateQuery = "EXECUTE SelectAssessReportDate'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(SelectAssessReportDateQuery);
        }

        public DataTable ViewActiveEmployees()
        {
            string viewActiveEmployeesQuery = "EXECUTE ViewActiveEmployees'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewActiveEmployeesQuery);
        }

        public DataTable ViewCurrentEmployeeLeaveBalance()
        {
            string viewCurrentEmployeeLeaveBalanceQuery = "EXECUTE ViewCurrentEmployeeLeaveBalance'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewCurrentEmployeeLeaveBalanceQuery);
        }

        public DataTable ViewEmployeeOffenses()
        {
            string ViewEmployeeOffensesQuery = "EXECUTE ViewEmployeeOffenses '" +
                Supervisor_id + "','" +
                Report_year + "'";
            ;
            return DHELTASSysDataAccess.Select(ViewEmployeeOffensesQuery);
        }

        public DataTable ViewOffensesCount()
        {
            string viewOffensesCountQuery = "EXECUTE ViewOffensesCount'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewOffensesCountQuery);
        }

        public DataTable ViewOffensesCountDate()
        {
            string viewOffensesCountDateQuery = "EXECUTE ViewOffensesCountDate'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewOffensesCountDateQuery);
        }

        public DataTable ViewDaysPresentCount()
        {
            string viewDaysPresentCountQuery = "EXECUTE ViewDaysPresentCount'" + 
                Supervisor_id + "','" +
                Report_year + "'";
            return DHELTASSysDataAccess.Select(viewDaysPresentCountQuery);
        }

        public DataTable ViewEmployeeAttendance_Supervisor_1Q()
        {
            string ViewEmployeeAttendance_Supervisor_1QQuery = "EXECUTE ViewEmployeeAttendance_Supervisor_1Q'" + 
                Supervisor_id + "','" +
                Report_year + "'";
            return DHELTASSysDataAccess.Select(ViewEmployeeAttendance_Supervisor_1QQuery);
        }

        public DataTable ViewEmployeeAttendance_Supervisor_2Q()
        {
            string ViewEmployeeAttendance_Supervisor_2QQuery = "EXECUTE ViewEmployeeAttendance_Supervisor_2Q'" +
                Supervisor_id + "','" +
                Report_year + "'";
            return DHELTASSysDataAccess.Select(ViewEmployeeAttendance_Supervisor_2QQuery);
        }

        public DataTable ViewEmployeeAttendance_Supervisor_3Q()
        {
            string ViewEmployeeAttendance_Supervisor_3QQuery = "EXECUTE ViewEmployeeAttendance_Supervisor_3Q'" +
                Supervisor_id + "','" +
                Report_year + "'";
            return DHELTASSysDataAccess.Select(ViewEmployeeAttendance_Supervisor_3QQuery);
        }

        public DataTable ViewEmployeeAttendance_Supervisor_4Q()
        {
            string ViewEmployeeAttendance_Supervisor_4QQuery = "EXECUTE ViewEmployeeAttendance_Supervisor_4Q'" +
                Supervisor_id + "','" +
                Report_year + "'";
            return DHELTASSysDataAccess.Select(ViewEmployeeAttendance_Supervisor_4QQuery);
        }

        public DataTable ViewDaysPresentCountDate()
        {
            string viewDaysPresentCountDateQuery = "EXECUTE ViewDaysPresentCountDate'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewDaysPresentCountDateQuery);
        }

        public DataTable ViewDaysLateCount()
        {
            string viewDaysLateCountQuery = "EXECUTE ViewDaysLateCount'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewDaysLateCountQuery);
        }

        public DataTable ViewDaysLateCountDate()
        {
            string viewDaysLateCountDateQuery = "EXECUTE ViewDaysLateCountDate'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewDaysLateCountDateQuery);
        }

        public DataTable ViewAttendanceCount()
        {
            string viewAttendanceCountQuery = "EXECUTE ViewAttendanceCount'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewAttendanceCountQuery);
        }

        public DataTable ViewAttendanceCountDate()
        {
            string viewAttendanceCountDateQuery = "EXECUTE ViewAttendanceCountDate'" + Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(viewAttendanceCountDateQuery);
        }

        public DataTable ViewEvaluationEmployees()
        {
            string viewEvaluationEmployeeQuery = "EXECUTE ViewEvaluationEmployees'" +
                Supervisor_id + "','" +
                Report_quarter + "','" +
                Report_year + "'";
            return DHELTASSysDataAccess.Select(viewEvaluationEmployeeQuery);
        }

        public DataTable ViewEvaluationStatusSupervisor() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusSupervisorQuery = "EXECUTE ViewEvaluationStatusSupervisor '" +
                Report_quarter + "','" +
                Report_year + "','" +
                Supervisor_id + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusSupervisorQuery);
            return dtSupervisorEvaluationStatus;
        }

        public DataTable ViewReportStatusHRManager()
        {
            string ViewReportStatusQuery = "EXECUTE ViewReportStatusHRManager'" +
                Report_quarter + "','" +
                Report_year + "','" +
                Emp_id + "'";
            return DHELTASSysDataAccess.Select(ViewReportStatusQuery);
        }

        public DataTable ViewReportStatusHRManagerID()
        {
                string ViewReportStatusHRManagerIDQuery = "EXECUTE ViewReportStatusHRManagerID'" +
                Report_id + "'";
            return DHELTASSysDataAccess.Select(ViewReportStatusHRManagerIDQuery);
        }

        public DataTable ViewReportStatusSupervisor()
        {
            string ViewReportStatusQuery = "EXECUTE ViewReportStatusSupervisor'" +
                Report_quarter + "','" +
                Report_year + "','" +
                Supervisor_id + "'";
            return DHELTASSysDataAccess.Select(ViewReportStatusQuery);
        }

        public DataTable ViewReportStatusAnnual() // [HR MANAGER] View ALL employees of the company
        {
            string ViewReportStatusAnnualQuery = "EXECUTE ViewReportStatusAnnual '" +
                Emp_id + "','" +
                Report_year + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewReportStatusAnnualQuery);
            return dtSupervisorEvaluationStatus;
        }

        public DataTable ViewReportStatusSupervisorAnnual() // [HR MANAGER] View ALL employees of the company
        {
            string ViewReportStatusSupervisorAnnualQuery = "EXECUTE ViewReportStatusSupervisorAnnual '" +
                Emp_id + "','" +
                Report_year + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewReportStatusSupervisorAnnualQuery);
            return dtSupervisorEvaluationStatus;
        }

        public void AddReportStatusHRManager() // [HR MANAGER] Add new question according to position
        {
            string AddReportStatusHRManagerQuery = "EXECUTE AddReportStatusHRManager '" +
                Emp_id + "','" +
                Report_id + "'";
            DHELTASSysDataAccess.Modify(AddReportStatusHRManagerQuery);
        }

        public void AddReportStatusSupervisor() // [HR MANAGER] Add new question according to position
        {
            string AddReportStatusSupervisorQuery = "EXECUTE AddReportStatusSupervisor '" +
                Report_quarter + "','" +
                Supervisor_id + "','" +
                Report_type + "'";
            DHELTASSysDataAccess.Modify(AddReportStatusSupervisorQuery);
        }
        #endregion
    }
}
