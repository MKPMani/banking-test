using banking.app;
using banking.app.Helpers;
using banking.app.RuleEngine;
using banking.app.Services;
using banking.app.Validation;
using banking.domain.Helpers;
using banking.domain.Models;


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

            if (ModelValidator.ValidateTransType(trans[2].ToUpper()))
            {
                Console.WriteLine("\nType allowed only (D/W).");
                ShowMainMenu();
                Console.ReadLine();
                return;
            }

            var txn = AccTransactionService.AddTransaction(trans);

            var val = ModelValidator.ModelValidation(txn);

            if (val.Any())
            {
                Console.WriteLine(val[0].ErrorMessage);
                Console.WriteLine("\nIs there anything else you'd like to do?");
                ShowMainMenu();
                Console.ReadLine();
                return;
            }

            var selAcct = AccTransactionService.GetTransaction(txn.AccountNumber);

            Console.WriteLine($"\nAccount: {txn!.AccountNumber}");
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

        string? command = Console.ReadLine();

        if (!string.IsNullOrEmpty(command) && command.Split(" ").Length == InputDataValidator.RulesInput)
        {
            var inst = command.Split(" ");

            var intr = InterestRuleService.AddInterestRule(inst);

            var val = ModelValidator.ModelValidation(intr);

            if (val.Any())
            {
                Console.WriteLine(val[0].ErrorMessage);
                Console.WriteLine("\nIs there anything else you'd like to do?");
                ShowMainMenu();
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Date      | RuleId        | Rate (%)  ");

            foreach (Interest data in Account.AllInterest.OrderBy(x => x.Date).ToList())
            {
                Console.WriteLine($"{data.Date.ToString("yyyyMMdd")}  | {data.RuleId}   | {Math.Round(data.Rate, 2)}");
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

        string? command = Console.ReadLine();

        if (!string.IsNullOrEmpty(command) && command.Split(" ").Length == InputDataValidator.PrintInput)
        {
            var _input = command.Split(" ");
            var acct = _input[0];
            var stdate = _input[1];

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