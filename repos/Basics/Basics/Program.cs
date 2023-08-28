using System;
using System.Collections.Generic;
using System.Linq;

// Parent class: Employee
class Employee
{
    // Properties
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Constructor
    public Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Methods
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {FirstName} {LastName}");
    }
}

// Child class: EmployeeAddress
class EmployeeAddress : Employee
{
    // Properties
    public string Address { get; set; }

    // Constructor
    public EmployeeAddress(string firstName, string lastName, string address)
        : base(firstName, lastName)
    {
        Address = address;
    }

    // Additional Method
    public void DisplayAddress()
    {
        Console.WriteLine($"Address: {Address}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an EmployeeAddress object
        EmployeeAddress emp = new EmployeeAddress("vandan", "kumar", "123 Main St");

        // Calling methods
        emp.DisplayInfo(); // Calls DisplayInfo from parent class
        emp.DisplayAddress(); // Calls DisplayAddress from child class

        // Using LINQ
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0);

        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
