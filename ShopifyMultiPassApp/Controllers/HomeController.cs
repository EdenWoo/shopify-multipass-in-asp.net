using Newtonsoft.Json;
using ShopifyMultiPassApp.Models;
using ShopifyMultipassTokenGenerator;
using ShopifyMultipassTokenGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopifyMultiPassApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(Signin model)
        {
            if (ModelState.IsValid)
            {
                var url = Request.UrlReferrer?.AbsoluteUri ?? "";
                var input = new Customer()
                {
                    Email = model.Email
                };

                //var secret = ConfigurationManager.AppSettings["shopifyMultipassSecret"];
                //var domain = ConfigurationManager.AppSettings["shopifyMultipassDomain"];
                var secret = "f8e3bcd88222497b2fd4b3bcc7383674";
                var domain = "multipass-test.myshopify.com";
                var customerJSONString = JsonConvert.SerializeObject(input);
                ShopifyMultipass shopifyMultipass = new ShopifyMultipass(secret, domain);
                url = shopifyMultipass.Process(customerJSONString);

                return Redirect(url);
            }
            else
            {
                return Content("Error");
            }
        }
    }

}