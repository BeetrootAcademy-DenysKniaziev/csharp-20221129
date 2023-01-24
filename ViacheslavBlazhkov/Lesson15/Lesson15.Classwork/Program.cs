namespace Lesson15.Classwork
{
    internal class Program
    {
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
            public string EmailAddress { get; set; }
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

        interface IMessageSender<in T> where T : Message
        {
            void Send(T message);
        }
        interface IMessageReceiver<out T> where T : Message
        {
            T Receive();
        }
        interface IMessageHandler<out T, in U> where T : Message where U : Message
        {
            void Send(U message);

            T Receive();
        }

        class MessageSender<T> : IMessageSender<T> where T : Message
        {
            public void Send(T message)
            {
                Console.WriteLine(message.Text);
            }
        }
        class MessageReceiver<T> : IMessageReceiver<T> where T : Message, new()
        {
            public T Receive()
            {
                return new T { Text = "ABC" };
            }
        }

        class EmailMessageReceiver : IMessageReceiver<EmailMessage>
        {
            public EmailMessage Receive()
            {
                return new EmailMessage { Text = "ABC" };
            }
        }

        class MessageHandler<T, U> : IMessageHandler<T, U> where T : Message, new() where U : Message
        {
            public T Receive()
            {
                return new T { Text = "ABC" };
            }

            public void Send(U message)
            {
                Console.WriteLine(message.Text);
            }
        }

        static void Swap(ref object a, ref object b)
        {
            (a, b) = (b, a);
        }
        static void SwapGeneric<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        static void Main(string[] args)
        {
            var a = 1;
            var b = 2;

            string s1 = "a";
            string s2 = "b";

            object o1 = a;
            object o2 = b;

            SwapGeneric(ref a, ref b);
            //SwapGeneric(ref s1, ref s2);

            Console.WriteLine(a + " " + b);
            Console.WriteLine(s1 + " " + s2);

            var mr1 = new MessageReceiver<PhoneMessage>();
            var mr2 = new MessageReceiver<EmailMessage>();

            IMessageReceiver<Message> mr3 = mr1;
            IMessageReceiver<Message> mr4 = mr2;

            var m1 = mr3.Receive();
            if(m1 is PhoneMessage pm1)
            {
                pm1.PhoneNumber = "1111";
            }

            var ms1 = new MessageSender<PhoneMessage>();
            var ms2 = new MessageSender<EmailMessage>();
            var ms3 = new MessageSender<Message>();
            ms3.Send(new PhoneMessage());

            IMessageSender<PhoneMessage> ms4 = ms3;
            ms4.Send(new PhoneMessage());

            var mh1 = new MessageHandler<EmailMessage, Message>();
            var mh2 = new MessageHandler<PhoneMessage, Message>();

            IMessageHandler<Message, EmailMessage> mh3 = mh1;
            mh3 = mh2;

            dynamic x = 1;
            Console.WriteLine(x);

            x = "wewe";
            Console.WriteLine(x);

            var emr1 = new EmailMessageReceiver();
            IMessageReceiver<Message> mr5 = emr1;

            Tuple<int, string> t1 = new Tuple<int, string>(1, "abc");
            (int, string) t2 = (1, "ewe");

            M1(t1);
        }

        static void M1 (Tuple<int, string> t) { }
    }
}