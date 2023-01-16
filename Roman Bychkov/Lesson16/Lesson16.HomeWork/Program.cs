class Program
{
    static void Main()
    {

        HashSet<Voting> votings = new HashSet<Voting>();
        while (true)
        {
            Console.WriteLine("1 - Create a voting.");
            Console.WriteLine("2 - Add options to the voting.");
            Console.WriteLine("3 - Make vote.");
            Console.WriteLine("4 - Show all votings.");
            Console.WriteLine("0 - Exit.");
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1:
                    CreateVoting(votings);
                    break;
                case ConsoleKey.D2:
                    AddOptions(votings);
                    break;
                case ConsoleKey.D3:
                    MakeVote(votings);
                    break;
                case ConsoleKey.D4:
                    ShowVotings(votings);
                    break;
                case ConsoleKey.D0:
                    return;
            }
            Console.WriteLine();
        }
    }

    private static void MakeVote(HashSet<Voting> votings)
    {
        string name = ValidationName("voting");
        DateTime date = DateValidation();
        var ob = votings.FirstOrDefault(x => x.Name == name && x.DateOfCreate == date);
        if (ob == null)
        {
            Console.WriteLine("This voting not exist.");
            return;
        }

        int numberOf = 1;
        Dictionary<int, Option> options = new Dictionary<int, Option>();
        foreach (var include in ob)
        {
            options[numberOf] = include.Key;
            numberOf++;
        }

        while (true)
        {
            foreach (var option in options)
                Console.WriteLine("\t" + option.Key + " — " + option.Value);


            Console.WriteLine();

            if (!int.TryParse(Console.ReadLine(), out numberOf) && !options.ContainsKey(numberOf))
            {
                Console.WriteLine("Invalid numberof.");
                continue;
            }
            ob.MakeVote(options[numberOf]);
            return;
        }

    }

    private static void AddOptions(HashSet<Voting> votings)
    {
        string name = ValidationName("voting");
        DateTime dateTime = DateValidation();
        var ob = votings.FirstOrDefault(x => x.Name == name && x.DateOfCreate == dateTime);
        if (ob == null)
        {
            Console.WriteLine("This voting not exist.");
            return;
        }
        while (true)
        {
            Console.WriteLine("1 - Add option.");
            Console.WriteLine("0 - Exit.");
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1:
                    ob.AddOption(ValidationName("option"));
                    break;
                case ConsoleKey.D0:
                    return;
            }

        }
    }

    private static DateTime DateValidation()
    {
        while (true)
        {
            Console.WriteLine("Input date of creating voting DD-MM-YYYY (press enter to pick today): ");
            var result = Console.ReadLine();
            if (result == "")
            {
                return DateTime.Today;
            }
            if (!DateTime.TryParse(result, out DateTime date) || date == DateTime.MinValue)
            {
                Console.WriteLine("Invalid Date");
                continue;
            }
            return date;
        }
    }

    private static void CreateVoting(HashSet<Voting> votings)
    {
        var vote = new Voting(ValidationName("voting"), null);
        if (votings.Contains(vote))
        {
            Console.WriteLine("This voting already exist.");
            return;
        }
        votings.Add(vote);
    }

    private static void ShowVotings(HashSet<Voting> votings)
    {
        foreach (var item in votings)
        {
            Console.WriteLine($"{item.Name} Date: {item.DateOfCreate:d}");
            foreach (var include in item)
                Console.WriteLine("\t" + include);
        }
    }
    public static string ValidationName(string option)
    {
        while (true)
        {
            Console.WriteLine($"Input name of {option}: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid Name");
                continue;
            }
            return name;
        }
    }
}