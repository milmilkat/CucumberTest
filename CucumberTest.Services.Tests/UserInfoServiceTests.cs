using CucumberTest.Services.Interfaces;
using Xunit;
using CucumberTest.Services.Concretes;
using System;

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

        [Fact]
        public void Invalid_Cash_Test()
        {
            Assert.Throws<ArgumentException>(() => _userInfoService.GetUserDetailsWithCashInWords(null, 0.342m).CashInWords);
        }

        [Fact]
        public void Unhandled_Large_Cash_Test()
        {
            Assert.Throws<ArgumentException>(() => _userInfoService.GetUserDetailsWithCashInWords(null, 1234561).CashInWords);
        }
    }
}
