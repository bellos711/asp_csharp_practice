using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace asp_exam.Models
{
    public class PActivity
    {
        [Key]
        public int PActivityId {get;set;}

        [Required(ErrorMessage="Activity title can't be empty")]
        [MinLength(2, ErrorMessage="Activity title must be at least 2 chars")]
        public string PActivityName {get;set;}



        // [Required(ErrorMessage="Please enter a time")]
        // public TimeSpan PActivityTime {get;set;}


        [Required(ErrorMessage="Select a date.")]
        public DateTime? DateNTime {get;set;}

        [Required(ErrorMessage="Must have a duration")]
        public int? Duration {get;set;}

        [Required(ErrorMessage="You need to select the range of activity")]
        public string PActivitySpan {get;set;}

        [Required(ErrorMessage="Your activity needs a description")]
        public string Description {get;set;}



        //ONE TO MANY WITH CREATOR OF ACTIVITY
        public int CreatorId {get;set;}
        public User Creator {get;set;}


        //MANY TO MANY with users JOINING to ACTIVITY
        public List<UserJoinPActivity> UsersWhoJoined {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }
}//end namespace