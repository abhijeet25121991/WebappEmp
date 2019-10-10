using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.EmpRepository
{
    public class EmpDataRepository
    {


        private SqlConnection sqlCon = null;
        private void CreateConnection()
        {
            try
            {
                // string dbConnection = @"Data Source=.\sqlexpress;Initial Catalog=EmpolyeeMangmentSystem;Integrated Security=True";
                string dbConnection = System.Configuration.ConfigurationManager.ConnectionStrings["dbEmp"].ToString();
                sqlCon = new SqlConnection(dbConnection);
            }

            catch (Exception ex)
            {
            }


        }
        private void OpenConection()
        {

            sqlCon.Open();

        }



        private void CloseConnection()
        {

            sqlCon.Close();

        }



        public bool AddEmpoyee(Employees empObj)

        {
            int i = 0;

            try
            {
                CreateConnection();
                OpenConection();
                SqlCommand sqlComObj = new SqlCommand("usp_AddEmployee", sqlCon);
                sqlComObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlComObj.Parameters.AddWithValue("@intOpMode", 1);
                sqlComObj.Parameters.AddWithValue("@Name", empObj.Name);
                sqlComObj.Parameters.AddWithValue("@Address", empObj.Address);

                sqlComObj.Parameters.AddWithValue("@City", empObj.City);
                sqlComObj.Parameters.AddWithValue("@Bdate", empObj.Bdate);
                sqlComObj.Parameters.AddWithValue("@Gender", empObj.gender);


                i = sqlComObj.ExecuteNonQuery();
                CloseConnection();
                if (i == 1)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;


            }
            finally
            {
                CloseConnection();
            }
        }
        public bool updateEmployee(Employees empObj)
        {
            int i = 0;

            try
            {
                CreateConnection();
                SqlCommand sqlComObj = new SqlCommand("usp_AddEmployee", sqlCon);
                sqlComObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlComObj.Parameters.AddWithValue("@intOpMode", 2);
                sqlComObj.Parameters.AddWithValue("@Name", empObj.Name);
                sqlComObj.Parameters.AddWithValue("@ID", empObj.ID);
                sqlComObj.Parameters.AddWithValue("@Address", empObj.Address);
                sqlComObj.Parameters.AddWithValue("@City", empObj.City);
                sqlComObj.Parameters.AddWithValue("@Bdate", empObj.Bdate);
                sqlComObj.Parameters.AddWithValue("@Gender", empObj.gender);
                OpenConection();
                i = sqlComObj.ExecuteNonQuery();
                CloseConnection();
                if (i == 1)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                return false;

            }
            finally
            {
                CloseConnection();
            }
        }



        public bool deleteEmployee(int empId)
        {
            try
            {
                CreateConnection();
                int i = 0;
                SqlCommand sqlComObj = new SqlCommand("usp_AddEmployee", sqlCon);
                sqlComObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlComObj.Parameters.AddWithValue("@intOpMode", 3);
                sqlComObj.Parameters.AddWithValue("@Id", empId);

                OpenConection();
                i = sqlComObj.ExecuteNonQuery();
                CloseConnection();
                if (i == 1)
                {
                    return true;
                }
                else
                    return true;
            }
            catch (Exception ex)

            {
                return false;
            }

        }

        public List<Employees> FetchAllEmployee()
        {
            try
            {
                CreateConnection();
                List<Employees> empList = new List<Employees>();
                SqlCommand sqlComObj = new SqlCommand("usp_SelectEmployee", sqlCon);
                sqlComObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlComObj.Parameters.AddWithValue("@intOpMode", 2);

                OpenConection();
                SqlDataAdapter sqlDataObj = new SqlDataAdapter(sqlComObj);
                DataTable dt = new DataTable();
                sqlDataObj.Fill(dt);
                CloseConnection();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employees empObj = new Employees();
                    empObj.ID = dt.Rows[i]["Employeeid"].ToString() != "" ? Convert.ToInt32(dt.Rows[i]["Employeeid"].ToString()) : 0;
                    empObj.Name = dt.Rows[i]["Name"].ToString() != "" ? Convert.ToString(dt.Rows[i]["Name"].ToString()) : "";
                    empObj.City = dt.Rows[i]["City"].ToString() != "" ? Convert.ToString(dt.Rows[i]["City"].ToString()) : "";
                    empObj.Address = dt.Rows[i]["Address"].ToString() != "" ? Convert.ToString(dt.Rows[i]["Address"].ToString()) : "";
                    empObj.gender = dt.Rows[i]["Gender"].ToString() != "" ? Convert.ToInt32(dt.Rows[i]["Gender"].ToString()) : 0;
                    empObj.Bdate = dt.Rows[i]["Bdate"].ToString() != "" ? Convert.ToDateTime(dt.Rows[i]["Bdate"].ToString()) : System.DateTime.Now;
                    empList.Add(empObj);

                }


                return empList;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public Employees FetchEmployee(int empId)
        {
            try
            {
                CreateConnection();

                SqlCommand sqlComObj = new SqlCommand("usp_SelectEmployee", sqlCon);
                sqlComObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlComObj.Parameters.AddWithValue("@intOpMode", 1);
                sqlComObj.Parameters.AddWithValue("@Empid", empId);

                OpenConection();
                SqlDataAdapter sqlDataObj = new SqlDataAdapter(sqlComObj);
                DataTable dt = new DataTable();
                sqlDataObj.Fill(dt);
                CloseConnection();
                Employees empObj = new Employees();

                for (int i = 0; i < 1; i++)
                {
                    
                    empObj.ID = dt.Rows[i]["Employeeid"].ToString() != "" ? Convert.ToInt32(dt.Rows[i]["Employeeid"].ToString()) : 0;
                    empObj.Name = dt.Rows[i]["Name"].ToString() != "" ? Convert.ToString(dt.Rows[i]["Name"].ToString()) : "";
                    empObj.City = dt.Rows[i]["City"].ToString() != "" ? Convert.ToString(dt.Rows[i]["City"].ToString()) : "";
                    empObj.Address = dt.Rows[i]["Address"].ToString() != "" ? Convert.ToString(dt.Rows[i]["Address"].ToString()) : "";
                    empObj.gender = dt.Rows[i]["Gender"].ToString() != "" ? Convert.ToInt32(dt.Rows[i]["Gender"].ToString()) : 0;
                    empObj.Bdate = dt.Rows[i]["Bdate"].ToString() != "" ? Convert.ToDateTime(dt.Rows[i]["Bdate"].ToString()) : System.DateTime.Now;
                
                    

                }
                return empObj;





            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
    }

}