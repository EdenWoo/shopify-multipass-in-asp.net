using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShopifyMultiPassApp.Models
{
    /// <summary>
    /// Base class that holds customer data. If you want to include more details about the customer, create a new class and inherit this class.
    /// </summary>
    public class Customer
    {
        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }

        //2013-04-11T15:16:23-04:00
        [JsonProperty(propertyName: "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(propertyName: "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(propertyName: "last_name")]
        public string LastName { get; set; }

        //tag_string: "canadian, premium",
        [JsonProperty(propertyName: "tag_string")]
        public string TagString { get; set; }

        //identifier: "bob123",
        //remote_ip: "107.20.160.121",
        //return_to: "http://yourstore.com/some_specific_site",

        //addresses: [{
        //address1: "123 Oak St",
        //city: "Ottawa",
        //country: "Canada",
        //first_name: "Bob",
        //last_name: "Bobsen",
        //phone: "555-1212",
        //province: "Ontario",
        //zip: "123 ABC",
        //province_code: "ON",
        //country_code: "CA",
        //default: true
        //}]

        public Customer()
        {
            this.CreatedAt = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
        }
    }
}
