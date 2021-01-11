using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace wedding_planner.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        
        [Required(ErrorMessage="This field is required")]
        [MinLength(2, ErrorMessage="Minimum length of 2 chars required for FIRST name!")]
        public string FirstName {get;set;}


        [Required(ErrorMessage="This field is required")]
        [MinLength(2, ErrorMessage="Minimum length of 2 chars required for LAST name!")]
        public string LastName {get;set;}


        [Required(ErrorMessage="This field is required")]
        [EmailAddress(ErrorMessage="Not a valid email format!")]
        public string Email {get;set;}

        
        [Required(ErrorMessage="Password can't be empty")]
        [MinLength(6, ErrorMessage="Minimum length of 6 chars required for PASSWORD!")]
        [DataType(DataType.Password)]
        public string Password {get;set;}



        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set;}
        


        //ONE TO MANY WITH WEDDINGS CREAETD BY USER
        public List<Wedding> WeddingsCreated {get;set;}

        //MANY TO MANY with weddings rsvped to
        public List<UserWeddingRSVP> WeddingsRSVPedTo {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }//end class user




    //-----------USER LOGIN----------------
    public class LoginUser
    {
        [Required(ErrorMessage="Please enter your email address")]
        [EmailAddress(ErrorMessage="Login with a valid email address")]
        public string LoginEmail {get;set;}

        public string LoginPassword {get;set;}
    }//end class loginuser
}//end namespace