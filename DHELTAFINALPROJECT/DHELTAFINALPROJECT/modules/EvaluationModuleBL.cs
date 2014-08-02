using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Imports
using System.Data;
using DHELTASSYS.DataAccess;
using DHELTASSys.AuditTrail;
using System.Data.SqlClient;

namespace DHELTASSys.modules
{
    public class EvaluationModuleBL
    {
        #region Getters and Setters
        
        private int emp_id;
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        private int eval_supervisor_group_status_id;
        public int Eval_supervisor_group_status_id
        {
            get { return eval_supervisor_group_status_id; }
            set { eval_supervisor_group_status_id = value; }
        }

        private int emp_search_id;
        public int Emp_search_id
        {
            get { return emp_search_id; }
            set { emp_search_id = value; }
        }

        private int emp_selected_id;
        public int Emp_selected_id
        {
            get { return emp_selected_id; }
            set { emp_selected_id = value; }
        }

        private int company_id;
        public int Company_id
        {
            get { return company_id; }
            set { company_id = value; }
        }

        private string company_name;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string department_name;
        public string Department_name
        {
            get { return department_name; }
            set { department_name = value; }
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

        private string question_position;
        public string Question_position
        {
            get { return question_position; }
            set { question_position = value; }
        }

        private string question_status;
        public string Question_status
        {
            get { return question_status; }
            set { question_status = value; }
        }

        private string eval_question;
        public string Eval_question
        {
            get { return eval_question; }
            set { eval_question = value; }
        }

        private int eval_question_id;
        public int Eval_question_id
        {
            get { return eval_question_id; }
            set { eval_question_id = value; }
        }

        private int emp_evaluating_id;
        public int Emp_evaluating_id
        {
            get { return emp_evaluating_id; }
            set { emp_evaluating_id = value; }
        }

        private int emp_evaluated_id;
        public int Emp_evaluated_id
        {
            get { return emp_evaluated_id; }
            set { emp_evaluated_id = value; }
        }

        private string emp_evaluated_lastName;
        public string Emp_evaluated_lastName
        {
            get { return emp_evaluated_lastName; }
            set { emp_evaluated_lastName = value; }
        }

        private string emp_evaluated_firstName;
        public string Emp_evaluated_firstName
        {
            get { return emp_evaluated_firstName; }
            set { emp_evaluated_firstName = value; }
        }

        private string eval_answer;
        public string Eval_answer
        {
            get { return eval_answer; }
            set { eval_answer = value; }
        }

        private string eval_quarter;
        public string Eval_quarter
        {
            get { return eval_quarter; }
            set { eval_quarter = value; }
        }

        private DateTime eval_date;
        public DateTime Eval_date 
        {
            get { return eval_date; }
            set { eval_date = value; }
        }

        private string eval_question_status;
        public string Eval_question_Status
        {
            get { return eval_question_status; }
            set { eval_question_status = value; }
        }

        private bool eval_status;
        public bool Eval_status
        {
            get { return eval_status; }
            set { eval_status = value; }
        }

        private bool assess_status;
        public bool Assess_status
        {
            get { return assess_status; }
            set { assess_status = value; }
        }

        private int eval_year;
        public int Eval_year
        {
            get { return eval_year; }
            set { eval_year = value; }
        }

        private int eval_status_id;
        public int Eval_status_id
        {
            get { return eval_status_id; }
            set { eval_status_id = value; }
        }

        private int assess_status_id;
        public int Assess_status_id
        {
            get { return assess_status_id; }
            set { assess_status_id = value; }
        }

        private float eval_score;
        public float Eval_score
        {
            get { return eval_score; }
            set { eval_score = value; }
        }

        #endregion

        public void AddEvaluationQuestions() // [HR MANAGER] Add new question according to position
        {
            string AddEvaluationQuestionQuery = "EXECUTE AddEvaluationQuestions '" +
                Emp_id + "','" +
                Eval_question + "','" +
                Position_name + "','" +
                Eval_question_Status + "'";
            DHELTASSysDataAccess.Modify(AddEvaluationQuestionQuery);
        }

        public void AddEvaluationAnswers() // [EMPLOYEE/SUPERVISOR] Add a new answer to the evaluation according to position
        {
            string AddEvaluationAnswerQuery = "EXECUTE AddEvaluationAnswers '" +
                Emp_evaluating_id + "','" +
                Emp_evaluated_id + "','" +
                Eval_quarter + "','" +
                Eval_question + "','" +
                Eval_answer + "'";
            ;
            DHELTASSysDataAccess.Modify(AddEvaluationAnswerQuery);
        }

        public void UpdateEvaluationQuestion() // [HR MANAGER] edit evaluation question
        {
            string UpdateEvaluationQuestionQuery = "EXECUTE UpdateEvaluationQuestion '" +
                Eval_question_id + "','" +
                Eval_question_Status + "'";
            DHELTASSysDataAccess.Modify(UpdateEvaluationQuestionQuery);
        }

        public void AddEvaluationStatusEmployee()
        {
            string AddEvaluationStatusEmployeeQuery = "EXECUTE AddEvaluationStatusEmployee '" +            	               
                Eval_quarter + "','" +
                Emp_evaluating_id + "','" +
                Emp_evaluated_id + "'";
            DHELTASSysDataAccess.Modify(AddEvaluationStatusEmployeeQuery);
        }

        public void AddEvaluationStatusSupervisor()
        {
            string AddEvaluationStatusEmployeeQuery = "EXECUTE AddEvaluationStatusSupervisor '" +
                    Eval_quarter + "','" +
                    Emp_evaluated_id + "','" +
                    Emp_evaluating_id + "'";
            DHELTASSysDataAccess.Modify(AddEvaluationStatusEmployeeQuery);
        }

        public void AddEvaluationStatusSupervisor_Group()
        {
            string AddEvaluationStatusEmployeeQuery = "EXECUTE AddEvaluationStatusSupervisor_Group '" + 
                    Eval_quarter + "','" +
                    Emp_evaluated_id + "'";
            DHELTASSysDataAccess.Modify(AddEvaluationStatusEmployeeQuery);
        }

        public void AddAssessmentStatusEmployee()
        {
            string connectionString = "Server=localhost;Database=dheltassysfinal;UID=dheltassys;PWD=teammegabyte";

            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand("AddAccountSetTempPassword", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = Password;
            //cmd.Parameters.Add("@last_name", SqlDbType.VarChar).Value = Last_name;
            //cmd.Parameters.Add("@first_name", SqlDbType.VarChar).Value = First_name;
            //cmd.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = Middle_name;
            //cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = Gender;
            //cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
            //cmd.Parameters.Add("@birthdate", SqlDbType.Date).Value = Birthdate;
            //cmd.Parameters.Add("@position_name", SqlDbType.VarChar).Value = Position_name;
            //cmd.Parameters.Add("@company_name", SqlDbType.VarChar).Value = Company_name;
            //cmd.Parameters.Add("@department_name", SqlDbType.VarChar).Value = Department_name;
            //cmd.Parameters.Add("@biometrics_image", SqlDbType.VarBinary).Value = Biometric_code;

            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("AddAssessmentStatusEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@eval_status_id", SqlDbType.Int).Value = Eval_status_id;
            cmd.Parameters.Add("@eval_score", SqlDbType.Float).Value = Eval_score;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //string AddAssessmentStatusEmployeeQuery = "EXECUTE AddAssessmentStatusEmployee '" +
            //    Eval_status_id + "','" +
            //    Eval_score + "'";
            //DHELTASSysDataAccess.Modify(AddAssessmentStatusEmployeeQuery);
        }

        public void AddAssessmentStatusSupervisor_Group()
        {
            string AddAssessmentStatusSupervisor_GroupQuery = "EXECUTE AddAssessmentStatusSupervisor_Group '" +
                Eval_status_id + "','" +
                Eval_score + "'";
            DHELTASSysDataAccess.Modify(AddAssessmentStatusSupervisor_GroupQuery);
        }

        public DataTable SelectEmployeeID_Supervisor()
        {
            string SelectEmployeeID_SupervisorQuery = "EXECUTE SelectEmployeeID_Supervisor'" +
                Emp_evaluated_id + "'";
            return DHELTASSysDataAccess.Select(SelectEmployeeID_SupervisorQuery);
        }

        public DataTable SelectCompanyDepartment()
        {
            string SelectCompanyDepartmentQuery = "EXECUTE SelectCompanyDepartment '" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(SelectCompanyDepartmentQuery);
        }

        public DataTable SelectEmployee_Position()
        {
            string SelectEmployee_PositionQuery = "EXECUTE SelectEmployee_Position '" + Emp_evaluated_id + "'";
            return DHELTASSysDataAccess.Select(SelectEmployee_PositionQuery);
        }

        public DataTable SelectSupervisor_Position()
        {
            string SelectSupervisor_PositionQuery = "EXECUTE SelectSupervisor_Position '" + Emp_evaluated_id + "'";
            return DHELTASSysDataAccess.Select(SelectSupervisor_PositionQuery);
        }

        public DataTable ViewEvaluationAnswersEmployee()
        {
            string ViewEvaluationAnswersEmployeeQuery = "EXECUTE ViewEvaluationAnswersEmployee '" + Emp_evaluated_id + "','" + Emp_evaluating_id + "','" + Eval_date + "'";
            return DHELTASSysDataAccess.Select(ViewEvaluationAnswersEmployeeQuery);
        }

        public DataTable ViewEvaluationAnswersSupervisor()
        {
            string ViewEvaluationAnswersSupervisorQuery = "EXECUTE ViewEvaluationAnswersSupervisor '" + Emp_evaluated_id + "','" + Eval_quarter + "','" + Eval_year + "'";
            return DHELTASSysDataAccess.Select(ViewEvaluationAnswersSupervisorQuery);
        }

        public DataTable SelectCompanyPosition()
        {
            string SelectCompanyPositionQuery = "EXECUTE SelectCompanyPosition '" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(SelectCompanyPositionQuery);
        }

        public DataTable SelectAllCompany() // [HR MANAGER] View ALL company
        {
            string SelectAllCompanyQuery = "EXECUTE SelectAllCompany";
            return DHELTASSysDataAccess.Select(SelectAllCompanyQuery);
        }

        public DataTable SelectAllPosition() // [HR MANAGER] View ALL position
        {
            string SelectAllPositionQuery = "EXECUTE SelectAllPosition";
            return DHELTASSysDataAccess.Select(SelectAllPositionQuery);
        }

        public DataTable SelectCompanyEmployeesEmployeeID() // [HR MANAGER] View ALL supervisors and employee of the company
        {
            string SelectAllCompanyEmployeesEmployeeIDQuery = "EXECUTE SelectAllCompanyPersonnel '" + Emp_id + "','" + Emp_search_id + "'";
            return DHELTASSysDataAccess.Select(SelectAllCompanyEmployeesEmployeeIDQuery);
        }

        public DataTable SelectCompanyEmployeesDepartment()
        {
            string selectCompanyEmployeesDepartmentQuery = "EXECUTE SelectCompanyEmployeesDepartment '" + Emp_id + "','" + Department_name + "'";
            return DHELTASSysDataAccess.Select(selectCompanyEmployeesDepartmentQuery);
        }

        public DataTable SelectEvaluationQuestionID()
        {
            string SelectEvaluationQuestionIDQuery = "EXECUTE SelectEvaluationQuestionID '" + 
                Emp_id + "','" +
                Eval_question + "','" +
                Position_name + "'";
            return DHELTASSysDataAccess.Select(SelectEvaluationQuestionIDQuery);
        }

        public DataTable SelectCompanyEmployeesPosition()
        {
            string selectCompanyEmployeesPositionQuery = "EXECUTE SelectCompanyEmployeesPosition '" + Emp_id + "','" + Position_name + "'";
            return DHELTASSysDataAccess.Select(selectCompanyEmployeesPositionQuery);
        }

        public DataTable SelectAllCompanyPersonnel() // [HR MANAGER] View ALL supervisors and employee of the company
        {
            string SelectAllCompanyPersonnelQuery = "EXECUTE SelectAllCompanyPersonnel '" + Emp_id + "'";
            return DHELTASSysDataAccess.Select(SelectAllCompanyPersonnelQuery);
        }

        public DataTable SelectCompanyEmployeeForEvaluation() // [HR MANAGER] View ALL supervisors and employee of the company
        {
            string selectCompanyEmployeeForEvaluationQuery = "EXECUTE selectCompanyEmployeeForEvaluation '" + Emp_evaluated_id + "'";
            return DHELTASSysDataAccess.Select(selectCompanyEmployeeForEvaluationQuery);
        }

        public DataTable SearchCompanyPersonnel() // [HR MANAGER] View searched employee of the company
        {
            string SearchCompanyPersonnelQuery = "EXECUTE SearchCompanyPersonnel '" + Emp_id + "','" + Emp_search_id + "'";
            return DHELTASSysDataAccess.Select(SearchCompanyPersonnelQuery);
        }

        public DataTable ViewEvalStatSV_Group_QuarterYear() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvalStatSV_Group_QuarterYEarQuery = "EXECUTE ViewEvalStatSV_Group_QuarterYear '" + 
                Eval_quarter + "','" +
                Eval_year + "','" +
                Emp_evaluated_id + "'";
            DataTable dtStatSV_Group_QuarterYEar = DHELTASSysDataAccess.Select(ViewEvalStatSV_Group_QuarterYEarQuery);
            return dtStatSV_Group_QuarterYEar;
        }

        public DataTable ViewEvalStatAnswers() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvalStatAnswersQuery = "EXECUTE ViewEvalStatAnswers '" +
                Emp_evaluating_id + "','" +
                Emp_evaluated_id + "','" +
                Eval_quarter + "','" + 
                Eval_year + "'";
            DataTable dtViewEvalStatAnswers = DHELTASSysDataAccess.Select(ViewEvalStatAnswersQuery);
            return dtViewEvalStatAnswers;
        }

        public DataTable ViewEvaluationStatusEmployee() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusEmployeeQuery = "EXECUTE ViewEvaluationStatusEmployee '" + Emp_evaluated_id + "'";
            DataTable dtEmployeeEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusEmployeeQuery);
            return dtEmployeeEvaluationStatus;
        }

        public DataTable ViewEvaluationStatusEmployee_Assess() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusEmployee_AssessQuery = "EXECUTE ViewEvaluationStatusEmployee_Assess '" +
                Eval_quarter + "','" +
                Eval_year + "','" +
                Emp_id + "'";
            DataTable dtEmployeeEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusEmployee_AssessQuery);
            return dtEmployeeEvaluationStatus;
        }

        public DataTable ViewEvaluationStatusEmployeeID() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusEmployeeIDQuery = "EXECUTE ViewEvaluationStatusEmployeeID '" + Emp_evaluated_id + "'";
            DataTable dtEmployeeEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusEmployeeIDQuery);
            return dtEmployeeEvaluationStatus;
        }


        public DataTable ViewEvaluationStatusEmployeeAnnual() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusEmployeeAnnualQuery = "EXECUTE ViewEvaluationStatusEmployeeAnnual '" + Emp_evaluated_id + "'";
            DataTable dtEmployeeEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusEmployeeAnnualQuery);
            return dtEmployeeEvaluationStatus;
        }

        public DataTable ViewEvaluationStatusSupervisor() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusSupervisorQuery = "EXECUTE ViewEvaluationStatusSupervisor '" + 
                Eval_quarter + "','" +
                Eval_year + "','" + 
                Emp_evaluated_id + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusSupervisorQuery);
            return dtSupervisorEvaluationStatus;
        }

        public DataTable ViewEvaluationStatusSupervisor_PerEmployee() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusSupervisor_PerEmployeeQuery = "EXECUTE ViewEvaluationStatusSupervisor_PerEmployee '" + Emp_evaluating_id + "','" + Eval_quarter + "','" + Eval_year + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusSupervisor_PerEmployeeQuery);
            return dtSupervisorEvaluationStatus;
        }

        public DataTable ViewEvaluationStatusSupervisor_Group() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusSupervisor_GroupQuery = "EXECUTE ViewEvaluationStatusSupervisor_Group '" + Emp_evaluated_id + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusSupervisor_GroupQuery);
            return dtSupervisorEvaluationStatus;
        }

        public DataTable ViewEvaluationStatusSupervisor_Group_Assess() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusSupervisor_Group_AssessQuery = "EXECUTE ViewEvaluationStatusSupervisor_Group_Assess '" +
                Eval_quarter + "','" +
                Eval_year + "','" +
                Emp_id + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusSupervisor_Group_AssessQuery);
            return dtSupervisorEvaluationStatus;
        }

        public DataTable ViewEvaluationStatusSupervisor_GroupAnnual() // [HR MANAGER] View ALL employees of the company
        {
            string ViewEvaluationStatusSupervisor_GroupAnnualQuery = "EXECUTE ViewEvaluationStatusSupervisor_GroupAnnual '" + Emp_evaluated_id + "'";
            DataTable dtSupervisorEvaluationStatus = DHELTASSysDataAccess.Select(ViewEvaluationStatusSupervisor_GroupAnnualQuery);
            return dtSupervisorEvaluationStatus;
        }

        public DataTable ViewCompanyEmployees() // [HR MANAGER] View ALL employees of the company
        {
            string viewCompanyEmployeesQuery = "EXECUTE ViewCompanyEmployees '" + Emp_id + "'";
            DataTable dtCompanyEmployees = DHELTASSysDataAccess.Select(viewCompanyEmployeesQuery);
            return dtCompanyEmployees;
        }

        public DataTable ViewCompanySupervisors() // [HR MANAGER] View ALL supervisors of the company
        {
            string viewCompanySupervisorsQuery = "EXECUTE ViewCompanySupervisors '" + Emp_id + "'";
            DataTable dtCompanySupervisors = DHELTASSysDataAccess.Select(viewCompanySupervisorsQuery);
            return dtCompanySupervisors;
        }

        public DataTable ViewEvaluateEmployees() // [SUPERVISOR] View ALL employees handled by the supervisor
        {
            string viewEmployeesToEvaluateQuery = "EXECUTE ViewEvaluateEmployees '" + Emp_evaluating_id + "'";
            DataTable dtEvaluateEmployees = DHELTASSysDataAccess.Select(viewEmployeesToEvaluateQuery);
            return dtEvaluateEmployees;
        }

        public DataTable ViewEvaluateSupervisors() // [EMPLOYEE] View supervisor of the employees
        {
            string viewSupervisorsToEvaluateQuery = "EXECUTE ViewEvaluateSupervisors '" + Emp_evaluating_id + "'";
            DataTable dtViewEvaluationFormEmployee = DHELTASSysDataAccess.Select(viewSupervisorsToEvaluateQuery);
            return dtViewEvaluationFormEmployee;
        }

        public DataTable ViewEvaluationFormSupervisor() // [HR MANAGER] View ALL the questions for supervisors
        {
            string viewEvaluationFormSupervisorQuery = "EXECUTE ViewEvaluationFormSupervisor '" + Emp_evaluating_id + "'";
            DataTable dtViewEvaluationFormSupervisor = DHELTASSysDataAccess.Select(viewEvaluationFormSupervisorQuery);
            return dtViewEvaluationFormSupervisor;
        }

        public DataTable ViewEvaluationFormEmployee() // [HR MANAGER] View ALL the questions for employees
        {
            string viewEvaluationFormEmployeeQuery = "EXECUTE ViewEvaluationFormEmployee '" + Emp_evaluating_id + "'";
            DataTable dtEvaluationFormEmployee = DHELTASSysDataAccess.Select(viewEvaluationFormEmployeeQuery);
            return dtEvaluationFormEmployee;
        }

        public DataTable ViewEvaluationQuestion() // [HR MANAGER] View ALL the questions per position
        {
            string viewEvaluationQuestionQuery = "EXECUTE ViewEvaluationQuestion '" + Emp_id + "'";
            DataTable dtEvaluationQuestion = DHELTASSysDataAccess.Select(viewEvaluationQuestionQuery);
            return dtEvaluationQuestion;
        }

        public DataTable ViewEvaluationQuestionSort() //
        {
            string ViewEvaluationQuestionSortQuery = "EXECUTE ViewEvaluationQuestionSort '" +
                Emp_id + "','" + 
                Question_position + "','" + 
                Question_status + "'";
            return DHELTASSysDataAccess.Select(ViewEvaluationQuestionSortQuery);
        }

        public DataTable ViewEvaluationQuestionPosition() //
        {
            string ViewEvaluationQuestionPositionQuery = "EXECUTE ViewEvaluationQuestionPosition '" +
                Emp_id + "','" +
                Question_position + "'";
            return DHELTASSysDataAccess.Select(ViewEvaluationQuestionPositionQuery);
        }

        public DataTable ViewEvaluationQuestionStatus() //
        {
            string ViewEvaluationQuestionStatusQuery = "EXECUTE ViewEvaluationQuestionStatus '" +
                Emp_id + "','" +
                Question_status + "'";
            return DHELTASSysDataAccess.Select(ViewEvaluationQuestionStatusQuery);
        }
    }
}