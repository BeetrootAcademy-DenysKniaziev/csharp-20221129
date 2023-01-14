class A
{
    protected int AProp { get; set; }

    public virtual void Do()
    {
        Console.WriteLine("A.Do()");
    }
}

class AA : A
{
}

class B : A
{
    public int BProp { get; set; }

    public override void Do()
    {
        AProp++;
        this.AProp++;
        base.AProp++;
        Console.WriteLine("B.Do()");
    }

    public void DoB()
    {
        Console.WriteLine("B.DoB()");
    }
}

class C : B
{
    public virtual new void Do()
    {
        AProp++;
        Console.WriteLine("C.Do()");
    }
}

class D : C
{
    public override void Do()
    {
        Console.WriteLine("D.Do()");
    }
}

class Program
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();
        D d = new D();

        //a.PropA();
        //MethodArr(new A[] { a, b, c, new AA() });

        //a.Do();
        //b.Do();
        //c.Do();

        //b.DoB();

        //a = b;
        //Method(a); 

        ////b.DoB();
        ////a.DoB();

        //a = c;
        //Method(a);

        //a = new D();
        //Method(a);

        //Method(b);
        //b = c;
        //Method(b);
        //b = d;
        //Method(b);

        Method(c);
        c = d;
        Method(c);

    }

    static void Method(C a)
    {
        a.Do();
    }

    static void MethodArr(A[] arr)
    {
        foreach (var item in arr)
        {
            if (item is B b)
                b.DoB();
            else
                item.Do();
        }
    }
}