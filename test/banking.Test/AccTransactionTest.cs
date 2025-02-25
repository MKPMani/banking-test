using banking.app.Validation;
using banking.domain.Models;
using banking.Test.mocks;
using System.Transactions;
using Xunit.Abstractions;

namespace banking.Test
{
    public class AccTransactionTest
    {
        public AccTransactionTest()
        {
            Account.AllTransactions.Clear();
        }

        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenTransactionAddedSuccessfully()
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
        public async Task Handle_ShouldReturnFail_WhenTransactionWithInvalidInput()
        {
            //Arrange
            var trans = MockData.GetTransactionInvalidData();

            //Act
            var errCount = ModelValidator.ModelValidation(trans);
            var result = errCount.Count == 0;

            //Assert
            Assert.False(result);
        }

    }
}