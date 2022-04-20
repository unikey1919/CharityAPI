using CharityAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace CharityAPI.DAO
{
    public class PostDAO
    {
        public DataTable GetPostFromUser() 
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            string query = "select * from user_post";
            MySqlCommand com = new MySqlCommand(query);
            com.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(com);
            dr.Fill(dt);
            
            //while (dr.Read())
            //{
            //    posts.Add(new Post
            //    {
            //        postid = Convert.ToInt32(dr["postid"].ToString()),
            //        uid = dr["uid"].ToString(),
            //        postcontent = dr["postcontent"].ToString(),
            //        picture = dr["picture"].ToString(),
            //        like = Convert.ToInt32(dr["like"].ToString()),
            //        createdate = dr["createdate"].ToString()
            //    });
            //}
            mySql.Close();
            return dt;
        }
        
    }
}
