using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;
using banking.domain.Models;
using banking.app.Helpers;

namespace banking.app.RuleEngine
{
    public class InterestRuleEngine
    {
        public static List<AccTransaction> TransactionWithInterest(string acctno, string month)
        {
            double _accInt = 0;

            var selAcct = Account.AllTransactions.Where(e => e.AccountNumber == acctno
            && e.Date.ToString("yyyyMMdd").Contains(month)).OrderBy(e => e.Date).ToList();

            var dt = Common.FormatDateOnly($"{month}01");

            var firstday = Common.FirstDayOfTheMonth(dt);
            var lastday = Common.LastDayofTheMonth(dt);

            var _nextday = firstday;

            foreach (var trans in selAcct)
            {
                var oldbal = selAcct.Max(e => e.Balance);

                if (trans.Type == "D")
                {
                    selAcct.FirstOrDefault(e => e.TransactionId == trans.TransactionId)!.Balance = oldbal + trans.Amount;
                }
                if (trans.Type == "W")
                {
                    Account.AllTransactions.FirstOrDefault(e => e.TransactionId == trans.TransactionId)!.Balance = oldbal - trans.Amount;
                }
            }

            var fromdate = firstday;
            var noofdays = 0;

            while (fromdate < lastday)
            {
                var _rule = Account.AllInterest.Where(e => e.Date == fromdate).OrderByDescending(e => e.Date).FirstOrDefault();
                var trans = selAcct.OrderByDescending(o => o.Date).FirstOrDefault(e => e.Date <= fromdate);

                if (_rule != null && trans != null)
                {
                    noofdays = Common.DaysBetween(fromdate, trans.Date);
                    _accInt = +(_rule.Rate / 100) * trans.Balance * (noofdays < 0 ? 0 : noofdays);
                }
                fromdate = fromdate.AddDays(1);
            }

            //Interest earned
            var intrst = new AccTransaction()
            {
                Date = lastday,
                Type = "I",
                Amount = _accInt / 365,
                Balance = _accInt / 365 + selAcct.OrderByDescending(e => e.Date).FirstOrDefault()!.Balance
            };

            selAcct.Add(intrst);

            return selAcct;
        }
    }
}