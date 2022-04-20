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
        
    }
}
