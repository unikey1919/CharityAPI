using System;
using System.Collections.Generic;

namespace CharityAPI.Models
{
    public class Post
    {
        public int postid { get; set; }
        public string uid { get; set; }
        public string postcontent { get; set; }
        public string picture { get; set; }
        public int likecount { get; set; }
        public string createdate { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string avatar { get; set; }
    }
    public class UserPostInfo
    {
        public int postid { get; set; }
        public string uid { get; set; }
        public int type { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
    public class LikeInfo
    {
       public List<UserPostInfo> lstUserInfo { get; set; } 
       public int likeCount { get; set; }
       public int likeYour { get; set; }
    }

    public class Comment_Post
    {
        public int commentid { get; set; }
        public int postid { get; set; }
        public string commentcontent { get; set; }
        public DateTime createdate { get; set; }
        public DateTime updatedate { get; set; }
        public string commentpicture { get; set; }
        public int like { get; set; }
        public string uid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string avatar { get; set; }
    }
}
