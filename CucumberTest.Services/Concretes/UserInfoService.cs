using CucumberTest.Business.Models;
using CucumberTest.Services.Extensions;
using CucumberTest.Services.Interfaces;
using System;

namespace CucumberTest.Services.Concretes
{
    public class UserInfoService : IUserInfoService
    {
        public UserInfo GetUserDetailsWithCashInWords(string fullName, decimal userCash)
        {
            var cashValue = Math.Truncate(userCash * 100);
            if (userCash * 100 - cashValue > 0)
                throw new ArgumentException("Cash value is not standard");

            if(userCash >= 1000000)
                throw new ArgumentException("That amount is not supported, please select less");

            var userInfo = new UserInfo
            {
                FullName = fullName,
                CashInWords = string.Empty
            };

            var wholePart = Math.Truncate(userCash);
            userInfo.CashInWords = GetWholePartWords(wholePart);

            var demicalPart = userCash - wholePart;
            userInfo.CashInWords += GetDecimalPartWords(demicalPart);

            return userInfo;
        }

        private string GetWholePartWords(decimal wholePart)
        {
            var result = $"{decimal.ToInt32(wholePart).ToWord()} dollar";
            if (wholePart > 1)
                result += "s";
            return result;
        }

        private string GetDecimalPartWords(decimal decimalPart)
        {
            if (decimalPart == 0)
                return string.Empty;

            // removing 0 and . from the length
            var length = decimalPart.ToString().Length - 2;
            decimalPart *= Convert.ToDecimal(Math.Pow(10, length));

            var result = $" and {decimal.ToInt32(decimalPart).ToWord()} cent";
            if (decimalPart > 1)
                result += "s";
            return result;
        }
    }
}
