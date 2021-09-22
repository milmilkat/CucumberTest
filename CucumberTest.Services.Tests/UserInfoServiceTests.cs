using CucumberTest.Services.Interfaces;
using Xunit;
using CucumberTest.Services.Concretes;

namespace CucumberTest.Services.Tests
{
    public class UserInfoServiceTests
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoServiceTests()
        {
            _userInfoService = new UserInfoService();
        }

        [Fact]
        public void Zero_Dollar_Test()
        {
            Assert.Equal("zero dollar", _userInfoService.GetUserDetailsWithCashInWords(null, 0).CashInWords);
        }
    }
}
