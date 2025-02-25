using banking.app.Helpers;
using banking.app.Validation;
using banking.domain.Helpers;
using banking.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking.app.Services
{
    public class AccTransactionService
    {
        public static AccTransaction AddTransaction(string[] input)
        {
            AccTransaction transaction = new();

            transaction!.Date = Common.FormatDateOnly(input[0]);
            transaction!.AccountNumber = input[1];
            transaction!.Type = input[2];
            transaction!.Amount = Convert.ToDouble(input[3]);
            transaction!.Id = SequenceGen.GetNextSeqId(transaction!.Date);

            transaction.TransactionId = string.Format("{0}-{1}", transaction!.Date.ToString("yyyyMMdd"),
                SequenceGen.GetNextSeqId(transaction!.Date).ToString("00"));

            if (!ModelValidator.ModelValidation(transaction).Any())
            {
                Account.AllTransactions.Add(transaction);
            }

            return transaction;
        }

        public static List<AccTransaction> GetTransaction(string acctNumber)
        {
            return Account.AllTransactions.Where(e => e.AccountNumber == acctNumber).ToList();
            
        }

    }
}
