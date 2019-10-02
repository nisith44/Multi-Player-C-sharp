using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementSystem.EntityClasses
{
    public class tel_number
    {
       
        public int contactId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string tel { get; set; }
        public string addess { get; set; }
        public string gender { get; set; }

        static string myconstring = ConfigurationManager.ConnectionStrings["contactConnectionString"].ConnectionString; 

        //insert contact
        public bool insert_tel_numbers(tel_number t)
        {
            bool is_success = false;
            SqlConnection conn = new SqlConnection(myconstring);

            try
            {
                string sql = "INSERT INTO tel_numbers(fname,lname,tel,address,gender) VALUES (@fname,@lname,@tel,@address,@gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fname", t.firstName);
                cmd.Parameters.AddWithValue("@lname", t.lastName);
                cmd.Parameters.AddWithValue("@tel", t.tel);
                cmd.Parameters.AddWithValue("@address", t.addess);
                cmd.Parameters.AddWithValue("@gender", t.gender);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) {
                    is_success = true; }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return is_success;
        }

        //select data
        public DataTable select()
        {
            SqlConnection conn = new SqlConnection(myconstring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tel_numbers";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        //update data
        public bool update_contact(tel_number t)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconstring);

            try
            {
                string sql = "UPDATE tel_numbers SET fname=@fname,lname=@lname,tel=@tel,address=@address,gender=@gender WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", t.contactId);
                cmd.Parameters.AddWithValue("@fname", t.firstName);
                cmd.Parameters.AddWithValue("@lname", t.lastName);
                cmd.Parameters.AddWithValue("@tel", t.tel);
                cmd.Parameters.AddWithValue("@address", t.addess);
                cmd.Parameters.AddWithValue("@gender", t.gender);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    issuccess = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return issuccess;

        }


        //delete contact
        public bool delete_contact(tel_number t)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconstring);
            try
            {
                string sql = "DELETE FROM tel_numbers WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", t.contactId);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    issuccess = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return issuccess;
        }

        //search contacts
        public DataTable search(String key)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconstring);
            try
            {
                string sql = "SELECT * FROM tel_numbers WHERE fname LIKE '%"+key+"%'   ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
