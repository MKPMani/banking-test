

using banking.app;
using banking.app.Helpers;
using banking.app.RuleEngine;
using banking.app.Validation;
using banking.domain.Helpers;
using banking.domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Globalization;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine(ConstMessage.WelcomeMessage);
        ShowMainMenu();
    }

    public static void ShowMainMenu()
    {        
        Console.WriteLine("\n-------------------\n");
        Console.WriteLine(ConstMessage.Menu);
        Console.WriteLine("\n-------------------\n");

        string command = Console.ReadLine();

        try
        {

            if (command == "T" || command == "t")
            {
                InputTransactions();
            }
            else if (command == "I" || command == "i")
            {
                
                SetInterestRule();
            }
            else if (command == "P" || command == "p")
            {
                PrintStatement();
            }
            else if (command == "Q" || command == "q")
            {
                Console.Clear();
                Console.WriteLine(ConstMessage.ExitMessage);
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ConstMessage.ErrorMessage);
            Console.ReadLine();
        }
    }

    public static void InputTransactions()
    {
        Console.Clear();
        Console.WriteLine(ConstMessage.TransMessage);

        string command = Console.ReadLine();

        if (!string.IsNullOrEmpty(command) && command.Split(" ").Length == InputDataValidator.TransactionInput)
        {
            var trans = command.Split(" ");

            if (trans[2].ToUpper() != "D" && trans[2].ToUpper() != "W")
            {
                Console.WriteLine("\nType allowed only (D/W).");
                ShowMainMenu();
                Console.ReadLine();
                return;
            }

            AccTransaction transaction = new();

            transaction!.Date = Common.FormatDateOnly(trans[0]);
            transaction!.AccountNumber = trans[1];
            transaction!.Type = trans[2];
            transaction!.Amount = Convert.ToDouble(trans[3]);
            transaction!.Id = SequenceGen.GetNextSeqId(transaction!.Date);

            var val = ModelValidator.ModelValidation(transaction);

            if (val.Any())
            {
                Console.WriteLine(val[0].ErrorMessage);
                Console.WriteLine("\nIs there anything else you'd like to do?");
                ShowMainMenu();
                Console.ReadLine();
                return;
            }

            transaction.TransactionId = string.Format("{0}-{1}", transaction!.Date.ToString("yyyyMMdd"), SequenceGen.GetNextSeqId(transaction!.Date).ToString("00")); 

            Account.AllTransactions.Add(transaction);

            var selAcct = Account.AllTransactions.Where(e => e.AccountNumber == transaction!.AccountNumber).ToList();

            Console.WriteLine($"\nAccount: {transaction!.AccountNumber}");
            Console.WriteLine($"Date      | Txn Id        | Type        | Amount    ");

            foreach (AccTransaction trs in selAcct)
            {
                Console.WriteLine($"{trs.Date.ToString("yyyyMMdd")}  | {trs.TransactionId}   | {trs.Type}    | {trs.Amount}  ");
            }
            
            Console.WriteLine("\nIs there anything else you'd like to do?");
            ShowMainMenu();
            Console.ReadLine();
        }
                
    }

    public static void SetInterestRule()
    {
        Console.Clear();
        Console.WriteLine(ConstMessage.RuleMessage);

        string command = Console.ReadLine();
                
        if (!string.IsNullOrEmpty(command) && command.Split(" ").Length == InputDataValidator.RulesInput)
        {
            var inst = command.Split(" ");

            Interest interest = new();

            interest!.Date = Common.FormatDateOnly(inst[0]);
            interest!.RuleId = inst[1];
            interest!.Rate = Convert.ToDouble(inst[2]);
            interest!.CreationDate = DateTime.Now;

            var val = ModelValidator.ModelValidation(interest);            

            if (val.Any())
            {
                Console.WriteLine(val[0].ErrorMessage);
                Console.WriteLine("\nIs there anything else you'd like to do?");
                ShowMainMenu();
                Console.ReadLine();
                return;
            }


            Account.AllInterest.Add(interest);

            Console.WriteLine($"Date      | RuleId        | Rate (%)  ");

            foreach (Interest intr in Account.AllInterest.OrderBy(x=> x.Date).ToList())
            {
                Console.WriteLine($"{intr.Date.ToString("yyyyMMdd")}  | {intr.RuleId}   | {Math.Round(intr.Rate,2)}");
            }

            Console.WriteLine("\nIs there anything else you'd like to do?");
            ShowMainMenu();
            Console.ReadLine();

        }
    }

    public static void PrintStatement()
    {
        Console.Clear();
        Console.WriteLine(ConstMessage.PrintMessage);

        string command = Console.ReadLine();

        if (!string.IsNullOrEmpty(command) && command.Split(" ").Length == InputDataValidator.PrintInput)
        {
            var _input = command.Split(" ");
            var acct = _input[0];
            var stdate = _input[1];

            //var selAcct = Account.AllTransactions.Where(e => e.AccountNumber == acct && e.Date.ToString("yyyyMMdd").Contains(stdate)).ToList();

            var prnt = InterestRuleEngine.TransactionWithInterest(acct, stdate);

            Console.WriteLine($"\nAccount: {acct}");
            Console.WriteLine($"Date      | Txn Id        | Type        | Amount     | Balance");

            foreach (AccTransaction trs in prnt)
            {
                Console.WriteLine($"{trs.Date.ToString("yyyyMMdd")}  | {trs.TransactionId}   | {trs.Type}    | {trs.Amount}     | {trs.Balance}");
            }

            Console.WriteLine("\nIs there anything else you'd like to do?");
            ShowMainMenu();
            Console.ReadLine();
        }
    }
}