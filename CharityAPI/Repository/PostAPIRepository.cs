using CharityAPI.DAO;
using CharityAPI.Helper;
using CharityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public LikeInfo GetLikeOfPost(Post post)
        {
            LikeInfo likeInfo = new LikeInfo();
            likeInfo.lstUserInfo = new List<UserPostInfo>();
            try
            {
                PostDAO postDAO = new PostDAO();
                likeInfo.lstUserInfo = postDAO.GetLikeOfPost(post).ToList<UserPostInfo>();
                likeInfo.likeCount = likeInfo.lstUserInfo.Count();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }

            return likeInfo;
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
                throw new Exception("Lỗi tạo bài viết!.  [ PostAPIRepository > CreatePost Error: " + objEx.Message + " ]");
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
                throw new Exception("Lỗi chỉnh sửa bài viết!.  [ PostAPIRepository > DeletePost Error: " + objEx.Message + " ]");
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
                throw new Exception("Lỗi xóa bài viết!.  [ PostAPIRepository > UpdatePost Error: " + objEx.Message + " ]");
            }
        }
        public void PostAction(UserPostInfo userPostInfo)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.PostAction(userPostInfo);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi thao tác bài viết!.  [ PostAPIRepository > UpdatePost Error: " + objEx.Message + " ]");
            }
        }
    }
}
