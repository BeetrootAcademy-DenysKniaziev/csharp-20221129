using Xunit;

namespace StringUtils
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Super", "Super")]
        [InlineData("123", "123")]
        public void CompareTwoStrongForEquality(string s1, string s2)
        {
            var result = Program.MyEquals(s1, s2);
            Assert.Equal(result, true);

        }

        [Fact]
        public void CompareTwoStrongForEqualityFact()
        {
            var result = Program.MyEquals("Sk0rpion", "Skorpin");
            Assert.Equal("Skorpion", "Skorpion");
            Assert.NotEqual(result, true);

        }
    }
}