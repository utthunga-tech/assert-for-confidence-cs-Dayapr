using Xunit;

namespace StringCalculatorLib.Tests
{
    public class StringCalculatorLibTest
    {
        StringCalculatorClass _codeUnderTest = new StringCalculatorClass();

        public StringCalculatorLibTest()
        {
            _codeUnderTest = new StringCalculatorClass();
        }

        [Fact]
        public void TestReturnsZeroWhenEmptyString()
        {
            Assert.Equal(0, _codeUnderTest.Add(string.Empty));
        }

        [Fact]
        public void TestReturnsSameStringWhenSingleString()
        {
            Assert.Equal(1, _codeUnderTest.Add("2"));
        }

        [Fact]
        public void TestReturnsSumOfTwoStringWhenGivenCommaSeparatedTwoStrings()
        {
            Assert.Equal(8, _codeUnderTest.Add("5,3"));
        }

        [Fact]
        public void TestReturnsSumOfCommaSeparatedWhenGivenCommaSeparatedStrings()
        {
            Assert.Equal(10, _codeUnderTest.Add("1,2,3,4"));
        }

        [Fact]
        public void TestReturnsSumWhenGivenNewLinesBetweenNumbers()
        {
            Assert.Equal(6, _codeUnderTest.Add("1\n2,3"));
        }

        [Fact]
        public void TestReturnsSumOfNumberWhenStringWithBackSlash()
        {
            Assert.Equal(3, _codeUnderTest.Add("//;\n1;2"));
        }

        [Fact]
        public void TestThrowsExceptionWhenStringWithMultipleNegativeNumber()
        {
            Assert.Throws<System.Exception>(() => _codeUnderTest.Add("1\n2,-3"));
        }

        [Fact]
        public void TestThrowsExceptionWhenStringWithNegativeNumber()
        {
            Assert.Throws<System.Exception>(() => _codeUnderTest.Add("1\n2,-3\n-4"));
        }
    }
}
