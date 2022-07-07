using CharityAPI.Models;
using CharityAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [Route("GetPost")]
        [HttpPost]
        public IEnumerable<Post> GetPostFromUser(UserPostInfo user)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetListPost(user).OrderByDescending(time => time.createdate).ToList(); ;
            return listPost;
        }
        [Route("GetPostAuction")]
        [HttpPost]
        public IEnumerable<Post> GetPostAuction(UserPostInfo user)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetPostAuction(user).OrderByDescending(time => time.createdate).ToList(); ;
            return listPost;
        }
        [Route("GetPostAuctioning")]
        [HttpPost]
        public IEnumerable<Post> GetPostAuctioning(UserPostInfo user)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetPostAuctioning(user).OrderByDescending(time => time.createdate).ToList(); ;
            return listPost;
        }
        [Route("GetSuccessAuction")]
        [HttpPost]
        public IEnumerable<Post> GetSuccessAuction(UserPostInfo user)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetSuccessAuction(user).OrderByDescending(time => time.createdate).ToList(); ;
            return listPost;
        }
        [Route("GetPostSelf")]
        [HttpPost]
        public IEnumerable<Post> GetPostSelf(UserPostInfo user)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetPostFromSelf(user);
            var listPostSelf = listPost.Where(x => x.uid == user.uid).OrderByDescending(time => time.createdate).ToList();
            return listPostSelf;
        }
        [Route("GetLikeOfPost")]
        [HttpPost]
        public LikeInfo GetLikeOfPost(Post post)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            LikeInfo likeInfo = postAPIRepository.GetLikeOfPost(post);
            return likeInfo;
        }
        [Route("GetPostAutionRequest")]
        [HttpPost]
        public IEnumerable<Post> GetPostAutionRequest(UserPostInfo user)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetPostAutionRequest(user);
            var listPostSelf = listPost.Where(x => x.uid == user.uid).OrderByDescending(time => time.createdate).ToList();
            return listPostSelf;
        }
        [Route("GetAuctionOfPost")]
        [HttpPost]
        public AuctionInfo GetAuctionOfPost(Post post)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            AuctionInfo auctionInfo = postAPIRepository.GetAuctionOfPost(post);
            return auctionInfo;
        }
        [Route("GetCommentOfPost/{postid}")]
        [HttpGet]
        public IEnumerable<Comment_Post> GetCommentOfPost(int postid)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Comment_Post> listComment = postAPIRepository.GetListComment(postid);
            return listComment;
        }

        [Route("CreatePost")]
        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            postAPIRepository.CreatePost(post);
            return Ok(post);
        }

        [Route("AddComment")]
        [HttpPost]
        public ActionResult AddComment(Comment_Post comment)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            postAPIRepository.AddComment(comment);
            return Ok(comment);
        }

        [Route("EditComment")]
        [HttpPut]
        public ApiResultMessage EditComment(Comment_Post comment)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.EditComment(comment);
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }

        [Route("DeleteComment/{commentid}")]
        [HttpDelete]
        public ApiResultMessage DeleteComment(int commentid)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.DeleteComment(commentid);
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }

        [Route("DeletePost")]
        [HttpPost]
        public ApiResultMessage DeletePost(Post post)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.DeletePost(post);
            }
            catch(Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = ""};
        }

        [Route("UpdatePost")]
        [HttpPost]
        public ApiResultMessage UpdatePost(Post post)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.UpdatePost(post);
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }
        [Route("UpdatePostEndBid")]
        [HttpPost]
        public ApiResultMessage UpdatePostEndBid(HistoryBid history)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.CreateHistoryBid(history);
                postAPIRepository.UpdatePostEndBid(history);           
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }
        [Route("UpdatePostStatusAuction")]
        [HttpPost]
        public ApiResultMessage UpdatePostStatusAuction(Post post)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.UpdatePostStatusAuction(post);
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }

        [Route("PostAction")]
        [HttpPost]
        public ApiResultMessage PostAction(UserPostInfo userPostInfo)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.PostAction(userPostInfo);
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }
        [Route("PostActionAuction")]
        [HttpPost]
        public ApiResultMessage PostActionAuction(UserPostInfo userPostInfo)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.PostActionAuction(userPostInfo);
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }
        [Route("CreateHistoryBid")]
        [HttpPost]
        public ApiResultMessage CreateHistoryBid(HistoryBid history)
        {
            try
            {
                PostAPIRepository postAPIRepository = new PostAPIRepository();
                postAPIRepository.CreateHistoryBid(history);
            }
            catch (Exception objEx)
            {
                return new ApiResultMessage { IsError = true, Message = objEx.Message };
            }

            return new ApiResultMessage { IsError = false, Message = "" };
        }
    }
}
