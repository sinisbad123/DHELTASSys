using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using DHELTASSYS.DataAccess;
//using DHELTASSYS.AuditTrail;

namespace DHELTASSys.Modules
{
    public class TransferModuleBL
    {
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private string date_transfer;
        public string Date_transfer
        {
            get { return date_transfer; }
            set { date_transfer = value; }
        }

        private int transferRequestID;
        public int TransferRequestID
        {
            get { return transferRequestID; }
            set { transferRequestID = value; }
        }

        private int transfreReceivingID;
        public int TransfreReceivingID
        {
            get { return transfreReceivingID; }
            set { transfreReceivingID = value; }
        }

        private int companyID;
        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        

        private string hrManagerDecision;
        public string HrManagerDecision
        {
            get { return hrManagerDecision; }
            set { hrManagerDecision = value; }
        }
        private string vpRequestingDecision;
        public string VpRequestingDecision
        {
            get { return vpRequestingDecision; }
            set { vpRequestingDecision = value; }
        }

        private string positionName;
        public string PositionName
        {
            get { return positionName; }
            set { positionName = value; }
        }

        private int yourComID;
        public int YourComID
        {
            get { return yourComID; }
            set{yourComID = value;}
        }

        public DataTable ViewEmployeeRequest()
        {
            string viewEmployeeRequestQuery = "EXECUTE ViewEmployee'" + PositionName + "','" + Emp_id + "','" + CompanyID + "'";
            DataTable dtViewEmployee = DHELTASSysDataAccess.Select(viewEmployeeRequestQuery);
            return dtViewEmployee;
        }

        public DataTable ViewTransferRequestsReceiving()
        {
            string viewTransferRequestQuery = "EXECUTE ViewTransferRequestsReceiving";
            DataTable dtViewTransferRequest = DHELTASSysDataAccess.Select(viewTransferRequestQuery);
            return dtViewTransferRequest;
        }


        public void ModifyRequests()
        {
            string addRequest = "EXECUTE ModifyRequest '" + CompanyID + "','" + YourComID + "'" ;
            DHELTASSysDataAccess.Modify(addRequest);
        }

        public void DenyRequests()
        {
            string denyAllRequestReceiving = "EXECUTE DenyAllReceivingRequest'" +TransferRequestID+ "'";
            DHELTASSysDataAccess.Modify(denyAllRequestReceiving);
        }

        public DataTable SelectPosition()
        {
            string selectPositionQuery = "SELECT * FROM position";
            DataTable dtSelectPosition = DHELTASSysDataAccess.Select(selectPositionQuery);
            return dtSelectPosition;
        }

        //Inserting Requested Employee to EmpTransfer Table
        public void AddEmpRequest()
        {
            //string addEmpRequestQuery = "EXECUTE AddEmpTransfer '" + Emp_id + "','" + Date_transfer + "','" 
            //    + TransferRequestID + "','" + TransfreReceivingID + "'";
            //DHELTASSysDataAccess.Modify(addEmpRequestQuery);

            //string connectionString = "Server=localhost;Database=dheltassys;UID=dheltassys;PWD=teammegabyte";

            //    SqlConnection con = new SqlConnection(connectionString);
            //    SqlCommand cmd = new SqlCommand("AddAccountSetTempPassword", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = Password;
            //    cmd.Parameters.Add("@last_name", SqlDbType.VarChar).Value = Last_name;
            //    cmd.Parameters.Add("@first_name", SqlDbType.VarChar).Value = First_name;
            //    cmd.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = Middle_name;
            //    cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = Gender;
            //    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
            //    cmd.Parameters.Add("@birthdate", SqlDbType.Date).Value = Birthdate;
            //    cmd.Parameters.Add("@position_name", SqlDbType.VarChar).Value = Position_name;
            //    cmd.Parameters.Add("@company_name", SqlDbType.VarChar).Value = Company_name;
            //    cmd.Parameters.Add("@department_name", SqlDbType.VarChar).Value = Department_name;
            //    cmd.Parameters.Add("@biometrics_image", SqlDbType.VarBinary).Value = Biometric_code;

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //    string cmdTwo = "Execute AddSupervisor";
            //    DHELTASSysDataAccess.Modify(cmdTwo);

            string connectionString = "Server=localhost;Database=dheltassysfinal;UID=dheltassys;PWD=teammegabyte";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("AddEmpTransfer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = Emp_id;
            cmd.Parameters.Add("@date_transfer", SqlDbType.Date).Value = Date_transfer;
            cmd.Parameters.Add("@transfer_requesting_id", SqlDbType.Int).Value = TransferRequestID;
            cmd.Parameters.Add("@transfer_receiving_id", SqlDbType.Int).Value = TransfreReceivingID;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable ViewTransferRequests()
        {
            string ViewRequestEmployees = "EXECUTE ViewEmployeeRequestForm";
            DataTable dtViewEmployeeRequestForm = DHELTASSysDataAccess.Select(ViewRequestEmployees);
            return dtViewEmployeeRequestForm;
        }

        //Update VP Requesting Decision (Agree)
        public void UpdateVPRequestingDecision()
        {
            string updateVPRequestingDecision = "EXECUTE UpdateVPRequestingDecision'"+ TransferRequestID + "'";
            DHELTASSysDataAccess.Modify(updateVPRequestingDecision);
        }

       
        //View of Vice President of the Requesting Company
        public DataTable ViewVPRequestEmployee()
        {
            string viewEmployeeVPRequest = "EXECUTE ViewVPRequestingEmployee'" +CompanyID+"'";
            DataTable dtViewEmployeeVPRequesting = DHELTASSysDataAccess.Select(viewEmployeeVPRequest);
            return dtViewEmployeeVPRequesting;
        }

        //Add Employee Transfer to the the receiving table
        public void AddEmployeeReceive()
        {
            string viewApporove = "EXECUTE AddEmployeeReceiving'" + TransferRequestID + "'";
            DHELTASSysDataAccess.Modify(viewApporove);
        }

        //VP of the requesting company deny the request
        public void DenyEmployeeRequest()
        {
            string denyRequest = "EXECUTE DenyEmployeeTransfer'" + TransferRequestID + "'";
            DHELTASSysDataAccess.Modify(denyRequest);
        }

        public DataTable ViewAllReceivingTransfer()
        {
            string viewAllReceivingtransfer = "EXECUTE ViewAllReceivingTransfer";
            DataTable dtViewAllReceivingTransfer = DHELTASSysDataAccess.Select(viewAllReceivingtransfer);
            return dtViewAllReceivingTransfer;
        }



        //View All Employee Requested
        public DataTable ViewAllReceivingEmployee()
        {
            string ViewAllReceiveEmployee = "EXECUTE ViewAllEmployeeReceiving'" + CompanyID + "'";
            DataTable dt = DHELTASSysDataAccess.Select(ViewAllReceiveEmployee);
            return dt;
        }

        public DataTable ViewVPReceiving()
        {
            string ViewAllReceiveEmployee = "EXECUTE ViewVPReceiving'" + CompanyID + "'";
            DataTable dt = DHELTASSysDataAccess.Select(ViewAllReceiveEmployee);
            return dt;
        }

        //Update the Employee's Company Detail
        public void UpdateEmployeeCompany()
        {
            string updateEmployeeCompany = "EXECUTE UpdateEmployeeCompany'" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(updateEmployeeCompany);
        }

        public void UpdateComanyEmployeeReceiving()
        {
            string updateCompanyEmployee = "EXECUTE UpdateEmployeeReceivingCompany'" + CompanyID + "','" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(updateCompanyEmployee);
        }

        public void AddTransferRecieve()
        {
            string updateEmpTransfer = "EXECUTE UpdateEmpTransferReceiving";
            DHELTASSysDataAccess.Modify(updateEmpTransfer);
        }

        //if HR Approve the Transfer by the Requesting Company
        public void UpdateHRApprove()
        {
            string updateHRDecision = "EXECUTE UpdateApproveHRDecision'" + TransfreReceivingID + "'";
            DHELTASSysDataAccess.Modify(updateHRDecision);
        }

        //HR of the Receiving Company Deny the Request
        public void UpdateHRReceiving()
        {
            string updateHRdecision = "EXECUTE UpdateHRReceiving '" + TransfreReceivingID + "'";
            DHELTASSysDataAccess.Modify(updateHRdecision);
        }

        public void DenyAllRequest()
        {
            string denyRequest = "EXECUTE DenyAllRequest'" + transfreReceivingID + "'";
            DHELTASSysDataAccess.Modify(denyRequest);
        }


        public void UpdateCompany()
        {
            string updateEmployeeCompany = "EXECUTE UpdateEmployeeCompany'" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(updateEmployeeCompany);
        }

        public DataTable ViewAllReceivedRequest()
        {
            string viewAllReceive = "EXECUTE ViewAllReceivingRequest'" + CompanyID + "'";
            DataTable dtView = DHELTASSysDataAccess.Select(viewAllReceive);
            return dtView;
        }

        public DataTable ViewAllApprovedReceived()
        {
            string viewApproved = "EXECUTE VPReceivingDecision";
            DataTable dt = DHELTASSysDataAccess.Select(viewApproved);
            return dt;
        }

        public void VPApprovedReceived()
        {
            string update = "EXECUTE VPReceivingApproved'" + TransfreReceivingID + "'";
            DHELTASSysDataAccess.Modify(update);
        }

        public void VPDeniedReceived()
        {
            string update = "EXECUTE VPReceivingDeny'" + TransfreReceivingID + "'";
            DHELTASSysDataAccess.Modify(update);
        }

        public void UpdateCompanyEmployee()
        {
            string update = "EXECUTE UpdateCompanyEmployee'" + YourComID + "','" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(update);
        }
    }
}