using Lesson24.Classwork;

namespace Lesson24.Tests
{
    public class MathUtilsTests
    {
        [Theory]
        [InlineData(4, 6, 10)]
        [InlineData(3, 5, 8)]
        [InlineData(1, 3, 4)]
        [InlineData(2, 2, 4)]
        public void Sum_ShouldReturnExpectedSum(int a, int b, int expected)
        {            
            int actual = MathUtils.Sum(a, b);

            Assert.Equal(expected, actual);
            Assert.NotEqual(a, b);
        }

        [Theory]
        [InlineData("Abc", true)]
        [InlineData("abc", false)]
        public void StartsWithCapitalLetter_ShouldVerifyIsStringStartsWithCapitalLetter(
            string str,
            bool expected)
        {
            bool actual = str.StartsWithCapitalLetter();

            Assert.Equal(expected, actual);   
        }

        [Fact]
        public void StartsWithCapitalLetter_ShouldThrowExceptionIfStringIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => "".StartsWithCapitalLetter());
        }
    }
}