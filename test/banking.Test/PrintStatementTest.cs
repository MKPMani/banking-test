using banking.app.RuleEngine;
using banking.app.Validation;
using banking.domain.Models;
using banking.Test.mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking.Test
{
    public class PrintStatementTest
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenInterestCalculatedSuccessfully()
        {
            //Arrange
            var trans = MockData.GetAllTransactionData();

            //Act            
            var res = InterestRuleEngine.TransactionWithInterest("A001", "202501");
            
            var interest = res.FirstOrDefault(e => e.Type == "I"); //Interest calculated

            var result = interest != null;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenInvalidAccountTransaction()
        {
            //Arrange
            var trans = MockData.GetAllTransactionDataInvalid();

            //Act
            var res = InterestRuleEngine.TransactionWithInterest("XXXX", "202501");

            var result = res.Count != 0;

            //Assert
            Assert.False(result);
        }
    }
}
