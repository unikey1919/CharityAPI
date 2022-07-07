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
        public DataTable GetPostFromUser(UserPostInfo user) 
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("POST_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("I_CURRENTPAGE", user.pageIndex);
            cmd.Parameters.AddWithValue("I_PAGESIZE", user.pageSize);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        public DataTable GetPostFromUserMinhChung(UserPostInfo user)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("GET_POSTMC");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("I_POSTID", user.postid);
            cmd.Parameters.AddWithValue("I_UID", user.uid);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        public DataTable GetPostFromSelf(UserPostInfo user)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("POSTSELF_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("I_UID", user.uid);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        public DataTable GetPostAutionRequest(UserPostInfo user)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("POSTAUTIONREQUEST_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("I_UID", user.uid);
            cmd.Parameters.AddWithValue("I_CURRENTPAGE", user.pageIndex);
            cmd.Parameters.AddWithValue("I_PAGESIZE", user.pageSize);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        public DataTable GetPostAuction(UserPostInfo user)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("POSTAUCTION_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("I_UID", user.uid);
            cmd.Parameters.AddWithValue("I_CURRENTPAGE", user.pageIndex);
            cmd.Parameters.AddWithValue("I_PAGESIZE", user.pageSize);
            cmd.Parameters.AddWithValue("I_STATUS", user.status);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        public DataTable GetPostAuctioning(UserPostInfo user)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("POSTAUCTIONING_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("I_UID", user.uid);
            cmd.Parameters.AddWithValue("I_CURRENTPAGE", user.pageIndex);
            cmd.Parameters.AddWithValue("I_PAGESIZE", user.pageSize);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        public DataTable GetSuccessAuction(UserPostInfo user)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("SUCCESSAUTION_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("I_UID", user.uid);
            cmd.Parameters.AddWithValue("I_CURRENTPAGE", user.pageIndex);
            cmd.Parameters.AddWithValue("I_PAGESIZE", user.pageSize);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }

        public DataTable GetCommentOfPost(int postid)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("GET_COMMENT_OF_POST");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("post_id", postid);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }

        public DataTable GetLikeOfPost(Post post)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("LIKE_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_postid", post.postid);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            dr.Fill(dt);
            mySql.Close();
            return dt;
        }
        public DataTable GetAuctionOfPost(Post post)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand("AUCTION_INFO");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_postid", post.postid);
            cmd.Connection = mySql;
            mySql.Open();
            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
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
        public void CreatePostMinhChung(Post post)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POSTMC_INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_postid", post.uid);
                cmd.Parameters.AddWithValue("@i_uid", post.uid);
                cmd.Parameters.AddWithValue("@i_postcontent", post.postcontent);
                cmd.Parameters.AddWithValue("@i_picture", post.picture);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > CreatePost: " + ex);
            }
        }
        public void AddComment(Comment_Post comment)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("ADD_COMMENT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("postid", comment.postid);
                cmd.Parameters.AddWithValue("commentcontent", comment.commentcontent);
                cmd.Parameters.AddWithValue("commentpicture", comment.commentpicture);
                cmd.Parameters.AddWithValue("uid", comment.uid);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > AddComment: " + ex);
            }
        }

        public void EditComment(Comment_Post comment)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("COMMENT_EDIT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("c_commentid", comment.commentid);
                cmd.Parameters.AddWithValue("c_commentcontent", comment.commentcontent);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > EditComment: " + ex);
            }
        }

        public void DeleteComment(int commentid)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("COMMENT_DELETE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("c_commentid", commentid);
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
                cmd.Parameters.AddWithValue("@i_status", post.status);
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
        public void UpdatePostMinhChung(Post post)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POSTMC_UPD");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_mcid", post.mcid);
                cmd.Parameters.AddWithValue("@i_postcontent", post.postcontent);
                cmd.Parameters.AddWithValue("@i_picture", post.picture);
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
        public void UpdatePostEndBid(HistoryBid history)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POST_UPDENDBID");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_postid", history.postid);
                cmd.Parameters.AddWithValue("@i_uid", history.userwin);
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
        public void UpdatePostStatusAuction(Post post)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POST_UPDSTATUS");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_postid", post.postid);
                cmd.Parameters.AddWithValue("@i_status", post.status);
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
        public void PostAction(UserPostInfo userPostInfo)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POST_ACTIONS");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_uid", userPostInfo.uid);
                cmd.Parameters.AddWithValue("@p_postid", userPostInfo.postid);
                cmd.Parameters.AddWithValue("@p_type", userPostInfo.type);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > PostAction: " + ex);
            }
        }
        public void PostActionAuction(UserPostInfo userPostInfo)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("POSTAUCTION_ACTIONS");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_uid", userPostInfo.uid);
                cmd.Parameters.AddWithValue("@p_postid", userPostInfo.postid);
                cmd.Parameters.AddWithValue("@p_type", userPostInfo.type);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > PostAction: " + ex);
            }
        }
        public void CreateHistoryBid(HistoryBid history)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
                MySqlConnection mySql = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand("HISTORYBID_INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_userwin", history.userwin);
                cmd.Parameters.AddWithValue("@i_userold", history.userold);
                cmd.Parameters.AddWithValue("@i_postid", history.postid);
                cmd.Parameters.AddWithValue("@i_topbid", history.topbid);
                cmd.Connection = mySql;
                mySql.Open();
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("PostDAO > CreateHistoryBid: " + ex);
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
