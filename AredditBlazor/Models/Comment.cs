using System;
namespace Model
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public double CommentVotes { get; set; } = 0;

        public string CommentUser { get; set; }

        public long PostId { get; set; }


        public void UpvoteComment()
        {
            CommentVotes += 1;
        }

        public void DownvoteComment()
        {
            CommentVotes -= 1;
        }


        public Comment()
        {

        }
    }
}

