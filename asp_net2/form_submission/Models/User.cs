using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public class User
    {
        [Required(ErrorMessage="This field is required")]
        [MinLength(4, ErrorMessage = "Must be at least 4 characters")]
        public string fName { get; set; }

        [Required(ErrorMessage="This field is required")]
        [MinLength(4, ErrorMessage = "Must be at least 4 characters")]
        public string lName { get; set; }

        [Required(ErrorMessage="This field is required")]
        [Range(0,120, ErrorMessage = "Can't have negative age or over 120 u dead")]
        public string age { get; set; }
        
        [Required(ErrorMessage="This field is required")]
        [EmailAddress(ErrorMessage="Invalid email address")]
        public string email { get; set; }

        [Required(ErrorMessage="This field is required")]
        [MinLength(8, ErrorMessage = "Must be at least 4 characters")]
        public string password { get; set; }
        
    }//end user
}//end namespace