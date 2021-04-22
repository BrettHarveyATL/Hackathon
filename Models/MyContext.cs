using Microsoft.EntityFrameworkCore;
using System;

namespace SummerDrinks.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users {get; set;}
        public DbSet<Drink> Drinks {get; set;}
        public DbSet<FavoriteDrink> FavoriteDrinks {get; set;}
        
    }
}