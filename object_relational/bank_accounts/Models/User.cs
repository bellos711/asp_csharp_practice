using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_accounts.Models
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

        public List<Account> Accounts {get;set;}

        
        public List<Transaction> Transactions {get;set;}

        
        

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }//end class user
}//end namespace