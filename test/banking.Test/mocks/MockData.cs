using Moq;
using banking.domain.Models;
using System.Globalization;
using banking.app.Helpers;


namespace banking.Test.mocks
{
    public class MockData
    {
        public static  AccTransaction GetTransactionData() 
        {
            return new AccTransaction()
            {
                Date = DateOnly.Parse("01-01-2025"),
                AccountNumber = "A001",
                Type = "D",
                Amount = 100,
                TransactionId= "20250101-01"
            };
        }

        public static AccTransaction GetTransactionInvalidData()
        {
            return new AccTransaction()
            {
                Date = Common.FormatDateOnly("202501"),
                AccountNumber = "A001",
                Type = "A",
                Amount = 100,
                TransactionId = "20250101-01"
            };
        }

        public static Interest GetInterestRule()
        {
            return new Interest()
            {
                Date = Common.FormatDateOnly("20250101"),
                RuleId = "R001",
                Rate = 2.5
            };
        }

        public static Interest GetInterestRuleInvalidInput()
        {
            return new Interest()
            {
                Date = DateOnly.Parse("01-01-2025"),
                RuleId = "R001",
                Rate = 105
            };
        }
    }
}
