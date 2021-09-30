using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace myExamination.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        //To View all employees details      
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.ID = Convert.ToInt32(rdr["EmployeeNo"]);
                    employee.LastName = rdr["LastName"].ToString();
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.MiddleName = rdr["MiddleName"].ToString();
                    employee.Birthdate = rdr["Birthdate"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Address = rdr["Address"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        //To Add new employee record      
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string test = employee.MiddleName;

                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName == null ? (object)DBNull.Value : employee.MiddleName);
                cmd.Parameters.AddWithValue("@Birthdate", employee.Birthdate == null ? (object)DBNull.Value : employee.Birthdate);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Address", employee.Address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee    
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.ID);

                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName == null ? (object)DBNull.Value : employee.MiddleName);
                cmd.Parameters.AddWithValue("@Birthdate", employee.Birthdate == null ? (object)DBNull.Value : employee.Birthdate);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular employee    
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeNo= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.ID = Convert.ToInt32(rdr["EmployeeNo"]);
                    employee.LastName = rdr["LastName"].ToString();
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.MiddleName = rdr["MiddleName"].ToString();
                    employee.Birthdate = rdr["Birthdate"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Address = rdr["Address"].ToString();
                }
            }
            return employee;
        }

        //To Delete the record on a particular employee    
        public void DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get Report
        public IEnumerable<Employee> GetReport()
        {
            List<Employee> reportList = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spReportList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.ID = Convert.ToInt32(rdr["Employee"]);
                    employee.Department = rdr["Department"].ToString();

                    reportList.Add(employee);
                }
                con.Close();
            }
            return reportList;
        }
    }
}