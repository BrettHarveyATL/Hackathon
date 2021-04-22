using System;
using System.ComponentModel.DataAnnotations;

namespace SummerDrinks.Models
{
    public class FavoriteDrink
    {
        [Key]
        public int FavoriteDrinkId {get;set;}
        [Required]
        public int UserId {get; set;}
        [Required]
        public int DrinkId {get; set;}
        public User User {get; set;}
        public Drink Drink {get; set;}

    }
}