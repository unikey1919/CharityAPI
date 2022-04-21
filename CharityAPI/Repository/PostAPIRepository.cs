using CharityAPI.DAO;
using CharityAPI.Helper;
using CharityAPI.Models;
using System;
using System.Collections.Generic;

namespace CharityAPI.Repository
{
    public class PostAPIRepository
    {
        public List<Post> GetListPost()
        {
            List<Post> listPost = new List<Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listPost = postDAO.GetPostFromUser().ToList<Post>();
            }
            catch(Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }
            
            return listPost;
        }
        public void CreatePost(Post post)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.CreatePost(post);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > CreatePost Error: " + objEx.Message + " ]");
            }
        }
        public void DeletePost(Post post)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.DeletePost(post);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > DeletePost Error: " + objEx.Message + " ]");
            }
        }
        public void UpdatePost(Post post)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.UpdatePost(post);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > UpdatePost Error: " + objEx.Message + " ]");
            }
        }
    }
}
