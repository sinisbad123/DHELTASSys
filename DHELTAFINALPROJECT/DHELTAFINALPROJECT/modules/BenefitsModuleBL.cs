using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Imports
using System.Data;
using DHELTASSYS.DataAccess;
namespace DHELTASSys.modules
{
    public class BenefitsModuleBL
    {
        #region Getters & Setters
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private string last_name;
        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        private string first_name;
        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }

        private string company_name;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string benefit_type;
        public string Benefit_type
        {
            get { return benefit_type; }
            set { benefit_type = value; }
        }

        private string benefit_info;
        public string Benefit_info
        {
            get { return benefit_info; }
            set { benefit_info = value; }
        }

        private int benefit_id;
        public int Benefit_id
        {
            get { return benefit_id; }
            set { benefit_id = value; }
        }

        private int emp_benefit_id;
        public int Emp_benefit_id
        {
            get { return emp_benefit_id; }
            set { emp_benefit_id = value; }
        }

        private int position_id;
        public int Position_id
        {
            get { return position_id; }
            set { position_id = value; }
        }

        private string position_name;
        public string Position_name
        {
            get { return position_name; }
            set { position_name = value; }
        }

        private string dependent_name;
        public string Dependent_name
        {
            get { return dependent_name; }
            set { dependent_name = value; }
        }

        private string relation;
        public string Relation
        {
            get { return relation; }
            set { relation = value; }
        }

        private string contact_number;
        public string Contact_number
        {
            get { return contact_number; }
            set { contact_number = value; }
        }


        #endregion

        #region Functions

        #region Employee Benefits
        public void AddEmployeeBenefits()
        {
            string manageEmployeeBenefitsQuery = "EXECUTE AddEmployeeBenefits '" + Emp_id + "','" + Benefit_id + "'";
            DHELTASSysDataAccess.Modify(manageEmployeeBenefitsQuery);
        }

        public void RemoveEmployeeBenefits()
        {
            string manageEmployeeBenefitsQuery = "EXECUTE RemoveEmployeeBenefits '" + Emp_id + "','" + Emp_benefit_id + "'";
            DHELTASSysDataAccess.Modify(manageEmployeeBenefitsQuery);
        }

        public DataTable ViewEmployeeBenefits()
        {
            string viewBenefitsQuery = "EXECUTE ViewEmployeeBenefits '" + Emp_id + "'";
            DataTable dtEmployeeBenefits = DHELTASSysDataAccess.Select(viewBenefitsQuery);
            return dtEmployeeBenefits;
        }
        #endregion

        #region Benefits
        public DataTable ViewBenefits()
        {
            string viewBenefitsQuery = "EXECUTE ViewBenefits '" + Emp_id + "'";
            DataTable dtBenefits = DHELTASSysDataAccess.Select(viewBenefitsQuery);
            return dtBenefits;
        }

        public DataTable ViewBenefitsBenefitID()
        {
            string viewBenefitsBenefitIDQuery = "EXECUTE ViewEmployeeBenefitsBenefitID '" + Emp_id + "','" + Benefit_id + "'";
            return DHELTASSysDataAccess.Select(viewBenefitsBenefitIDQuery);
        }

        public DataTable ViewPositionBenefits()
        {
            string viewPositionBenefitsQuery = "EXECUTE ViewPositionBenefits '" + Emp_id + "', '" + Position_name + "'";
            return DHELTASSysDataAccess.Select(viewPositionBenefitsQuery);
        }

        public void AddBenefits()
        {
            string addBenefitsQuery = "EXECUTE AddBenefits '" + Benefit_type + "','" + Benefit_info + "','" + Emp_id + "','" + Position_name + "'";
            DHELTASSysDataAccess.Modify(addBenefitsQuery);
        }
        #endregion

        #region Dependents
        public void AddDependents()
        {
            string addDepenedentsQuery = "EXECUTE AddDependents '" + Dependent_name + "','" + Contact_number + "','" + Relation + "','" + Emp_id + "'";
            DHELTASSysDataAccess.Modify(addDepenedentsQuery);
        }

        public DataTable ViewDependents()
        {
            string viewDepenedentsQuery = "EXECUTE ViewDependents '" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(viewDepenedentsQuery);
        }
        #endregion

        #endregion
    }
}