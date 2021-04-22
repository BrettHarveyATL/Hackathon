using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SummerDrinks.Models
{
    public class Drink
    {
        [Key]
        public int DrinkId {get; set;}
        [Required]
        public string Liquor {get; set;}
        public string IngredientOne {get; set;}
        public string IngredientTwo {get; set;}
        public string IngredientThree {get; set;}
        public string IngredientFour {get; set;}
        public string IngredientFive {get; set;}
        [Required]
        public bool Ice {get; set;}
        // One to Many Relationship
        public int UserId {get; set;}
        public User Creator {get;set;}
        // Many to Many Relationship
        public List<FavoriteDrink> FavoriteDrinkList { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}