using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//imports
using System.Data;
using DHELTASSys.DataAccess;

namespace DHELTASSys
{
    namespace AuditTrail
    {
        class DHELTASSysAuditTrail
        {
            private int emp_id;
            public int Emp_id
            {
                get { return emp_id; }
                set { emp_id = value; }
            }

            public  void AddAuditTrail(string process)
            {
                string cmd = "EXECUTE AddAuditTrail"
                    + "'" + Emp_id + "',"
                    + "'" + process + "'";
                DHELTASSysDataAccess.Modify(cmd);
            }
        }
    }
}
