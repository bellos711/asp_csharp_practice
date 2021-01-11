using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login_reg.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage="Please enter your email address")]
        [EmailAddress(ErrorMessage="Login with a valid email address")]
        public string LoginEmail {get;set;}

        public string? LoginPassword {get;set;}
    }//end class loginuser
}//end namespace