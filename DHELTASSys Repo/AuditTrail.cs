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

            public static void AddAuditTrail(int emp_id, string process)
            {
                string cmd = "EXECUTE AddAuditTrail"
                    + "'" + emp_id + "',"
                    + "'" + process + "'";
                DHELTASSysDataAccess.Modify(cmd);
            }
        }
    }
}
