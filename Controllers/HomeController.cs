using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SummerDrinks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace SummerDrinks.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult RegisterForm()
        {
            return View();
        }
        [HttpPost("new/user")]
        public IActionResult NewUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                int? UserId = HttpContext.Session.GetInt32("UserId");
                HttpContext.Session.SetString("UserName", newUser.FirstName);
                return Redirect($"account/{(int)UserId}");
            }
            return View("RegisterForm");
        }
        //*********************************User Page *******************************************************
        [HttpGet("account/{UserId}")]
        public IActionResult AccountPage(int UserId)
        {
            Console.WriteLine("**********I am inside the AccountPage function**********");
            ViewBag.SessionName = HttpContext.Session.GetString("UserName");
            ViewBag.SessionId = HttpContext.Session.GetInt32("UserId");
            int? UseId = HttpContext.Session.GetInt32("UserId");
            if (UseId == null)
            {
                return RedirectToAction("LoginPage");
            }
            else
            {
                ViewBag.User = _context.Users
                    .Include(c => c.CreatedDrinks)
                    .FirstOrDefault(u => u.UserId == UserId);
                return View();
            }
        }

        [HttpGet("loginPage")]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser LogUser)
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            if (ModelState.IsValid)
            {
                var dbUser = _context.Users.FirstOrDefault(user => user.Email == LogUser.Email);
                if (dbUser == null)
                {
                    ModelState.AddModelError("Email", "Invalid login");
                    return View("LoginPage");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(LogUser, dbUser.Password, LogUser.Password);
                if (result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid login");
                    return View("LoginPage");
                }
                HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                int? UserId = HttpContext.Session.GetInt32("UserId");
                HttpContext.Session.SetString("UserName", dbUser.FirstName);
                return Redirect($"account/{(int)UserId}");
            }
            return View("LoginPage");
        }


        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage");
        }
        //**************************************************Add Drink Stuff below here ********************************************************

        [HttpGet("drinks")]
        public IActionResult AllDrinks()
        {
            ViewBag.SessionName = HttpContext.Session.GetString("UserName");
            ViewBag.SessionId = HttpContext.Session.GetInt32("UserId");
            int? UseId = HttpContext.Session.GetInt32("UserId");
            if (UseId == null)
            {
                return RedirectToAction("LoginPage");
            }
            ViewBag.AllDrinks = _context.Drinks.ToList();
            return View();
        }
        //***********************come back and add ID when displaying single drink page.
        [HttpGet("drinks/id")]
        public IActionResult SingleDrink()
        {
            ViewBag.SessionName = HttpContext.Session.GetString("UserName");
            ViewBag.SessionId = HttpContext.Session.GetInt32("UserId");
            int? UseId = HttpContext.Session.GetInt32("UserId");
            if (UseId == null)
            {
                return RedirectToAction("LoginPage");
            }
            return View();
        }
        //*********************************Drink Form Control***********************
        [HttpGet("drink")]
        public IActionResult Drink()
        {
            ViewBag.SessionId = HttpContext.Session.GetInt32("UserId");
            return View("Drink");
        }
        [HttpPost("drink/new")]
        public IActionResult NewDrink(Drink newDrink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDrink);
                _context.SaveChanges();
                return Redirect($"/account/{newDrink.UserId}");
            }
            return View("Drink");
        }
        [HttpGet("delete/{drinkId}")]
        public IActionResult DeleteDrink(int drinkId)
        {
            Drink deleteDrink = _context.Drinks.FirstOrDefault(drink => drink.DrinkId == drinkId);
            _context.Drinks.Remove(deleteDrink);
            _context.SaveChanges();
            return Redirect($"/account/{deleteDrink.UserId}");
        }
        //*********************************End Drink Form Control***********************
    }
}
