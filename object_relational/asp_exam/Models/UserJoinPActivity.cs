using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_exam.Models
{
    public class UserJoinPActivity
    {
        [Key]
        public int UserJoinPActivityId {get;set;}

        public int UserJoinedId {get;set;}
        public User UserJoined {get;set;}

        public int PActivityJoinedId {get;set;}
        public PActivity PActivityJoined {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}