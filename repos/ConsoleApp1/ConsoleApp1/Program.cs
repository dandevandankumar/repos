using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace JsonReadingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the path to your JSON file
            string filePath = "data.json";

            // Read the JSON file
            string jsonText = File.ReadAllText(filePath);

            // Deserialize JSON data into a list of objects
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonText);

            // Display the data
            foreach (Person person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
