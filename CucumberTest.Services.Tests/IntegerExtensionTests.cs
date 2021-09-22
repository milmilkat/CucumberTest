using CucumberTest.Services.Extensions;
using Xunit;

namespace CucumberTest.Services.Tests
{
    public class IntegerExtensionTests
    {
        [Fact]
        public void Zero_Value_Test()
        {
            Assert.Equal("zero", 0.ToWord());
        }

        [Fact]
        public void Zero_Left_Padded_Test()
        {
            Assert.Equal("one", 001.ToWord());
        }

        [Fact]
        public void Six_Digit_Number_Test()
        {
            Assert.Equal("nine billions and eight millions and seven thousands and six hundreds and fifty four", 987654.ToWord());
        }
    }
}
