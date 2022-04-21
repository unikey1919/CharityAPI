using CharityAPI.Models;
using CharityAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [Route("CreatePost")]
        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            PostAPIRepository postAPIRepository = new PostAPIRepository();
            postAPIRepository.CreatePost(post);
            return Ok(post);
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
    }
}
