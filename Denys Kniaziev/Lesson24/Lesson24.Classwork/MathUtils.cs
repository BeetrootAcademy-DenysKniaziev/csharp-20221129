namespace Lesson24.Classwork
{
    public static class MathUtils
    {
        public static int Sum(int a, int b) => a + b;

        public static bool StartsWithCapitalLetter(this string str)
        {
            var firstLetter = str.First();

            return char.IsLetter(firstLetter) && char.IsUpper(firstLetter);
        }
    }
}
