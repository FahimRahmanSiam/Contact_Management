using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Management.classes
{
    class EcontactClasses
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        static string myconnStr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //select data from database
        public DataTable Select()
        {   
            //establish the connection!!
            SqlConnection conn = new SqlConnection(myconnStr);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Contacts";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        //Inserting data into database
        public bool Insert(EcontactClasses c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnStr);
            try
            {
                string sql = "INSERT INTO Contacts (FirstName,LastName,Mobile,Address,Email,Gender) VALUES (@FirstName,@LastName,@Mobile,@Address,@Email,@Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@Mobile", c.Mobile);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query is successful then rows>0 otherwise rows=0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //Updateing data of database
        public bool Update(EcontactClasses c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnStr);
            try
            {
                string sql = "Update Contacts SET FirstName=@FirstName,LastName=@LastName,Mobile=@Mobile,Address=@Address,Email=@Email,Gender=@Gender WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@Mobile", c.Mobile);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Email",c.Email);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query is successful then rows>0 otherwise rows=0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //Deleting data From database
        public bool Delete(EcontactClasses c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnStr);
            try
            {
                string sql = "Delete From Contacts  WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query is successful then rows>0 otherwise rows=0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
