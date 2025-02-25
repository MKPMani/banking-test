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
    public class InterestRuleTest
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenRuleAddedSuccessfully()
        {
            //Arrange
            var intrst = MockData.GetInterestRule();

            //Act
            Account.AllInterest.Add(intrst);
            var result = Account.AllInterest.Count() > 0;

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
