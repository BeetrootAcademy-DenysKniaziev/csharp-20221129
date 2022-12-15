
Console.OutputEncoding = System.Text.Encoding.Unicode;
int success = 0;
Console.WriteLine("Предісторія:\n" +
    "Ви, спецагент операції \"CringeProject\", якому потрібно потратипити на військову засекречену территорію через КПП.\n" +
    "Вибирайте гілки розвитку події та слідкуйте за своїм \"Успіхом\"\t");
bool skip = true, accessToOption=false;
int agentClass=0;
while(skip)
{
    Console.WriteLine("Підготуйте маскування. Виберіть запропованований варіант:");
    Console.WriteLine("1. Костюм звичайного громадянина");
    Console.WriteLine("2. Костюм службовця силових структур + посвідчення");
    Console.WriteLine("3. Костюм електрика + сумка з інструментами\n");

    switch (Console.ReadLine())
    {
        case "1":
            success += 5;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            agentClass = 0;
            skip = false;
            break;
        case "2":
            success += 25;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            agentClass= 2;
            skip = false;
            break;
        case "3":
            success += 10;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            agentClass = 1;
            skip = false;
            break;
        default:
            Console.WriteLine("Варіант відсутній.\n");
            break;

    }

}
skip = true;
accessToOption = false;
while (skip)
{
    Console.WriteLine("1. Підійти до КПП");
    Console.WriteLine("2. Відступити\n");
    switch(Console.ReadLine())
    {
        case "1":
            success += 5;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            skip = false;
            break;
        case "2":
            Console.WriteLine("Міссія провалена\n");
            return;
        default:
            Console.WriteLine("Варіант відсутній.\n");
            break;

    }
}
skip = true;
accessToOption = false;
while (skip)
{

    Console.WriteLine("1. Привітатися звичайно");
    if (agentClass == 2)
    {
        Console.WriteLine("2. Віддати честь та показати посвідчення");
        accessToOption = true;
    }
    Console.WriteLine("3. Протягнути руку, ніби охоронець ваш старий знайомий");
    Console.WriteLine("4. Атакувати охоронця\n");
    switch (Console.ReadLine())
    {
        case "1":
            success += 5;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            skip = false;
            break;
        case "2" when accessToOption == true:
            success += 25;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            skip = false;
            break;
        case "3":
            success += 35;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            skip = false;
            break;
        case "4":
            while (skip)
            {
                Console.WriteLine("\n1. Удар з підтібка по печінці");
                Console.WriteLine("2. Удар у щелепу");
                Console.WriteLine("3. Ліквідація\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        success = success + 50 > 100 ? 100 : success + 50;
                        Console.WriteLine($"Шанс успіху: {success}%\n");
                        skip= false;
                        break;
                    case "2":
                        success = success + 60 > 100 ? 100 : success + 70;
                        Console.WriteLine($"Шанс успіху: {success}%\n");
                        skip=false;
                        break;
                    case "3":
                        success = 100;
                        Console.WriteLine($"Шанс успіху: {success}%\n");
                        skip=false;
                        break;
                    default:
                        Console.WriteLine("Варіант відсутній.\n");
                        break;
                }
            }
            if (success == 100)
                Console.WriteLine("Фаза пройдена. Агент проникнув на територію");
            else
                Console.WriteLine("Охоронець встиг підняти тривогу. Місія провалена");
             return;
        default:
            Console.WriteLine("Варіант відсутній.\n");
            break;
    }
}
skip=true;
accessToOption=false;
while(skip)
{
    Console.WriteLine("1. Ввести в оману охоронця метою візиту");
    if (agentClass == 1)
    {
        Console.WriteLine("2. Спитати: \"Як потрапити в бібліотеку?\" та прикласти хустинку з хлорофілом до обличчя охоронця");
        accessToOption = true;
    }
    Console.WriteLine("3. Спитати як справи на службі");
    Console.WriteLine("4. Почати обговорювати як можна потрапити в середину\n");

    string ans = Console.ReadLine();
    switch (ans)
    {
        case "1":
            success = success + 45 > 100 ? 100 : success + 45;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            skip = false;
            break;
        case "2" when accessToOption == true:
            success = success + 50 > 100 ? 100 : success + 50;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            skip = false;
            break;
        case "3":
            success = success + 1 > 100 ? 100 : success + 1;
            Console.WriteLine($"Шанс успіху: {success}%\n");
            skip = false;
            break;
        case "4":
            Console.WriteLine($"Охоронець запримітив неладне. Місія провалена.");
            return;
        default:
            Console.WriteLine("Варіант відсутній.\n");
            break;
    }

    
}
if (success == 100)
    Console.WriteLine("Фаза пройдена. Агент проникнув на територію");
else
    Console.WriteLine("Агент, варіант проникнення \"Обман\" провалено. Охоронець встиг зреагувати на ваші маніпуляції.\nПотрібно шукати інший шлях.");

