using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace wedding_planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required(ErrorMessage="Wedder 1 Can't be empty")]
        [MinLength(2, ErrorMessage="Wedder1's name must be at least 2 chars")]
        public string WedderOne {get;set;}

        [Required(ErrorMessage="Wedder 2 Can't be empty")]
        [MinLength(2, ErrorMessage="Wedder1's name must be at least 2 chars")]
        public string WedderTwo {get;set;}

        
        public DateTime? Date {get;set;}

        [Required(ErrorMessage="Must have an address")]
        [MinLength(3,ErrorMessage="Address must be at least 3 chars")]
        public string Address {get;set;}



        //ONE TO MANY WITH CREATOR OF WEDDING
        public int CreatorId {get;set;}
        public User Creator {get;set;}


        //MANY TO MANY with users rsvping to wedding
        public List<UserWeddingRSVP> UsersWhoRSVPed {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }
}//end namespace