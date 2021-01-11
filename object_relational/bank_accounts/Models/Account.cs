using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_accounts.Models
{
    public class Account{

        [Key]
        public int AccountID {get;set;}
        public string AccountName {get;set;}
        public double AccountBalance {get;set;}


        public int UserId {get;set;}
        public User User {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}