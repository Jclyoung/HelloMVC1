using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC1.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/


        // One way to return a parameter in the index displayed /Hello?name= (if blank returns world else returns name given)
        [HttpGet]
        public IActionResult Index()
        {
            //This is a quick way to get a temporary form and should not be used normally this method will allow
            //you to route to the display instead of calling a direct acction for it (See Display for routing info)
            string html = "<form method = 'post'>" +
                "<input type='text' name= 'name' />" +
                "<input type='submit' value= 'Greet me!'" +
                "</form>";

            return Content(html, "text/html");
        }



        //public IActionResult Index()
        //{
        //    This is a quick way to get a temporary form and should not be used normally
        //    string html = "<form method = 'post' action = 'Hello/Display'>" +
        //        "<input type='text' name= 'name' />" +
        //        "<input type='submit' value= 'Greet me!'" +
        //        "</form>";

        //    return Content(html, "text/html");
        //}

        // Or you can use

        //public IActionResult Index(string name)
        //{
        //    if(string.IsNullOrEmpty(name))
        //        name = "world";
        //    return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html"));
        //}
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name = "World")
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        // Handle requests to /Hello/NAME (URL segment) ie. /Hello/Jennifer should return Hello Jennifer
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");

        }

        // Orignal Index
        //public IActionResult Index()
        //{
        //    return Content("<h1>Hello World</h1>", "text/html");
        //}


        // This changes the route and makes /Hello/Goodbye no longer accessible
        [Route("Hello/Aloha")]
        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }

        public IActionResult bubye()
        {
            //This is a quick way to get a temporary form and should not be used normally this method will allow
            //you to route to the display instead of calling a direct acction for it (See Display for routing info)


            return Redirect("/Hello/Goodbye");
        }

        // public IActionResult Goodbye()
        // {
        // 	return Content ("Goodbye");
        // }
    }
}