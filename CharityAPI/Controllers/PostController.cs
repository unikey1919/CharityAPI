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
    }
}
