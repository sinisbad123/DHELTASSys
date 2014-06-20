using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//imports
using System.Data;
using DHELTASSys.Modules;
using DHELTASSys.AuditTrail;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DHELTASSys
{
    public partial class OffenseFiling : System.Web.UI.Page
    {
        DisciplineModuleBL discipline = new DisciplineModuleBL();
        DHELTASSysAuditTrail audit = new DHELTASSysAuditTrail();


        protected void Page_Load(object sender, EventArgs e)
        {
            string position = Session["Position"].ToString();
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else if (position != "Supervisor" || Session["SelectedEmployee"] == null)
            {
                Response.Redirect(@"~/AccessDenied.aspx");
            }

            string employeeFirstName = Session["SelectedEmpFirstName"].ToString();
            string employeeLastName = Session["SelectedEmpLastName"].ToString();

            lblEmployeeFiled.Text = employeeLastName + ", " + employeeFirstName;

            drpOffenseTypeforFiling.DataSource = discipline.DisplayOffenseTypeForFiling();
            drpOffenseTypeforFiling.DataTextField = "offense_info";
            drpOffenseTypeforFiling.DataValueField = "offense_info";
            drpOffenseTypeforFiling.DataBind();
        }

        public  Boolean IsImage()
        {
            string filePath = fileUploadProof.PostedFile.FileName;
            string fileName = Path.GetFileName(filePath);
            string ext = Path.GetExtension(fileName);
            string contentType = String.Empty;

            switch (ext)
            {
                case ".png":
                    contentType = "image/png";
                    break;
                case ".jpg":
                    contentType = "image/jpg";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".bmp":
                    contentType = "image/bmp";
                    break;
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".tif":
                    contentType = "image/tif";
                    break;
            }

            if (contentType != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void AttachProof()
        {

            //check if FileUpload has a file uploaded into
            
                string filePath = fileUploadProof.PostedFile.FileName;
                string fileName = Path.GetFileName(filePath);
               
                if (IsImage() == true)
                {
                    //Check if directory exists
                    if (!Directory.Exists(MapPath(@"~/Uploads_Proofs/")))
                    {
                        Directory.CreateDirectory(MapPath(@"~/Uploads_Proofs/"));
                    }

                    //specify directory to save the image into
                    string directory = Server.MapPath(@"~/Uploads_Proofs/");

                    //create a bitmap object of the file uploaded
                    Bitmap originalBMP = new Bitmap(fileUploadProof.FileContent);

                    //calculate the image dimensions
                    decimal origWidth = originalBMP.Width;

                    decimal origHeight = originalBMP.Height;

                    decimal sngRatio = origHeight / origWidth;

                    int newHeight = 300;  //hight in pixels

                    decimal newWidth_temp = newHeight / sngRatio;

                    int newWidth = Convert.ToInt16(newWidth_temp);  

                    //create a new bitmap with the new set width and height
                    Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

                    //create graphics from the bitmap
                    Graphics graphics = Graphics.FromImage(newBMP);

                    //set the graphic's properties
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    //draw the image
                    graphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

                    //get name of the employee to be file to be used as naming convention for the saved image.
                    string employeeFirstName = Session["SelectedEmpFirstName"].ToString();
                    string employeeLastName = Session["SelectedEmpLastName"].ToString();

                    //also the current datetime
                    string datetime = DateTime.Now.ToString("MM-dd-yyyy");

                    //file name of the image to be saved
                    string ImageSaveName = employeeLastName + "_" + employeeFirstName + "_" + datetime + ".jpg";
                    
                    directory += ImageSaveName;
                    //save the graphic in the directory
                    newBMP.Save(directory, ImageFormat.Jpeg);

                    originalBMP.Dispose();
                    newBMP.Dispose();
                    graphics.Dispose();

                    discipline.ProofFileName = ImageSaveName;

                    discipline.AddProof();
                }
                else
                {
                    return;
                }

        }



        protected void btnFileOffense_Click(object sender, EventArgs e)
        {

            if (txtStatement.Text == "")
            {
                Response.Write("<script>alert('Please enter Offense Statement')</script>");
            }
            else
            {
                audit.Emp_id = int.Parse(Session["EmployeeID"].ToString());

                discipline.Filing_emp = int.Parse(Session["EmployeeID"].ToString());
                discipline.Filed_emp = int.Parse(Session["SelectedEmployee"].ToString());
                discipline.Offense_info = drpOffenseTypeforFiling.Text;
                discipline.Statement = txtStatement.Text;

                if (fileUploadProof.HasFile)
                {

                    if (IsImage() == true)
                    {
                        discipline.AddOffense();
                        AttachProof();
                        audit.AddAuditTrail("Offense and Proof Added for " + Session["SelectedEmpLastName"].ToString() + ", " + Session["SelectedEmpFirstName"].ToString());
                        Response.Redirect("OffenseFilingSuccess.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Please upload image files in .jpg, .jpeg, .png, .bmp, .tif, .gif')</script>");
                    }

                }
                else
                {
                    discipline.AddOffense();
                    audit.AddAuditTrail("Offense Added for " + Session["SelectedEmpLastName"].ToString() + ", " + Session["SelectedEmpFirstName"].ToString());
                    Response.Redirect("OffenseFilingSuccess.aspx");
                }
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Remove("SelectedEmpLastName");
            Session.Remove("SelectedEmpFirstName");
            Session.Remove("SelectedEmployee");
            Response.Redirect(@"~/discipline/FileOffense.aspx");
        }
    }
}

//Now check other functions