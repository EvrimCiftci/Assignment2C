using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Evrim_Assignment2
{
    public class servicee
    {
        private readonly string jsonFilePath;

        public servicee(string filePath)
        {
            jsonFilePath = filePath; // Constructor: Initialize the path to the JSON file
        }

        public List<WebsiteModel> GetYourModels()
        {
            // Read the JSON data from the file
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON data into a List of WebsiteModel objects
            List<WebsiteModel> yourModels = JsonSerializer.Deserialize<List<WebsiteModel>>(jsonData);

            // Return the List of WebsiteModel objects
            return yourModels;
        }
    }
}
