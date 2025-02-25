using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking.app.Helpers
{
    public class ConstMessage
    {
        public const string WelcomeMessage = "Weolcome to Awesome GIC Bank! What would like to do?";
        public const string Menu = "[T]: Input transactions\n[I]: Define interest rules\n[P]: Print statement\n[Q]: Quit";
        public const string ExitMessage = "Thank you for banking with Awesome GIC Bank. \nHave a nice day!";
        public const string TransMessage = "Please enter transaction details in <Date> <Account> <Type> <Amount> (or enter blank to go back main menu):";
        public const string PrintMessage = "Please enter account and month to generate the statement <Account> <Year><Month>\r\n(or enter blank to go back to main menu):";
        public const string RuleMessage = "Please enter interest rules details in <Date> <RuleId> <Rate in %> format \r\n(or enter blank to go back to main menu):";
        public const string ErrorMessage = "Invalid input, please verify";        
    }
}
