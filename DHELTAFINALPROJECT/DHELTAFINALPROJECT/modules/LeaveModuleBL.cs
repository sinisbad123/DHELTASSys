using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Imports
using System.Data;
using DHELTASSYS.DataAccess;

namespace DHELTASSys.modules
{
    public class LeaveModuleBL
    {
        #region Getters & Setters
        private int leave_req_id;
        public int Leave_req_id
        {
            get { return leave_req_id; }
            set { leave_req_id = value; }
        }

        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private int leave_type_id;
        public int Leave_type_id
        {
            get { return leave_type_id; }
            set { leave_type_id = value; }
        }

        private string date_from;
        public string Date_from
        {
            get { return date_from; }
            set { date_from = value; }
        }

        private string date_to;
        public string Date_to
        {
            get { return date_to; }
            set { date_to = value; }
        }

        private string reason;
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        private string hr_manager_decision;
        public string Hr_manager_decision
        {
            get { return hr_manager_decision; }
            set { hr_manager_decision = value; }
        }

        private string vp_decision;
        public string Vp_decision
        {
            get { return vp_decision; }
            set { vp_decision = value; }
        }
        #endregion

        #region Processes

        #region Decision
        public void EmployeeLeaveVPDecision()
        {
            string employeLeaveVPDecisionQuery = "EXECUTE VPDecision '" + Vp_decision + "', '" + Leave_req_id + "'";
            DHELTASSysDataAccess.Modify(employeLeaveVPDecisionQuery);
        }

        public void UpdateLeaveBalance()
        {
            string updateLeaveBalanceQuery = "EXECUTE UpdateLeaveBalance '" + Leave_req_id + "','"+ Emp_id+"'";
            DHELTASSysDataAccess.Modify(updateLeaveBalanceQuery);
        }

        public DataTable ViewVPLeaveRequest()
        {
            string viewVPLeaveRequestQuery = "EXECUTE ViewVPLeaveRequest '" + Emp_id + "'";
            DataTable dtVPLeaveRequest = DHELTASSysDataAccess.Select(viewVPLeaveRequestQuery);
            return dtVPLeaveRequest;
        }

        public void EmployeeLeaveHRDecision()
        {
            string employeLeaveHRDecisionQuery = "EXECUTE HRDecision  '" + Hr_manager_decision + "', '" + Leave_req_id + "'";
            DHELTASSysDataAccess.Modify(employeLeaveHRDecisionQuery);
        }
        public DataTable viewLeaveRequestEmployeeID()
        {
            string viewLeaveRequestEmployeeIDQuery = "EXECUTE viewLeaveRequestEmployeeID '" + Leave_req_id + "'";
            DataTable dtLeaveRequestEmployeeID = DHELTASSysDataAccess.Select(viewLeaveRequestEmployeeIDQuery);
            return dtLeaveRequestEmployeeID;
        }

        public DataTable ViewHRLeaveRequest()
        {
            string viewHRLeaveRequestQuery = "EXECUTE ViewHRLeaveRequest '" + Emp_id + "'";
            DataTable dtHRLeaveRequest = DHELTASSysDataAccess.Select(viewHRLeaveRequestQuery);
            return dtHRLeaveRequest;
        }

        #endregion

        #region Requests
        public void AddLeaveRequest()
        {
            string AddLeaveRequestQuery = "EXECUTE AddLeaveRequests '" + Emp_id + "','" + Leave_type_id + "','" + Date_from + "','" + Date_to + "','" + Reason + "'";
            DHELTASSysDataAccess.Modify(AddLeaveRequestQuery);
        }

        public DataTable ViewLeaveRequest()
        {
            string viewLeaveRequestQuery = "EXECUTE ViewLeaveRequest '" + Emp_id + "'";
            DataTable dtLeaveRequest = DHELTASSysDataAccess.Select(viewLeaveRequestQuery);
            return dtLeaveRequest;
        }

        public DataTable ViewPreviousLeaveRequest()
        {
            string viewPreviousLeaveRequestQuery = "EXECUTE ViewPreviousLeaveRequest '" + Emp_id + "'";
            DataTable dtPreviousLeaveRequest = DHELTASSysDataAccess.Select(viewPreviousLeaveRequestQuery);
            return dtPreviousLeaveRequest;
        }

        public DataTable ViewLatestLeaveRequest()
        {
            string viewLeaveRequestQuery = "EXECUTE ViewLatestLeaveRequest '" + Emp_id + "'";
            DataTable dtLeaveRequest = DHELTASSysDataAccess.Select(viewLeaveRequestQuery);
            return dtLeaveRequest;
        }

        #endregion

        #region Balance
        public DataTable ViewLeaveBalance()
        {
            string viewLeaveBalanceQuery = "EXECUTE ViewEmployeeLeaveBalance '" + Emp_id + "'";
            DataTable dtLeaveBalance = DHELTASSysDataAccess.Select(viewLeaveBalanceQuery);
            return dtLeaveBalance;
        }

        public void AddLeaveBalance()
        {
            string addLeaveBalanceQuery = "EXECUTE AddLeaveBalance '" + Emp_id + "','" + Leave_type_id + "'";
            DHELTASSysDataAccess.Modify(addLeaveBalanceQuery);
        }

        public void ResetLeaveBalance()
        {
            string resetLeaveBalanceQuery = "EXECUTE ResetLeaveBalance '" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(resetLeaveBalanceQuery);
        }
        #endregion

        #region Leave Type
        public DataTable SelectEmployeeLeaveTypeEmployeeID()
        {
            string selectEmployeeLeaveTypeEmployeeIDQuery = "EXECUTE SelectEmployeeLeaveTypeEmployeeID '" + Emp_id + "'";
            DataTable dtSelectEmployeeLeaveTypeEmployeeID = DHELTASSysDataAccess.Select(selectEmployeeLeaveTypeEmployeeIDQuery);
            return dtSelectEmployeeLeaveTypeEmployeeID;
        }

        public DataTable SelectAllLeaveType()
        {
            string selectAllLeaveTypeQuery = "EXECUTE SelectAllLeaveType";
            DataTable dtSelectAllLeaveType = DHELTASSysDataAccess.Select(selectAllLeaveTypeQuery);
            return dtSelectAllLeaveType;
        }
        #endregion

        #endregion
    }
}


//Default Page MyLeaveRequests.aspx