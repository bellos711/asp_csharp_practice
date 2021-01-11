using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using dojidachi.Models;

namespace dojidachi.Controllers
{
    public class HomeController : Controller
    {
        Random rand = new Random(); 
        

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? DojidachiFullnessFromSession = HttpContext.Session.GetInt32("DojidachiFullness");
            int? DojidachiHappinessFromSession = HttpContext.Session.GetInt32("DojidachiHappiness");
            int? DojidachiMealsFromSession = HttpContext.Session.GetInt32("DojidachiMeals");
            int? DojidachiEnergyFromSession = HttpContext.Session.GetInt32("DojidachiEnergy");
            string DojidachiMessage = HttpContext.Session.GetString("DojidachiMessage");
            if(DojidachiEnergyFromSession == null)
            {
                return RedirectToAction("Restart");
            }//endif
            else
            {
                if(
                    DojidachiFullnessFromSession >= 100 &&
                    DojidachiHappinessFromSession >= 100 && 
                    DojidachiMealsFromSession >= 100 &&
                    DojidachiEnergyFromSession >= 100
                    )
                {
                    return RedirectToAction("Win");
                }

                if(
                    DojidachiFullnessFromSession <= 0 &&
                    DojidachiHappinessFromSession <= 0 && 
                    DojidachiMealsFromSession <= 0 &&
                    DojidachiEnergyFromSession <= 0
                    )
                {
                    return RedirectToAction("Lost");
                }
                System.Console.WriteLine("--------------------------------------------------------------------------------------");
                System.Console.WriteLine($"test, your dojis energy is {DojidachiEnergyFromSession}");
                
                Dojidachi WDoji = new Dojidachi()
                {
                    Fullness = (int)DojidachiFullnessFromSession,
                    Happiness = (int)DojidachiHappinessFromSession,
                    Meals = (int)DojidachiMealsFromSession,
                    Energy = (int)DojidachiEnergyFromSession,
                    MyMsg = DojidachiMessage
                };//end obj instantiation

                return View("Index", WDoji);
            }//endelse
        }//end index

        [HttpGet]
        [Route("/win")]
        public IActionResult Win()
        {
            return View("Win");
        }

        [HttpGet]
        [Route("/lost")]
        public IActionResult Lost()
        {
            return View("Lost");
        }

        [HttpGet]
        [Route("/restart")]
        public IActionResult Restart()
        {
            // Dojidachi myDojidachi = new Dojidachi();
            HttpContext.Session.SetInt32("DojidachiFullness", (int)20);
            HttpContext.Session.SetInt32("DojidachiHappiness", (int)20);
            HttpContext.Session.SetInt32("DojidachiMeals", (int)3);
            HttpContext.Session.SetInt32("DojidachiEnergy", (int)50);
            HttpContext.Session.SetString("DojidachiMessage", "");
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("/feed")]
        public IActionResult Feed()
        {   
            string Myessage = "";
            System.Console.WriteLine("Feeding dojidachi now....");
            int? dojiFood = HttpContext.Session.GetInt32("DojidachiMeals");
            int? dojiFull = HttpContext.Session.GetInt32("DojidachiFullness");
            System.Console.WriteLine($"test, your dojis meal is {dojiFood}");
            if(Chance() <= 25)
            {
                System.Console.WriteLine($"Dochidachi doesn't want to eat 25%. lost some meals and is now at {dojiFood}");
                Myessage = ($"Dochidachi doesn't want to eat 25%. lost some meals and is now at {dojiFood}");
                HttpContext.Session.SetString("DojidachiMessage", Myessage);
                if(dojiFood <= 0)
                {
                    System.Console.WriteLine("OUT OF MEALS");
                    Myessage = "OUT OF MEALS";
                    HttpContext.Session.SetString("DojidachiMessage", Myessage);
                }
                else
                {
                    dojiFood -= 1;
                    HttpContext.Session.SetInt32("DojidachiMeals", (int)dojiFood);
                }
            }
            else
            {
                if(dojiFood <= 0)
                {
                    System.Console.WriteLine("OUT OF MEALS");
                    Myessage = "OUT OF MEALS";
                    HttpContext.Session.SetString("DojidachiMessage", Myessage);
                }
                else
                {
                    dojiFood -= 1;
                    HttpContext.Session.SetInt32("DojidachiMeals", (int)dojiFood);
                    // System.Random rand = new Random();
                    dojiFull = dojiFull + rand.Next(5, 11);
                    HttpContext.Session.SetInt32("DojidachiFullness", (int)dojiFull);
                    System.Console.WriteLine($"Dojidachi ate, fullness is now {dojiFull}");
                    Myessage = $"Dojidachi ate, fullness is now {dojiFull}";
                    HttpContext.Session.SetString("DojidachiMessage", Myessage);
                }
            }
            return RedirectToAction("Index");
        }//end Feed


        [HttpGet]
        [Route("/play")]
        public IActionResult Play()
        {
            string Myessage = "";
            int? dojiEner = HttpContext.Session.GetInt32("DojidachiEnergy");
            int? dojiHapp = HttpContext.Session.GetInt32("DojidachiHappiness");
            

            if(Chance() <= 25)
            {
                if(dojiEner <= 0)
                {
                    System.Console.WriteLine($"Dojidachi not enough energy to play. Energy is {dojiEner}");
                    Myessage = ($"Dojidachi not enough energy to play. Energy is {dojiEner}");
                    HttpContext.Session.SetString("DojidachiMessage", Myessage);
                }
                else
                {
                    dojiEner -= 5;
                    System.Console.WriteLine($"Dojidachi doesn't want to play with you, lol. 25%. lost some energy and is now at {dojiEner}");
                    HttpContext.Session.SetInt32("DojidachiEnergy", (int)dojiEner);
                    Myessage = ($"Dojidachi doesn't want to play with you, lol. 25%. lost some energy and is now at {dojiEner}");
                    HttpContext.Session.SetString("DojidachiMessage", Myessage);
                }
            }
            else
            {
                if(dojiEner <= 0)
                {
                    System.Console.WriteLine($"Dojidachi not enough energy to play. Energy is {dojiEner}");
                    Myessage = ($"Dojidachi not enough energy to play. Energy is {dojiEner}");
                    HttpContext.Session.SetString("DojidachiMessage", Myessage);
                }
                else
                {
                    dojiEner -= 5;
                    HttpContext.Session.SetInt32("DojidachiEnergy", (int)dojiEner);

                    dojiHapp = dojiHapp + rand.Next(5, 11);
                    System.Console.WriteLine($"Dojidachi playedl, happiness is now {dojiHapp}");
                    HttpContext.Session.SetInt32("DojidachiHappiness", (int)dojiHapp);
                    Myessage =($"Dojidachi playedl, happiness is now {dojiHapp}");
                    HttpContext.Session.SetString("DojidachiMessage", Myessage);
                }
            }
            return RedirectToAction("Index");
        }//end play


        [HttpGet]
        [Route("/work")]
        public IActionResult Work()
        {
            string Myessage = "";
            int? dojiEner = HttpContext.Session.GetInt32("DojidachiEnergy");
            int? dojiFood = HttpContext.Session.GetInt32("DojidachiMeals");

            if(dojiEner <= 0)
            {
                System.Console.WriteLine($"Dojidachi not enough energy to work. Energy is {dojiEner}");
                Myessage = ($"Dojidachi not enough energy to work. Energy is {dojiEner}");
                HttpContext.Session.SetString("DojidachiMessage", Myessage);
            }
            else
            {
                dojiEner -= 5;
                HttpContext.Session.SetInt32("DojidachiEnergy", (int)dojiEner);
                dojiFood = dojiFood + rand.Next(1, 4);
                
                System.Console.WriteLine($"Dojidachi worked, meals is now {dojiFood}");
                HttpContext.Session.SetInt32("DojidachiMeals", (int)dojiFood);
                Myessage = ($"Dojidachi worked, meals is now {dojiFood}");
                HttpContext.Session.SetString("DojidachiMessage", Myessage);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/sleep")]
        public IActionResult Sleep()
        {
            string Myessage = "";
            System.Console.WriteLine("Dojidachi is sleeping now...");
            int? dojiEner = HttpContext.Session.GetInt32("DojidachiEnergy");
            int? dojiFull = HttpContext.Session.GetInt32("DojidachiFullness");
            int? dojiHapp = HttpContext.Session.GetInt32("DojidachiHappiness");

            dojiEner += 15;
            dojiFull -= 5;
            dojiHapp -= 5;

            HttpContext.Session.SetInt32("DojidachiEnergy", (int)dojiEner);
            HttpContext.Session.SetInt32("DojidachiFullness", (int)dojiFull);
            HttpContext.Session.SetInt32("DojidachiHappiness", (int)dojiHapp);
            System.Console.WriteLine($"Dojis entergy {dojiEner} | dojis fullness {dojiFull} | dojis happines {dojiHapp}");

            Myessage = ($"Dojis entergy {dojiEner} | dojis fullness {dojiFull} | dojis happines {dojiHapp}");
            HttpContext.Session.SetString("DojidachiMessage", Myessage);

            return RedirectToAction("Index");
        }//end sleep

        //------------------TEST---------------------------
        private int Chance()
        {
            int chance = rand.Next(1, 101);
            return chance;
        }




    }//end controller
}