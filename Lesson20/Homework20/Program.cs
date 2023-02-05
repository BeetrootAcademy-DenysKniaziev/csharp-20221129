using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Intrinsics.X86;

namespace Homework20;
//Create application that will load assembly and show all it’s classes and their methods with arguments needed to pass and return types

internal class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        string fileName;

        using (OpenFileDialog fD = new OpenFileDialog())
        {
            //fD.InitialDirectory = "c:\\";
            fD.Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*";
            //fD.FilterIndex = 2;
            fD.RestoreDirectory = true;

            if (fD.ShowDialog() == DialogResult.OK)
            {
                fileName = fD.FileName;
                Console.Write(fileName);
                Assembly myAsm = Assembly.LoadFrom(fileName);

                var myTypes = myAsm.GetTypes();

                foreach (var myType in myTypes)
                {
                    var fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    var methods = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    var m = myType.GetMembers();
                    //m = myType.cl
                    var rTMethods = myType.GetRuntimeMethods();
                    var rTFields = myType.GetRuntimeFields();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nClass: " + myType.Name);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   Fields: " );
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var item in fields) Console.WriteLine("        " + item.Attributes + "  "+item.FieldType.Name  +"  "+ item.Name );

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   Methods: " );
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    foreach (var method in methods) 
                    {
                        string t = "        " //+method.Attributes +"   "
                            + method.ReturnType.Name +"  "+ method.Name +" (";
                        foreach (var p in method.GetParameters()) 
                        {
                            t += p.ParameterType.Name + " " + p.Name;
                            if (p.Position < method.GetParameters().Count()-1) t += ", ";
                        }
                        Console.WriteLine("    "+ t +")");
                    }
                }
            }
        }
    }
}