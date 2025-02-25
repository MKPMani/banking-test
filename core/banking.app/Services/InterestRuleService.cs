using banking.app.Helpers;
using banking.app.Validation;
using banking.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace banking.app.Services
{
    public class InterestRuleService
    {
        public static Interest AddInterestRule(string[] input)
        {
            Interest interest = new();

            interest!.Date = Common.FormatDateOnly(input[0]);
            interest!.RuleId = input[1];
            interest!.Rate = Convert.ToDouble(input[2]);
            interest!.CreationDate = DateTime.Now;

            if (!ModelValidator.ModelValidation(interest).Any())
            {
                Account.AllInterest.Add(interest);
            }

            return interest;
        }
    }
}
