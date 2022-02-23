
var dataSourceUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/manufacturers";
var carNamesPostUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/names";
var carColorsPostUrl = "https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/colors";
var httpClient = new HttpClient();

// TODO: use httpClient to GET Manufacturer data from the dataSourceUrl

// TODO: use httpClient to POST a list of unique car names offered by Ford, sorted in alphabetical order, to the carNamesPostUrl
// the POST body should be a JSON object { "names": [...] }

// TODO: use httpClient to POST a list of unique unique car colors offered by Chevy, sorted in alphabetical order, to the carColorsPostUrl
// the POST body should be a JSON object { "colors": [...] }

class Root
{
    public List<Manufacturer> Manufacturers { get; set; } = null!;
}

class Manufacturer
{
    public string Name { get; set; } = null!;
    public List<Car> Cars { get; set; } = new();
}

class Car
{
    public string Name { get; set; } = null!;
    public List<string> Colors { get; set; } = new();
}
