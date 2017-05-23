using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrantActivity.Models
{
    public class RatingAndReviews
    {
        public int UserId { get; set; }
        public int RatingStar { get; set; }
        public string ConsumerName { get; set; }
        public string ReviewHeader { get; set; }
        public string ReviewContent { get; set; }
    }
}