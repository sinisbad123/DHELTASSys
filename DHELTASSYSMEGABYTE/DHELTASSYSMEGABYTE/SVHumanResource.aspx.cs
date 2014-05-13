using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHELTASSYSMEGABYTE
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEvaluate_Click(object sender, EventArgs e)
        {
            Response.Redirect("SVEvaluateEmployee.aspx");
        }
    }
}