using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DHELTASSys.DataHandling;
using DHELTASSYS.DataAccess;

namespace DHELTAFINALPROJECT.DHELTAVP
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        DHELTASSysDataHandling dth = new DHELTASSysDataHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {
                dth.Company_id = int.Parse(Session["CompanyID"].ToString());
                gvEmployees.DataSource = dth.SelectEmployeeCompany();
                gvEmployees.DataBind();
            }
        }
    }
}