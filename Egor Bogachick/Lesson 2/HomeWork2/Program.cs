Console.OutputEncoding = System.Text.Encoding.Unicode; // для розкадки

Console.Write("Ведіть x: ");
double x = Convert.ToDouble(Console.ReadLine());

Console.Write("Ведіть y: ");
double y = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"\n Перший приклад -6*x^3+5*x^2-10*x+15: {Math.Round(-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15, 2)}");
Console.WriteLine($" Другий приклад abs(x)*sin(x): {Math.Round(Math.Abs(x) * Math.Sin(x), 2)}");
Console.WriteLine($" Третій приклад 2*pi*x: {Math.Round(2 * Math.PI * x, 2)}");
Console.WriteLine($" Четвертий приклад max(x, y): {Math.Max(x, y)}");