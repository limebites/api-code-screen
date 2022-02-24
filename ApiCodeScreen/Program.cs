using System.Collections.Generic;
using System.Net.Http;

namespace ApiCodeScreen
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSourceUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/manufacturers";
            var carNamesPostUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/names";
            var carColorsPostUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/colors";
            var httpClient = new HttpClient();

            /**
             * TODO
             */
        }
    }

    class Root
    {
        public List<Manufacturer> Manufacturers { get; set; } = null!;
    }

    class Manufacturer
    {
        public string Name { get; set; } = null!;
        public List<Car> Cars { get; set; } = new List<Car>();
    }

    class Car
    {
        public string Name { get; set; } = null!;
        public List<string> Colors { get; set; } = new List<string>();
    }
}