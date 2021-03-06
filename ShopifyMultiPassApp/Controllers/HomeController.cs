﻿using Newtonsoft.Json;
using ShopifyMultiPassApp.Helpers;
using ShopifyMultiPassApp.Models;
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
        public ActionResult Signin(Customer model)
        {
            if (ModelState.IsValid)
            {
                var url = Request.UrlReferrer?.AbsoluteUri ?? "";
                var input = new Customer()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
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