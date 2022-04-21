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
    }
}
