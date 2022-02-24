# api-code-screen

This assessment is intended to demonstrate a developer's ability to interact with a RESTful API.

A successful solution will be able to demonstrate the following capabilities: 
* GET data from a REST endpoint
* manipulate JSON data
* POST a specified payload to a REST endpoint

There are three publicly accessible REST endpoints outlined below. The "/manufacturers" endpoint will return JSON data. The developer will need to extract information from this JSON response and POST the appropriate payloads to the "/names" and "/colors" endpoints. 

An example .NET Core 3.1 solution is included in this repository and can be used as a starting point. **This assessment is language and framework agnostic and it is not required to use the provided example solution**.


## API

#### Manufacturers
**GET** [https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/manufacturers](https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/manufacturers)

**Returns**:

StatusCode: 200

Payload: a JSON object of cars offered by different manufactureres
``` json 
{
  "manufacturers": [
    {
      "name": "Chevy",
      "cars": [
        {
          "name": "Corvette",
          "colors": [
            "black",
            "midnight blue",
            "silver",
            "inferno red",
            "atomic orange"
          ]
        }
      ]
    }
  ]
}
```

</br>
#### Names
**POST** [https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/names](https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/names)

The expected payload is a JSON object containing a list of unique car names offered by Ford, sorted in alphabetical order

``` json
{ 
	"names": [...] 
}
```

**Returns:**

StatusCode: 200 - Correct Answer

StatusCode: 400 - Incorrect Answer

</br>
#### Colors
**POST** [https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/colors](https://k7o2mgxtv8.execute-api.us-east-1.amazonaws.com/public/colors) 

The expected payload is a JSON object containing a list of unique car colors offered by Chevy, sorted in alphabetical order

``` json
{ 
	"colors": [...] 
}
```

**Returns:**

StatusCode: 200 - Correct Answer

StatusCode: 400 - Incorrect Answer