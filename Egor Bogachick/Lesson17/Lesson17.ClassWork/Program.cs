namespace Lesson17.ClassWork
{
    class AccountEventArgs
    {
        public string Message { get; }

        public int Sum { get; }
        public AccountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }

    class Account
    {
        public delegate void AccountHandler(Account sender, AccountEventArgs e);
        public event AccountHandler? Notify;

        public int Sum { get; private set; }

        public Account(int sum) => Sum = sum;

        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke(this, new AccountEventArgs($"Deposit {sum}", sum));
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke(this, new AccountEventArgs($"Withdrawal {sum}", sum));
            }
            else
            {
                Notify?.Invoke(this, new AccountEventArgs("Not enough money", sum));
            }
        }
    }

    class Program
    {
        delegate void PrintMethod(string text);
        delegate int Calculate(int a, int b);

        delegate TReturn MethodCo<out TReturn, TParam>(TParam param);
        delegate TReturn MethodContr<TReturn, in TParam>(TParam param);

        static PrintMethod _eventPrintMethod;
        static event PrintMethod EventPrintMethod
        {
            add { _eventPrintMethod += value; }
            remove { _eventPrintMethod -= value; }
        }

        class Message
        {
            public string Text { get; set; }

            public Message(string text)
            {
                Text = text;
            }
        }

        class EmailMessage : Message
        {
            public string EmailAdress { get; set; }

            public EmailMessage() : base("NO MESSAGE")
            {
            }

            public EmailMessage(string text) : base(text)
            {
            }
        }

        class PhoneMessage : Message
        {
            public string PhoneNumber { get; set; }

            public PhoneMessage() : base("NO MESSAGE")
            {
            }

            public PhoneMessage(string text) : base(text)
            {
            }
        }

        static void Main()
        {
            PrintMethod pm1 = PrintConsole;
            pm1("Hello!");

            pm1 = null;
            pm1?.Invoke("Hello Invoke!");

            Calculate c1;

            c1 = Sum;
            var sum = c1(2, 4);

            c1 = (x, y) => x - y;
            var sub = c1(2, 4);

            c1 = delegate (int x, int y)
            {
                return x * y;
            };

            var mul = c1(2, 4);

            Console.WriteLine(sum);
            Console.WriteLine(sub);
            Console.WriteLine(mul);

            Action<string> a1 = PrintConsole;
            a1 += (string text) => Console.WriteLine(text.Reverse().ToArray());
            a1 += (string text) => Console.WriteLine(text.Substring(0, 3));

            //a1 -= PrintConsole;

            a1.Invoke("Hello!");

            MethodCo<Message, string> method1 = s => new Message(s);
            MethodCo<EmailMessage, string> method2 = GetEmailMessage;

            method1 += GetEmailMessage;
            method1 += s => new PhoneMessage(s);

            method1 = method2;

            MethodContr<string, EmailMessage> method3 = em => em.Text;
            MethodContr<string, Message> method4 = em => em.Text;

            method3 = method4;

            EventPrintMethod += PrintConsole;
            EventPrintMethod += PrintConsole;
            EventPrintMethod -= PrintConsole;

            _eventPrintMethod?.Invoke("Event!");

            var ac1 = new Account(1000);
            ac1.Notify += (s, args) => Console.WriteLine(args.Message + " total: " + s.Sum);

            ac1.Put(100);
        }

        static EmailMessage GetEmailMessage(string text)
        {
            return new EmailMessage(text);
        }

        static int Sum(int a, int b) => a + b;

        static void PrintConsole(string text)
        {
            Console.WriteLine(text);
        }
    }
}