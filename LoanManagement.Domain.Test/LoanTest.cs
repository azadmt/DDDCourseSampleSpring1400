//using System;
//using Xunit;
//using FluentAssertions;
//using LoanManagement.Domain.LoanAggregate.Exception;
//using LoanManagement.Domain.LoanTypeAggregate;
//using LoanManagement.Domain.LoanAggregate;

//namespace LoanManagement.Domain.Test
//{
//    public class LoanTest
//    {
//        LoanType loanType;
//        public LoanTest()
//        {
//            loanType = new LoanType(Guid.NewGuid(), "Gharz alhasane talaei", 1000, 10, 720);
//        }

//        [Fact]
//        public void ShouldBeEqual_When_IdIsSame()
//        {
//            var customerId = Guid.NewGuid();

//            var loanAmount = 10000000;
//            var payDate = DateTime.Now.AddYears(1);
//            var loan = new Loan(Guid.NewGuid(),customerId, loanType, loanAmount);
//            loan.Id.Should().NotBeEmpty();
//        }
//        [Fact]
//        public void ShouldCreateLoan_When_InputValidData()
//        {
//            var customerId = Guid.NewGuid();

//            var loanAmount = 10000000;
//            var payDate = DateTime.Now.AddYears(1);
//            var loan = new Loan(Guid.NewGuid(),customerId, loanType, loanAmount);
//            loan.Id.Should().NotBeEmpty();
//        }

//        [Fact]
//        public void ShouldThrowLoanPaydateIsInPastException_When_LoanPayDateIsInThePast()
//        {
//            var customerId = Guid.NewGuid();
//            var loantype2 = new LoanType(Guid.NewGuid(),"Gharz alhasane talaei", 1000, 10, -720);
//            var loanAmount = 10000000;

//            Action loanCreation = () => new Loan(Guid.NewGuid(),customerId, loantype2, loanAmount);
//            loanCreation.Should().Throw<LoanPaydateIsInPastException>();
//        }

//        [Theory]
//        [InlineData(5)]
//        [InlineData(500)]
//        [InlineData(53)]
//        [InlineData(33)]
//        [InlineData(105)]
//        public void ShouldMatchInsstalmentCountWhithLoanType_When_DefineMInsstalmentCountInLoanType(int payDateDay)
//        {
//            var customerId = Guid.NewGuid();
//            var loanId = Guid.NewGuid();
//            var loantype2 = new LoanType(Guid.NewGuid(),"Gharz alhasane talaei", 1000, 10, payDateDay);
//            var loanAmount = new Money(10000000,"");
//            var loan1 = new Loan(loanId, customerId, loantype2, loanAmount,null);
//            var loan2 = new Loan(loanId, customerId, loantype2, loanAmount, null);
//            loan1.Id.Should().Be(loan2.Id);
      
//        }
//    }
//}
