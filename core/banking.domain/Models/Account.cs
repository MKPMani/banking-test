using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace banking.domain.Models
{
    public class Account
    {
        private static List<AccTransaction> transactions = [];
        private static List<Interest> interests = [];
        public Account()
        {

            transactions = new List<AccTransaction>();
            interests = new List<Interest>();
        }

        public static List<AccTransaction> AllTransactions
        {
            get { return transactions; }
        }

        public static List<Interest> AllInterest
        {
            get { return interests; }
        }

    }
}