using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerDrinks.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [Display(Name="User Name:")]
        public string UserName {get; set;}
        [Required]
        [Display(Name="First Name:")]
        [MinLength(2, ErrorMessage="First name needs to be at least 2 characters.")]
        public string FirstName {get; set;}
        [Required]
        [Display(Name="Last Name:")]
        [MinLength(2, ErrorMessage="Last Name needs to be at least 2 characters.")]
        public string LastName {get; set;}
        [EmailAddress]
        [Required]
        
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Email needs to be at least 8 characters.")]
        public string Password {get; set;}
        [NotMapped]
        [Required]
        [Display(Name="Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password do not match.")]
        public string Confirm{get; set;}

        //One to Many Relationships
        public List<Drink> CreatedDrinks {get;set;}
        // Many to Many Relationship
        public List<FavoriteDrink> FavoriteDrinkList {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}