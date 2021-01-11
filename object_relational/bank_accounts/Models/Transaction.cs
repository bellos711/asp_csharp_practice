using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_accounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get;set;}
        public double TransactionAmount {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}