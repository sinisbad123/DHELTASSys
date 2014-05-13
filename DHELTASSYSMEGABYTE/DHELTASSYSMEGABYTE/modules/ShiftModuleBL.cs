using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Imports
using System.Data;
using DHELTASSYS.DataAccess;

namespace DHELTASSys.modules
{
    public class ShiftModuleBL
    {
        #region Getters & Setters
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private int shift_id;
        public int Shift_id
        {
            get { return shift_id; }
            set { shift_id = value; }
        }
       

        private string from_date;
        public string From_date
        {
            get { return from_date; }
            set { from_date = value; }
        }

        private string to_date;
        public string To_date
        {
            get { return to_date; }
            set { to_date = value; }
        }

        #endregion
        
        #region Process

        public DataTable ViewEmployeeShift()
        {
            string viewEmployeeShiftQuery = "EXECUTE ViewEmployeeShift '"+Emp_id+"'";
            return DHELTASSysDataAccess.Select(viewEmployeeShiftQuery);
        }
        public void AssignEmployeeShift()
        {
            string assignEmployeeShift = "EXECUTE AssignEmployeeShift '"+Emp_id+"','"+Shift_id+"','"+From_date+"','"+To_date+"'";
            DHELTASSysDataAccess.Modify(assignEmployeeShift);
        }
        public DataTable selectShift()
        {
            string selectShiftQuery = "EXECUTE SelectShift";
            return DHELTASSysDataAccess.Select(selectShiftQuery);
        }
        #endregion
    }
}

//Default Page MyShift.aspx