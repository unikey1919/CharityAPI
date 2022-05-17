using CharityAPI.Models;
using CharityAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace CharityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserAPIRepository userAPIRepository = new UserAPIRepository();
        [Route("GetUserByUserID/{userid}")]
        [HttpGet]
        public ApiResultMessage GetUserByUserID(string userid)
        {
            try
            {

                DataTable dt = userAPIRepository.GetUserByUserID(userid);
                return new ApiResultMessage { IsError = false, Message = JsonConvert.SerializeObject(dt), MessageDetail = "" };
            }
            catch (Exception ex)
            {
                return new ApiResultMessage { IsError = true, Message = ex.Message, MessageDetail = ex.StackTrace };
            }
        }

        [Route("GetUserProFile")]
        [HttpPost]
        public IEnumerable<User> GetUserProFile(User user)
        {

            List<User> lst = userAPIRepository.GetUserProFile(user.uid);
            return lst;
        }

        [HttpPut]
        [Route("EditUser")]
        public ApiResultMessage EditUser(User user)
        {
            try
            {
                userAPIRepository.EditUser(user);
                return new ApiResultMessage { IsError = false, Message = "", MessageDetail = "" };
            }
            catch (Exception ex)
            {
                return new ApiResultMessage { IsError = true, Message = ex.Message, MessageDetail = ex.StackTrace };
            }
        }
    }
}
