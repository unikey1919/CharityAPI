using CharityAPI.DAO;
using CharityAPI.Helper;
using CharityAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CharityAPI.Repository
{
    public class UserAPIRepository
    {
        private static UserDAO userDAO = new UserDAO();
        public DataTable GetUserByUserID(string userid)
        {
            try
            {
                DataTable dt = userDAO.GetUserByUserID(userid);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Elearning > GetStudentId Error: " + ex.Message);
            }
        }
        public List<User> GetUserProFile(string userid)
        {
            try
            {
                List<User> lst = userDAO.GetUserByUserID(userid).ToList<User>(); ;
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("Elearning > GetStudentId Error: " + ex.Message);
            }
        }
        public void EditUser(User user)
        {
            try
            {
                userDAO.EditUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception("CharityAPI > UpdateUser Error: " + ex.Message);
            }
        }
    }
}
