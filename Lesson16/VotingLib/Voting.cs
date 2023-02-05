using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Console;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace VotingLib;

public class Voting
{

    public static string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
    public static string filePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName).FullName).FullName;

    public int Id { get; set; }
    public string VoteTopic { get; set; }
    public string FileName { get; set; }
    public List<(string, int)> VoteOptionsVoices = new List<(string, int)>();
    public Voting(int id)
    {
        Id = id;
    }

    public void CreateNewVoting()
    {
        WriteLine("Please enter Vote Topic");
        this.VoteTopic = ReadLine();
        string text;
        int i = 1;
        while (i < 10)
        {
            WriteLine("Enter an Option (if no need more, press '0' and Enter)");
            text = ReadLine();
            if (text != "0" && text != "")
            {
                this.VoteOptionsVoices.Add((text, 0));
            }
            else break;
            i++;
        }
        this.WrtieToFile();
        File.AppendAllLines(filePath + "/Homework16/" + "Votings_List.txt", new string[] { this.FileName });
    }

    public void WrtieToFile()
    {

        var data = new string[this.VoteOptionsVoices.Count + 1];
        data[0] = this.VoteTopic;
        for (int i = 0; i < this.VoteOptionsVoices.Count; i++)
        {
            var record = this.VoteOptionsVoices[i];
            data[i + 1] = $"{record.Item1}|" +
            $"{record.Item2}";
        }
        if (!File.Exists(this.FileName))
        {
            string s = this.VoteTopic;
            var output = Regex.Replace(s, "[^A-Za-z]+", string.Empty);
            int maxSize = 16;
            if (output.Length < 16) maxSize = output.Length;
            this.FileName = output.Substring(0, maxSize) + "_Voting.txt";
            //WriteLine("New Voting was saved " + (filePath + "/Homework16/" + this.FileName));
        }
        File.WriteAllLines(filePath + "/Homework16/" + this.FileName, data);
    }

    public void ShowVoting(Person p)
    {
        int i = 0;
        WriteLine("\n" + this.VoteTopic);
        foreach (var item in this.VoteOptionsVoices)
        {
            WriteLine(++i + " " + item.Item1);
        }
        while (true)
        {
            WriteLine("Choose your option or '0' if nothing of above");
            var k = ReadKey();
            if (Int32.TryParse(k.KeyChar.ToString(), out int choise) == true && choise-1 < this.VoteOptionsVoices.Count)
            {
                VoteOptionsVoices[choise-1] = (VoteOptionsVoices[choise-1].Item1, VoteOptionsVoices[choise-1].Item2 + 1);
                this.WrtieToFile();
                File.AppendAllLines(filePath + "/Homework16/" + this.FileName + "Votes", new string[] { $"{VoteOptionsVoices[choise-1].Item1}|{p.Id}|{p.Name}|{p.Age}|{p.Gender}" });
                break;
            }
            else if (choise-1 >= this.VoteOptionsVoices.Count)
            {
                WriteLine("We so sorry that there is no optiond suiteble for you. Bay.");
                return;
            }
            else WriteLine("That was wrong option, please try again\n");
        }

    }
    public void ShowResults()
    {
        int i = 0;
        WriteLine("\n" + this.VoteTopic);
        foreach (var item in this.VoteOptionsVoices)
        {
            WriteLine(item.Item1 + " " + item.Item2);
        }
    }

    public void LoadFromFile()
    {
        if (!File.Exists(filePath + "/Homework16/" + this.FileName))
        {
            try
            {
                throw new System.IO.FileNotFoundException("File is gone :(");
            }
            catch (Exception Ex) { WriteLine(Ex.ToString()); }
        }
        else
        {
            try
            {
                var data = File.ReadAllLines(filePath + "/Homework16/" + FileName);
                this.VoteTopic = data[0];
                //int maxId = 0;
                for (int i = 1; i < data.Length; i++)
                {
                    var splited = data[i].Split('|');
                    bool success = Int32.TryParse(splited[1], out int votes);
                    if (success)
                    {
                        VoteOptionsVoices.Add((splited[0], votes));
                    }
                    else
                    {
                        VoteOptionsVoices.Add((splited[0], 0));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

        }
    }

    public void ShowDetaledResults()
    {

        if (!File.Exists(filePath + "/Homework16/" + this.FileName + "Votes"))
        {
            try
            {
                throw new System.IO.FileNotFoundException("File is gone :(");
            }
            catch (Exception Ex) { WriteLine(Ex.ToString()); }
        }
        else
        {
            try
            {
                var data = File.ReadAllLines(filePath + "/Homework16/"+FileName + "Votes");
                //this.VoteTopic = data[0];
                //int maxId = 0;
                WriteLine("\n This is gender and age split for answer to topic '" + this.VoteTopic +"'");
                List<(int, int, int, int, int)> oV = new List<(int, int, int, int, int)>();//.VoteOptionsVoices.Count;
                //int[] Chart = new int[this.VoteOptionsVoices.Count];
                //List<int, int> answerView = new List<int, int>();

                for(int j = 0; j< this.VoteOptionsVoices.Count;j++) 
                {
                    oV.Add(new (0, 0, 0, 0, 0));
                    for (int i = 0; i < data.Length; i++)
                    {
                        var splited = data[i].Split('|');
                        if (splited[0] == this.VoteOptionsVoices[j].Item1)
                        {
                            if (splited[4] == "1") oV[j] = (oV[j].Item1, oV[j].Item2 + 1, oV[j].Item3, oV[j].Item4, oV[j].Item5);
                            else oV[j] = (oV[j].Item1 + 1, oV[j].Item2, oV[j].Item3, oV[j].Item4, oV[j].Item5);

                            if (int.TryParse(splited[3], out int result)) 
                            { 
                                if(result <20) oV[j] = (oV[j].Item1, oV[j].Item2, oV[j].Item3+1, oV[j].Item4, oV[j].Item5);
                                else if (result <60) oV[j] = (oV[j].Item1, oV[j].Item2, oV[j].Item3, oV[j].Item4+1, oV[j].Item5);
                                else oV[j] = (oV[j].Item1, oV[j].Item2, oV[j].Item3, oV[j].Item4, oV[j].Item5+1);
                            }
                        }
                    }
                    WriteLine($"Option '{this.VoteOptionsVoices[j].Item1}' have totaly {oV[j].Item1 + oV[j].Item2} votes\n\nGender split of voters for aswer is\n {100/(oV[j].Item1+oV[j].Item2)*oV[j].Item1}%  women " +
                        $"{100/(oV[j].Item1+oV[j].Item2)*oV[j].Item2}%  men " +
                        $"\n\nAge split is {100 / (oV[j].Item3 + oV[j].Item4 + oV[j].Item5) * oV[j].Item3}% teenagers " +
                        $" { 100 / (oV[j].Item3 + oV[j].Item4 + oV[j].Item5) * oV[j].Item4}% adaults " +
                        $" {100 / (oV[j].Item3 + oV[j].Item4 + oV[j].Item5) * oV[j].Item5}% older people" );
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message + " But it`s not a problem for us ;)");
            }

        }
    }
}
