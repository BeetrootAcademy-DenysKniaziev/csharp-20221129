﻿class Program
{
    static void KillOrDeath()
    {
        Console.WriteLine("\n Що далі?\n 1- Вбити \n 2- Не вбивати");
        int killСhoice = int.Parse(Console.ReadLine());
        switch (killСhoice)
        {
            case 1:
                Console.WriteLine("\nБІЙ ЗАВЕРШЕНО\n");
                Console.WriteLine(" *Ціною великих утрат ви всеж таки змогли взяти Данію*");
                Console.WriteLine(" *Повернувшись до рідних країв ви добре правили протягом 7 років, але були вбиті сином Бйорна який помстився за батька і посів ваше місце*");
                break;
            case 2:
                Console.WriteLine("\nБІЙ ЗАВЕРШЕНО\n");
                Console.WriteLine(" *У ході великих битв вам поранило око, але під вашим коандуванням та за допомогою Бйорна ви захопили усю Данію і настала добра пора для вікінгів*");
                break;
            default:
                Console.WriteLine("*Ви довго вагалися, Бйорн швитко збив вас з ніг та завершив ваше життя вишою ж зброєю*");
                Console.WriteLine("\nБІЙ ЗАВЕРШЕНО\n");
                Console.WriteLine(" *Що ж хто зна що було потім для вас це вже не важливо*");
                break;
        }
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine(" Невідомий голос: Вставай народе! Вликий похід на Данію уже завтра!\n");
        Console.WriteLine(" *Ви виходите з палатки і приєднуєтесь до інших у натовп*\n");
        Console.WriteLine(" Невідомий голос: Вже завтра день який усі ми чекали! Усю зиму ми готувалися!\n І цей день прийшов! Завтра вікинги заберуть СВОЄ!\n");
        Console.WriteLine(" *Крик натовпу не можна було б заглушити тисяу канонад*\n");
        Console.WriteLine(" Невідомий голос: Привітайте нашого вождя БЙОООРНАА!\n");
        Console.WriteLine(" *З головної палаьки вийшов кримезний чоловік побачивши його натовп закричав уще гучніш*\n");
        Console.WriteLine(" Бйорн: Що ж добрий люде вже завтра ми усі разом підемо у похід,\n АЛЕ ми усі знаємо правила предків є обряд при якому кожний може кинути виклик мені БЙОРНУ ЛЮТОМУ");
        Console.WriteLine(" Бйорн: НУ ЩО ЧИ знайдеться СМІЛИВЄЦЬ?");

        Console.Write("\n 1- Я БДУ БИТИСЬ \n 2- Промовчати\n");
        int lifeСhoice = int.Parse(Console.ReadLine());
        if (lifeСhoice == 1)
        {
            Console.WriteLine("\n Бйорн: хо-хо добре воїне виходь та вибирай зброю\n");

            Console.WriteLine(" 1- Сокира \n 2- Меч \n 3- Кинжали");
            int weaponСhoice = int.Parse(Console.ReadLine());
            if (weaponСhoice == 1)
            {
                Console.WriteLine(" *Почався двобій.\n Це був гідний поєдинок 2 сильних бійців*");
                Console.WriteLine(" *Ви вибили зброю з рук Бйорна і збили з ніг.*");
                KillOrDeath();

            }
            else if (weaponСhoice == 2)
            {
                Console.WriteLine(" *Почався двобій.\n Це була запекла битва. Дуже довго не можна було зрозуміти хто лідує.*");
                Console.WriteLine(" *Важко дихая ви вибили зброю з рук Бйорна і збили з ніг.*");
                KillOrDeath();
            }
            else if (weaponСhoice == 3)
            {
                Console.WriteLine(" *Почався двобій.\n Було видно що лідує Бйорн, але в кінці ви ви зробили неперевершений швидкий пірует збивши с пантелику супротивника");
                Console.WriteLine(" *Весь у синцях та ранах ви вибили зброю з рук Бйорна і збили з ніг хоча самі майже тримаєтесь.*");
                KillOrDeath();
            }
            else
            {
                Console.WriteLine(" *Ви нічого не вибрали*");
                Console.WriteLine("\n Бйорн: ХО-ХО що я баачу хтось думає що може мене перебороти голими руками?!\n");
                Console.WriteLine(" *Що ж десь може це і спрацювало і ви б убили Бйорна, але не цього разу,\n десь через 10 хвилин бою Бйорн всеж таки перерубих вас своєю сокирою,\n Ви добре тримались.*");
                Console.WriteLine(" *У ході великих битв вам поранило око, але під вашим коандуванням та за допомогою Бйорна ви захопили усю Данію і настала добра пора для вікінгів*");
            }
        }
        else if (lifeСhoice == 2)
        {
            Console.WriteLine(" *Ви мовчки зариваєтесь у натов*");
            Console.WriteLine(" *Вікінги змогли захопити половину Данії.\n Бйорн залишив свого сина на нових землях, а сам повернувся з дарунками у рідний край.*");
            Console.WriteLine(" *Ви померли в одній із битв від якоїсь ворожої сокири*");
        }
        else
        {
            Console.WriteLine(" *Ви сказали щось нерозбірливе* \n *Усі подивилися на вас* \n *Через кілька хвилин мовчання про вас подумали що ви не в собі і принесли в жертву богам* *");
            Console.WriteLine(" *Що ж ваша смерть привнесла щось до перемоги над Данією... напевно....*");
        }
    }
}