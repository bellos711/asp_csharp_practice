using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using viewmodel_fun.Models;

namespace viewmodel_fun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string myMessage = "Bacon ipsum dolor amet burgdoggen swine turducken, rump buffalo pork jerky meatball filet mignon beef ribs pig bacon capicola ribeye. Pork chuck kevin, burgdoggen shoulder fatback alcatra brisket ham sirloin rump filet mignon andouille. Corned beef filet mignon cow, doner rump beef ribs drumstick. Bresaola andouille chicken frankfurter. Fatback cow boudin pork loin shank, leberkas venison. Shankle tongue drumstick, hamburger chicken porchetta shoulder doner fatback tenderloin beef.";
            return View("Index", myMessage);
        }//end index

        [HttpGet]
        [Route("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[]
            {
                1,2,3,10,43,5
            };
            return View("Numbers", numbers);
        }//end Numbers

        [HttpGet]
        [Route("singleuser")]
        public IActionResult SingleUser()
        {
            User singleUser = new User()
            {
                fName = "EggDog",
                lName = "Boba"
            };//end singleUser instatiation
            return View("SingleUser", singleUser);
        }//end singleuser

        [HttpGet]
        [Route("multipleusers")]
        public IActionResult MultipleUsers()
        {
            List<User> multiUsers = new List<User>()
            {
                new User(){fName = "John", lName = "Johnson"},
                new User(){fName = "Joseph", lName = ""},
                new User(){fName = "Baba", lName = "Booey"},
                new User(){fName = "Holmes", lName = "Dude"},
                new User(){fName = "Bob", lName = "Bobson"}
            };
            return View("MultipleUsers", multiUsers);
        }//end MulitpleUsers

    }//end Homecontroller
}//end namespace