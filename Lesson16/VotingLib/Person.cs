using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace VotingLib;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Gender { get; set; }
    public Person(int id)
    {
        Id = id;
    }
    public void CreateNewPerson()
    {
        while (true)
        {
            WriteLine("\nPlease enter Name (3-19 symbols)");
            string input = Console.ReadLine();  
            if(input.Length >= 3 && input.Length < 20) {this.Name = input; break;}
            else { WriteLine("Wrong input, try again\nPlease enter Name (3-19 symbols"); }

        }
        WriteLine("Please enter your Age");
        while (true) 
        {
            if (int.TryParse(ReadLine(), out int age)) { this.Age = age; break; }
            else { WriteLine("Wrong input, try again\nPlease enter your Age"); }
        }
        WriteLine("Please enter your gender: (M)ale of (F)male");
        while (true)
        {
            var key = Console.ReadKey();
            if (key.Key ==  ConsoleKey.M) { this.Gender = 1;  break; }
            else if (key.Key ==  ConsoleKey.F) { this.Gender = 0; break; }
            else { WriteLine("Wrong input, of gender try again\nPlease enter your Gender: (M)ale of (F)male"); }
        }
    }

    
}
