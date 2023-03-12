using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework15;

public class Element<U>
{
    U _element;
    public U TheElement { get {return _element ; } set {_element = value; } }
    public Element<U> Next { get; set; }
    public Element<U> Previeus { get; set; }
    public Element(U obj)
    {
        _element = obj;
    }
    public Element()
    {
    }
}


internal class MyStack<U> : IEnumerable<U>

{
    //public U Element { get; set; }
    //public Element<U> CurrentElement { get; set; }
    public Element<U> Top { get; set; }
    public Element<U> Bottom { get; set; }

    public void Push(U obj) //Push(obj) - adds obj at the top of stack
    {
        var temp = Top;
        Top = new Element<U>(obj);
        Top.Next = null;
        if (Bottom != null)
        {
            temp.Next = Top;
            Top.Previeus = temp;
        }
        else
        {
            Top.Previeus = null;
            Bottom = Top;
        }
        Count++;
    }

    public U Pop() //Pop() -returns top element of stack & removes it
    {
        var temp = Top;
        try
        {

            if (Top != null)
            {
                if (Top != Bottom)
                {
                    Top.Previeus.Next = null;
                    Top = temp.Previeus;
                    Count--;
                }
                else this.Clear();

                return temp.TheElement;
            }
            else 
            {
                throw new Exception("No more elements in MyStack"); 
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex);
            return new Element<U>().TheElement;
        }


    }

    public void Clear()//Clear() -clear stack
    {
        Count = 0;
        Bottom = null;
        Top = null;
    }
    public int Count { get; set; } //Count - property return number of elements
    public U Peek() //Peek() -returns top element but doesn’t remove it
    { 
        if(Top != null) return Top.TheElement;
        else
        {
            Console.WriteLine("No Elements in MyStack");
            return new Element<U>().TheElement; 
        }
    }
    public U[] CopyTo(U[] arr) //CopyTo(arr) -copies stack to array
    {
        Element<U> element = Bottom;
        for (int i = 0; i < arr.Length; i++) 
        {
            if (element != null) { arr[i] = element.TheElement; }
            else break;
            element = element.Next;
        }
        return arr;
    
    }


    IEnumerator IEnumerable.GetEnumerator()
    {                                               
        return ((IEnumerable)this).GetEnumerator();
    }

    IEnumerator<U> IEnumerable<U>.GetEnumerator()
    {
        Element<U> temp = Bottom; 
        while (temp != null) 
        {
            yield return temp.TheElement;//Povrertae potochnyi stan fiksuuchy danu tochku vykonnannya, pry nastupnomu zvernenni pochynae z nei
            temp = temp.Next; 
        }
    }




}
