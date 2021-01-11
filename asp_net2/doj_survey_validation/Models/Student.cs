using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace doj_survey_model.Models
{
    public class Student
    {
        [Required(ErrorMessage="This field is required!")]
        [MinLength(4, ErrorMessage="Minimum of 4 chars required!")]
        public string name {get;set;}

        [Required(ErrorMessage="This field is required!")]
        public string location {get;set;}

        [Required(ErrorMessage="This field is required!")]
        public string language {get;set;}

        [MaxLength(20, ErrorMessage="maximum of 20 chars!")]
        public string comment {get;set;}
    }//end class student
}//end namesp[ace]