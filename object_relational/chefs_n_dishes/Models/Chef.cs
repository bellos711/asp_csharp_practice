using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefs_n_dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Required(ErrorMessage="chef's first name is required")]
        [MinLength(2, ErrorMessage="Chef's first name must be 2 or more chars.")]
        public string ChefFName {get;set;}

        [Required(ErrorMessage="chef's last name is required")]
        [MinLength(2, ErrorMessage="Chef's last name must be 2 or more chars.")]
        public string ChefLName {get;set;}

        [Required(ErrorMessage="chef's dob is required")]
        public DateTime ChefAge {get;set;}

        //CREATE A LIST OF DISH OBJECTS
        public List<Dish> Dishes {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}