using CharityAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CharityAPI.DAO
{
    public class UserDAO
    {
        public DataTable GetUserByUserID(string userid)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("GET_USER_BY_USERID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("userid", userid);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }

        public void EditUser(User user)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("USER_EDIT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("u_userid", user.uid);
                cmd.Parameters.AddWithValue("u_firstname", user.firstname);
                cmd.Parameters.AddWithValue("u_lastname", user.lastname);
                cmd.Parameters.AddWithValue("u_mobile", user.mobile);
                cmd.Parameters.AddWithValue("u_email", user.email);
                cmd.Parameters.AddWithValue("u_avatar", user.avatar);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("UserDAO > UpdateUser: " + ex);
            }

        }
    }
}
