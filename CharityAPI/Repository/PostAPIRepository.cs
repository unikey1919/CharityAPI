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
        public List<Post> GetListPost(UserPostInfo user)
        {
            List<Post> listPost = new List<Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listPost = postDAO.GetPostFromUser(user).ToList<Post>();
            }
            catch(Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }
            
            return listPost;
        }
        public List<Post> GetPostFromSelf(UserPostInfo user)
        {
            List<Post> listPost = new List<Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listPost = postDAO.GetPostFromSelf(user).ToList<Post>();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }

            return listPost;
        }
        public List<Post> GetPostAutionRequest(UserPostInfo user)
        {
            List<Post> listPost = new List<Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listPost = postDAO.GetPostAutionRequest(user).ToList<Post>();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }

            return listPost;
        }
        public List<Post> GetPostAuction(UserPostInfo user)
        {
            List<Post> listPost = new List<Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listPost = postDAO.GetPostAuction(user).ToList<Post>();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }

            return listPost;
        }
        public List<Post> GetPostAuctioning(UserPostInfo user)
        {
            List<Post> listPost = new List<Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listPost = postDAO.GetPostAuctioning(user).ToList<Post>();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }

            return listPost;
        }
        public List<Post> GetSuccessAuction(UserPostInfo user)
        {
            List<Post> listPost = new List<Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listPost = postDAO.GetSuccessAuction(user).ToList<Post>();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }

            return listPost;
        }
        public List<Comment_Post> GetListComment(int postid)
        {
            List<Comment_Post> listComment = new List<Comment_Post>();
            try
            {
                PostDAO postDAO = new PostDAO();
                listComment = postDAO.GetCommentOfPost(postid).ToList<Comment_Post>();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách comment!.  [ PostAPIRepository > GetListComment Error: " + objEx.Message + " ]");
            }

            return listComment;
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
                likeInfo.likeYour = likeInfo.lstUserInfo.Where(x=> x.uid == post.uid).Count();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }
            return likeInfo;
        }
        public AuctionInfo GetAuctionOfPost(Post post)
        {
            AuctionInfo auctionInfo = new AuctionInfo();
            auctionInfo.lstUserInfo = new List<UserPostInfo>();
            try
            {
                PostDAO postDAO = new PostDAO();
                auctionInfo.lstUserInfo = postDAO.GetAuctionOfPost(post).ToList<UserPostInfo>();
                auctionInfo.auctionCount = auctionInfo.lstUserInfo.Count();
                auctionInfo.auctionYour = auctionInfo.lstUserInfo.Where(x => x.uid == post.uid).Count();
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi lấy danh sách bài viết!.  [ PostAPIRepository > GetListPost Error: " + objEx.Message + " ]");
            }
            return auctionInfo;
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

        public void AddComment(Comment_Post comment)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.AddComment(comment);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi tạo bài viết!.  [ PostAPIRepository > CreatePost Error: " + objEx.Message + " ]");
            }
        }

        public void EditComment(Comment_Post comment)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.EditComment(comment);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi xóa bài viết!.  [ PostAPIRepository > EditComment Error: " + objEx.Message + " ]");
            }
        }

        public void DeleteComment(int commentid)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.DeleteComment(commentid);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi chỉnh sửa bài viết!.  [ PostAPIRepository > DeleteComment Error: " + objEx.Message + " ]");
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
        public void UpdatePostEndBid(Post post)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.UpdatePostEndBid(post);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi xóa bài viết!.  [ PostAPIRepository > UpdatePost Error: " + objEx.Message + " ]");
            }
        }
        public void UpdatePostStatusAuction(Post post)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.UpdatePostStatusAuction(post);
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
        public void PostActionAuction(UserPostInfo userPostInfo)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.PostActionAuction(userPostInfo);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi thao tác bài viết!.  [ PostAPIRepository > UpdatePost Error: " + objEx.Message + " ]");
            }
        }
        public void CreateHistoryBid(HistoryBid history)
        {
            try
            {
                PostDAO postDAO = new PostDAO();
                postDAO.CreateHistoryBid(history);
            }
            catch (Exception objEx)
            {
                throw new Exception("Lỗi tạo bài viết!.  [ PostAPIRepository > CreateHistoryBid Error: " + objEx.Message + " ]");
            }
        }
    }
}
