using CharityAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace CharityAPI.DAO
{
    public class PostDAO
    {
        public DataTable GetPostFromUser() 
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            string query = "CALL POST_INFO";
            MySqlCommand com = new MySqlCommand(query);
            com.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(com);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        
        public void CreatePost(Post post)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POST_INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_uid", post.uid);
                cmd.Parameters.AddWithValue("@i_postcontent", post.postcontent);
                cmd.Parameters.AddWithValue("@i_picture", post.picture);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("PostDAO > CreatePost: " + ex);
            }
        }
        public void DeletePost(Post post)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POST_DEL");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_postid", post.postid);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > DeletePost: " + ex);
            }
        }
        public void UpdatePost(Post post)
        {
            try
            {
                
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POST_UPD");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_postid", post.postid);
                cmd.Parameters.AddWithValue("@i_postcontent", post.postcontent);
                cmd.Parameters.AddWithValue("@i_picture", post.picture);
                cmd.Parameters.AddWithValue("@i_likecount", post.likecount);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > UpdatePost: " + ex);
            }
        }

        public string ConvertTextToUTF8 (string textConvert)
        {
            byte[] bytes = Encoding.Default.GetBytes(textConvert);
            textConvert = Encoding.UTF8.GetString(bytes);
            return textConvert;
        }
    }
}
