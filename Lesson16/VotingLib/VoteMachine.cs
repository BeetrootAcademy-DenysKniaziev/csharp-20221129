
using System;

namespace VotingLib;

public class VoteMachine
{
    public static string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
    public static string filePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName).FullName).FullName;
    public static int LastVotingId { get; set; }
    public static int LastPersonId { get; set; }
    public static List<Voting> Votings = new List<Voting>();
    public static List<Person> Persons = new List<Person>();


    public static void AddVoting(string fileName)
    {
        LastVotingId++;
        Voting tempVote = new Voting(LastVotingId);
        if (fileName !="")
        {
            tempVote.FileName = fileName;
            tempVote.LoadFromFile();
        }
        else tempVote.CreateNewVoting();
        Votings.Add(tempVote);
    }
    public static void LoadPersones()
    {
        string[] data = File.ReadAllLines(filePath + "/Homework16/Persons.txt");
        int maxId = 0;
        Person tempPerson;
        foreach (var d in data)
        {
            var splited = d.Split('|');
            if (int.TryParse(splited[0], out int id))
            {
                if (id > maxId) maxId = id;
                tempPerson = new Person(id);
                tempPerson.Name = splited[1];
                try
                {
                    int.TryParse(splited[2], out int age);
                    tempPerson.Age = age;
                }
                catch { }
                if (splited[3] == "1") tempPerson.Gender = 1;
                else if (splited[3] == "0") tempPerson.Gender = 0;
                Persons.Add(tempPerson);
            }

        }
        LastPersonId = maxId;
    }
    public static Person AddPerson()
    {
        Person tempPerson = new Person(LastPersonId++);
        //LastPersonId++;
        tempPerson.CreateNewPerson();
        string[] s = new string[] { $"{tempPerson.Id}|{tempPerson.Name}|{tempPerson.Age}|{tempPerson.Gender}" };
        File.AppendAllLines(filePath + "/Homework16/Persons.txt", s);
        return tempPerson;
    }

    public static void LoadVotingsList()
    {
        string[] data = File.ReadAllLines(filePath + "/Homework16/Votings_List.txt");
        if (data != null && data.Length > 0)
        {
            foreach (string s in data)
            {
                AddVoting(s);
               // Console.WriteLine(s);
            }
        }
    }
}