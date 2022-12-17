using System.Text.RegularExpressions;

var regex = new Regex(@"^\d+$");

var str1 = "1234567";
var str2 = "546sdfg435";

Console.WriteLine(regex.IsMatch(str1));
Console.WriteLine(regex.IsMatch(str2));