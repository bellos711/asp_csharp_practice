using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wedding_planner.Models
{
    public class UserWeddingRSVP
    {
        [Key]
        public int UserWeddingRSVPId {get;set;}

        public int UserRSVPedId {get;set;}
        public User UserRSVPed {get;set;}

        public int WeddingRSVPedId {get;set;}
        public Wedding WeddingRSVPed {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}