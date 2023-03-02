using System.Linq;
using Xunit;

namespace Lesson7.HomeWork.Tests
{
    public class WorkWithStringsTests
    {
        [Theory]
        [InlineData("Super", "Super")]
        [InlineData("123", "123")]
        public void CompareTwoStringForEquality(string s1, string s2)
        {
            var result = WorkWithStrings.MyEquals(s1, s2);
            Assert.Equal(result, true);

        }

        [Fact]
        public void CompareTwoStringForEqualityFact()
        {
            var result = WorkWithStrings.MyEquals("Sk0rpion", "Skorpin");
            Assert.Equal("Skorpion", "Skorpion");
            Assert.NotEqual(result, true);

        }
        [Theory]
        [InlineData("Hello World", new char[] { 'l', 'o' })]
        [InlineData("H3110 i 4m r0bot", new char[] { '0', '1', ' ' })]

        public void CheckingForExpectedDuplicatesInTheString (string s1, char[] duplicates)
        {
            var result = WorkWithStrings.Duplicate(s1);
            Assert.Equal(result.Intersect(duplicates).Count(), duplicates.Count());
        }
        [Theory]
        [InlineData("Hello", 5, 0, 0)]
        [InlineData("H3110 )", 1, 4, 2)]

        public void CheckingTheExpectedValueOfStringAnalysis(string s1, int letter, int number, int another)
        {
            var result = WorkWithStrings.Analyze(s1);
            Assert.Equal(result.letter, letter);
            Assert.Equal(result.number, number);
            Assert.Equal(result.another, another);
        }
    }
}