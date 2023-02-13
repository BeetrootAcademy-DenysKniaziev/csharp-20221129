using Lesson24.Homework;

namespace TestProject1
{
    public class MathUtilsTest
    {
        [Theory]
        [InlineData("Hello", "Hallo")]
        [InlineData("Hello", "Hi")]
        [InlineData("Hello", "Hello")]
        public static void MathUtils_Compare_ShouldReturnBool(string str1, string str2)
        {
            bool res = MathUtils.Compare(str1, str2);
            Assert.True(res);
        }

        [Theory]
        [InlineData("Hello123.")]
        public static void MathUtils_Analyze_ShouldReturnCorrectAmountOfSymbols(string str)
        {
            var IsSymbol = 1;
            var IsLetter = 5;
            var IsDigit = 3;
            string expected = $"Letters: {IsLetter}\nDigits: {IsDigit}\nSymbols: {IsSymbol}";

            var actual = MathUtils.Analyze(str);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void MathUtils_Sort_ShouldReturnStringInAscendingOrder()
        {
            var expected = "Hello".OrderBy(i=>i);
            var actual = MathUtils.Sort("Hello");
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Helloo")]
        public static void MathUtils_Duplicate_ShouldReturnTrueIfStringContainsDuplicates(string str)
        {
            var res = MathUtils.Duplicate(str);
            Assert.NotEmpty(res);
        }
    }
}