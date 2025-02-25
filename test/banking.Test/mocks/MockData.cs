using Moq;
using banking.domain.Models;
using System.Globalization;
using banking.app.Helpers;


namespace banking.Test.mocks
{
    public class MockData
    {
        public static AccTransaction GetTransactionData()
        {
            return new AccTransaction()
            {
                Date = DateOnly.Parse("01-01-2025"),
                AccountNumber = "A001",
                Type = "D",
                Amount = 100,
                TransactionId = "20250101-01"
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
                Date = Common.FormatDateOnly("01-01-2025"),
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

        public static List<AccTransaction> GetAllTransactionData()
        {
            return
            [
             new AccTransaction(){AccountNumber = "A001", Amount = 2000, Date = new DateOnly(2025,01,01) , Type = "D", TransactionId ="20250101-01" },
             new AccTransaction(){AccountNumber = "A001", Amount = 2500, Date = new DateOnly(2025,01,10) , Type = "D", TransactionId ="20250110-01" },
             new AccTransaction(){AccountNumber = "A001", Amount = 1000, Date = new DateOnly(2025,01,20) , Type = "W", TransactionId ="20250120-01" },
            ];
        }

        public static List<AccTransaction> GetAllTransactionDataInvalid()
        {
            return
            [
             new AccTransaction(){AccountNumber = "A002", Amount = 2000, Date = new DateOnly(2025,01,01) , Type = "D", TransactionId ="20250101-01" },
             new AccTransaction(){AccountNumber = "A002", Amount = 2500, Date = new DateOnly(2025,01,10) , Type = "D", TransactionId ="20250110-01" },
             new AccTransaction(){AccountNumber = "A002", Amount = 1000, Date = new DateOnly(2025,01,20) , Type = "W", TransactionId ="20250120-01" },
            ];
        }

    }
}
