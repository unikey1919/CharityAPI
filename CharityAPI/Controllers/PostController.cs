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
        [HttpGet]
        public IEnumerable<Post> GetPostFromUser()
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetListPost();
            return listPost;
        }
        [Route("GetPostSelf")]
        [HttpPost]
        public IEnumerable<Post> GetPostSelf(UserPostInfo user)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            List<Post> listPost = postAPIRepository.GetListPost();
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
    }
}
