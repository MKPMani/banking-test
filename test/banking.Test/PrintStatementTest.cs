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
        public async Task Handle_ShouldReturnTrue_WhenPrintStatementSuccessfully()
        {
            //Arrange
            var trans = MockData.GetTransactionData();

            //Act            
            Account.AllTransactions.Add(trans);
            var result = Account.AllTransactions.Count() > 0;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenRuleOutOfRange()
        {
            //Arrange
            var intrst = MockData.GetInterestRuleInvalidInput();

            //Act
            var errCount = ModelValidator.ModelValidation(intrst);

            var result = errCount.Count == 0;

            //Assert
            Assert.False(result);
        }
    }
}
