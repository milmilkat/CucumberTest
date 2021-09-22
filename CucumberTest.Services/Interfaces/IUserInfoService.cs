using CucumberTest.Business.Models;

namespace CucumberTest.Services.Interfaces
{
    public interface IUserInfoService
    {
        UserInfo GetUserDetailsWithCashInWords(string fullName, decimal userCash);
    }
}
