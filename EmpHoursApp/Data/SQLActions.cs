using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Data;
using System.Data.SqlClient;

using EmpHoursApp.ViewModel;




namespace EmpHoursApp.Data
{
    public class SQLActions
    {
        private SqlConnection _conn;
        private SqlCommand _com;
        private SqlConnectionStringBuilder _conBuilder;

        public SQLActions()
        {
            try
            {
                _conn = new SqlConnection();
                _conBuilder = new SqlConnectionStringBuilder();
                _conBuilder.InitialCatalog = "EmpHoursEmployeesDb";
                _conBuilder.DataSource = @"(localdb)\mssqllocaldb";
                _conBuilder.IntegratedSecurity = true;
                _conn.ConnectionString = _conBuilder.ConnectionString;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public List<EmployeeViewModel> GetAllEmployee()
        {   

            List<EmployeeViewModel> employeeViewList = new List<EmployeeViewModel>();
            string storedProcedure = "sp_EmpHourEmployee_ListOfEmployees";
            _com = new SqlCommand(storedProcedure, _conn);
            _com.CommandType = CommandType.StoredProcedure;
            _conn.Open();
            SqlDataReader reader = _com.ExecuteReader();
            
            while (reader.Read())
            {                
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    EmpId = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Dob = reader.GetDateTime(4),
                    Phone = reader.GetString(5),
                    TotalHours = (double) reader.SafeGetDouble(6)
                    
                };
                employeeViewList.Add(employeeViewModel);
            }
            _conn.Close();
            return employeeViewList;                     
        }

        public List<EmployeeViewModel> ListAllEmployeeTotalHoursForThePeriod(DateTime beginDate, DateTime endDate)
        {

            List<EmployeeViewModel> employeeViewList = new List<EmployeeViewModel>();
            string storedProcedure = "sp_EmpHourEmployee_ListOfEmployeeTotalHoursForSelectedDates";
            _com = new SqlCommand(storedProcedure, _conn);
            _com.CommandType = CommandType.StoredProcedure;

            SqlParameter param = _com.Parameters.AddWithValue("@beginDate", beginDate);
            param.Direction = ParameterDirection.Input;
            param = _com.Parameters.AddWithValue("@endDate", endDate);
            param.Direction = ParameterDirection.Input;

            _conn.Open();
            SqlDataReader reader = _com.ExecuteReader();

            while (reader.Read())
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    EmpId = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Dob = reader.GetDateTime(4),
                    Phone = reader.GetString(5),
                    TotalHours = (double)reader.SafeGetDouble(6)
                };
                employeeViewList.Add(employeeViewModel);
            }
            _conn.Close();
            return employeeViewList;
        }

        public bool UpdateEmployee(int empId, string firstName, string lastName, string email, DateTime dob, string phone)
        {
            try
            {
                string storedProcedure = "sp_Employees_updateEmployee";
                _com = new SqlCommand(storedProcedure, _conn);
                _com.CommandType = CommandType.StoredProcedure;

                SqlParameter param = _com.Parameters.AddWithValue("@empId", empId);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@firstName", firstName);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@lastName", lastName);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@email", email);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@dob", dob);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@phone", phone);
                param.Direction = ParameterDirection.Input;

                _conn.Open();
                if (_com.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("No connection to the database, the changes have not been saved!!");
                    return false;
                }
                else { MessageBox.Show("Changes Saved Successfully!!"); return true; }
            }

            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally 
            { 
                _com.Dispose(); 
                _conn.Close(); 
            }
        }

        public bool InsertEmpHours(int empId, DateTime workDate, double hours)
        {
            try
            {
                string storedProcedure = "sp_EmpHours_insertEmpHours";
                _com = new SqlCommand(storedProcedure, _conn);
                _com.CommandType = CommandType.StoredProcedure;

                SqlParameter param = _com.Parameters.AddWithValue("@empId", empId);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@workDate", workDate);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@hours", hours);
                param.Direction = ParameterDirection.Input;

                _conn.Open();
                if (_com.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("No connection to the database, the repair was not changed!!");
                    return false;
                }
                else { MessageBox.Show("WorkingHours Added Successfully!!"); return true; }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                _com.Dispose();
                _conn.Close();
            }
        }

        public bool InsertNewEmployee(string firstName, string lastName, string email, DateTime dob, string phone)
        {
            try
            {
                string storedProcedure = "sp_Employees_insertNewEmployee";
                _com = new SqlCommand(storedProcedure, _conn);
                _com.CommandType = CommandType.StoredProcedure;

                SqlParameter param = _com.Parameters.AddWithValue("@firstName", firstName);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@lastName", lastName);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@email", email);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@dob", dob);
                param.Direction = ParameterDirection.Input;

                param = _com.Parameters.AddWithValue("@phone", phone);
                param.Direction = ParameterDirection.Input;

                _conn.Open();
                if (_com.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("No connection to the database, No Employee Added!!");
                    return false;
                }
                else { MessageBox.Show("Employee Added Successfully!!"); return true; }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally 
            { 
                _com.Dispose(); 
                _conn.Close(); 
            }
        }
    }
}
