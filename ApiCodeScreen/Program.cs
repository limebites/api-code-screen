using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace ApiCodeScreen
{
    class Program
    {
        private static Uri ManufacturesUri;
        private static Uri NamesUri;
        private static Uri ColorsUri;

        static void Main(string[] args)
        {
            var baseUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/";
            //var dataSourceUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/manufacturers";
            //var carNamesPostUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/names";
            //var carColorsPostUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/colors";
            NamesUri = new Uri(baseUrl + "names");
            ManufacturesUri = new Uri(baseUrl + "manufacturers");
            ColorsUri = new Uri(baseUrl + "colors");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var manufacures = GetManufactureres(httpClient).Result;
            var uniqueCarNames = GetUniqueCarNames(manufacures, ManufacturerEnum.Ford);
            var names = GetNames(httpClient, uniqueCarNames).Result;
            var uniqueColors = GetUniqueColors(manufacures, ManufacturerEnum.Chevy);
            var colors = GetColors(httpClient, uniqueColors).Result;
        }

        public static async Task<List<Manufacturer>> GetManufactureres(HttpClient httpClient)
        {
            try
            {
                var httpResponse = await httpClient.GetAsync(ManufacturesUri);
                var httpStatus = (int)httpResponse.StatusCode;
                var resultString = await httpResponse.Content.ReadAsStringAsync();

                if (httpStatus == 200)
                {
                    var root = JsonSerializer.Deserialize<Root>(resultString);
                    return root.Manufacturers;
                }
                else
                {
                    throw new Exception(resultString);
                }
            } catch
            {
                throw;
            }
        }

        public static List<string> GetUniqueCarNames(List<Manufacturer> manufacturers, 
                                                     ManufacturerEnum filterManufacturer)
        {
            var result = manufacturers.Where(i => i.Name == filterManufacturer.ToString())
                                      .SelectMany(i => i.Cars)
                                      .Select(o => o.Name)
                                      .Distinct()
                                      .OrderBy(i => i)
                                      .ToList();
            return result;
        }

        public static List<string> GetUniqueColors(List<Manufacturer> manufacturers,
                                                   ManufacturerEnum filterManufacturer)
        {
            var result = manufacturers.Where(i => i.Name == filterManufacturer.ToString())
                                      .SelectMany(i => i.Cars)
                                      .SelectMany(o => o.Colors)
                                      .Distinct()
                                      .OrderBy(i => i)
                                      .ToList();
            return result;
        }

        public static async Task<bool> GetNames(HttpClient httpClient, List<string> uniqueCarNames)
        {
            try
            {
                var rootOutbound = new RootNames() { Names = uniqueCarNames };
                var jsonString = JsonSerializer.Serialize(rootOutbound);
                var data = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(NamesUri.ToString(), data);
                var httpStatus = (int)httpResponse.StatusCode;
                var resultString = await httpResponse.Content.ReadAsStringAsync();

                if (httpStatus == 200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public static async Task<bool> GetColors(HttpClient httpClient, List<string> uniqueColors)
        {
            try
            {
                var rootOutbound = new RootColors() { Colors = uniqueColors };
                var jsonString = JsonSerializer.Serialize(rootOutbound);
                var data = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(ColorsUri.ToString(), data);
                var httpStatus = (int)httpResponse.StatusCode;
                var resultString = await httpResponse.Content.ReadAsStringAsync();

                if (httpStatus == 200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }

    public enum ManufacturerEnum
    {
        Ford,
        Chevy,
        Telsa
    }

    class Root
    {
        [JsonPropertyName("manufacturers")]
        public List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
    }

    class Manufacturer
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("cars")]
        public List<Car> Cars { get; set; } = new List<Car>();
    }

    class Car
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("colors")]
        public List<string> Colors { get; set; } = new List<string>();
    }

    class RootNames
    {
        [JsonPropertyName("names")]
        public List<string> Names { get; set; } = new List<string>();
    }

    class RootColors
    {
        [JsonPropertyName("colors")]
        public List<string> Colors { get; set; } = new List<string>();
    }
}