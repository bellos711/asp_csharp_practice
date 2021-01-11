using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefs_n_dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Required(ErrorMessage="This field is required")]
        [MinLength(4, ErrorMessage="Minimum length of 4 chars required for dish name!")]
        public string Name {get;set;}


        [Required(ErrorMessage="This field is required")]
        [Range(0, 5, ErrorMessage="Tastiness from 1 to 5 only")]
        public int Tastiness {get;set;}


        [Required(ErrorMessage="This field is required")]
        [Range(0, 10000, ErrorMessage="Calories from 0-10,000")]
        public int Calories {get;set;}

        
        public string Description {get;set;}


        //FOREIGN KEY FOR ONE TO MANY
        public int ChefObjId {get;set;}
        //NAVIGATION PROPERTY
        public Chef ChefObj {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }//end class dish
}//end namespace