using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using random_passcode.Models;


namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string PasscodeFromSession =  HttpContext.Session.GetString("StringPass");
            int? CounterFromSession = HttpContext.Session.GetInt32("PassCounter");

            if(PasscodeFromSession==null )
            {
                
                HttpContext.Session.SetInt32("PassCounter", 0);
                int? Counter = HttpContext.Session.GetInt32("PassCounter");
                System.Console.WriteLine($"First setup counter {Counter}");
                return RedirectToAction("GenerateCodeInSession");
                
            }
            else
            {
                WrapperModel WMod = new WrapperModel()
                {
                    MyPassCode = PasscodeFromSession,
                    MyCounter = (int)CounterFromSession
                };
                return View("Index", WMod);
            }
            
        }//end index

        [HttpGet]
        [Route("generate")]
        public IActionResult GenerateCodeInSession()
        {
            int? counter = HttpContext.Session.GetInt32("PassCounter");
            counter++;
            HttpContext.Session.SetInt32("PassCounter", (int)counter);
            System.Console.WriteLine($"This is the counter {counter}");
            
            string myRandomPass = GenerateRandomString(14);
            HttpContext.Session.SetString("StringPass", myRandomPass);

            return RedirectToAction("Index");
        }
        

        public int GetRandomNumber(int maxNumber)
        {
            // if(maxNumber < 1)
            //     throw new System.Exception("The maxNumber value should be greater than 1");
            // byte[] b = new byte[4];
            // new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            // int seed = (b[0] & 0x7f) << 24 | b[1] << 16 | b[2] << 8 | b[3];
            System.Random r = new System.Random();
            return r.Next(1, maxNumber);
        }

        public string GenerateRandomString(int passLength)
        {
            string[] charsArray = new string[31]
            {
                "0","2","3","4","5","6","8","9","A","B","C","D","E","F","G","H","J","K","L","M","N","P","R","S","T","U","V","W","X","Y","Z"
            };
            System.Text.StringBuilder sBuild = new System.Text.StringBuilder();
            for(int i = 0; i < passLength; i++)
            {
                sBuild.Append(charsArray[GetRandomNumber(30)]);
            }

            return sBuild.ToString();
        }
    }//end homecontroller
}//end namesapce