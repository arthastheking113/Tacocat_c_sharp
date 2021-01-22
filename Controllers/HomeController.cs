using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tacocat_c_sharp.Models;

namespace Tacocat_c_sharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Palindrome model = new Palindrome();
            if (model.Message == null)
            {
                model.Message = "Result";
            }
            
            if (model.Isclear)
            {
                model.Isclear = false;
                model.Inputword = "";
                model.Message = "Result";
            }
            return View(model);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Palindrome input)
        {
            string inputWord = input.Inputword.ToLower();
            inputWord = inputWord.Replace(" ", "");
            string revWord;
            char[] charArray = inputWord.ToCharArray();
            Array.Reverse(charArray);
            revWord = new string(charArray);

            if (revWord == inputWord)
            {
                
                input.Isclear = true;
                input.IsPalindrome = true;
                input.Message = $"Success {input.Inputword} is a Palindrome!";
            } else
            {
                
                input.Isclear = true;
                input.Message = $"Sorry {input.Inputword} is NOT a Palindrome!";
            }

            return View(input);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
