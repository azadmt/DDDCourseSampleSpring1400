using Framework.Domain;
using LoanManagement.Domain.LoanAggregate.Exception;
using LoanManagement.Domain.LoanTypeAggregate;
using System;
using System.Collections.Generic;

namespace LoanManagement.Domain.LoanAggregate
{
    public class Loan : Entity
    {
        public Guid OwnerId { get; private set; }
        public Guid LoanTypeId { get; private set; }
        public Money LoanAmount { get; private set; }

        public LoanState State { get; private set; }
        public DateTime PayDate { get; private set; }
        public static Loan CreateLoan(Guid ownerId, LoanType loanType, decimal loanAmount)
        {
            Money amount = new Money(loanAmount, "Rial");
            return new Loan(Guid.NewGuid(), ownerId, loanType, amount, null);
        }
        public static Loan CreateLoanWhitGurantors(Guid ownerId, LoanType loanType, decimal loanAmount, List<Guid> gurantors)
        {
            Money amount = new Money(loanAmount, "");
            var loan = new Loan(Guid.NewGuid(), ownerId, loanType, amount, gurantors);

            return loan;
        }

        public Loan(Guid id, Guid ownerId, LoanType loanType, Money loanAmount, List<Guid> gurantors) : base(id)
        {
            this.OwnerId = ownerId;
            this.LoanTypeId = loanType.Id;
            this.LoanAmount = loanAmount;
            State = LoanState.Requested;
            SetPayDate(loanType.PayDateDay);
        }


        public void Approve()
        {
            State = LoanState.Approved;
        }
        public void Reject()
        {
            if (State == LoanState.Paid)
                throw new NotSupportedException("you can not reject a paid loan !!!");
            State = LoanState.Rejected;
        }

        public void Pay()
        {
            if (State == LoanState.Rejected)
                throw new NotSupportedException("rejected loan can not be paid !!!");
            State = LoanState.Paid;
        }

        private void SetPayDate(int payDateDay)
        {
            this.PayDate = DateTime.Now.AddDays(payDateDay);
            if (PayDate < DateTime.Now)
                throw new LoanPaydateIsInPastException("LoanPaydateIsInPastException");
        }

    }

    //public class ApprovedLoan
    //{
    //    void Reject();
    //    void Pay();
    //}

    //public class RejectedLoan
    //{

    //}
    //public interface ILoanState
    //{
    //    void Approve();
    //    void Reject();
    //    void Pay();
    //}
    //public class RequestedLoanState : ILoanState
    //{
    //    public RequestedLoanState(Loan loan)
    //    {

    //    }
    //    public void Approve()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Pay()
    //    {
    //        //
    //    }

    //    public void Reject()
    //    {
    //        //
    //    }
    //}
    //public class ApprovedLoanState : ILoanState
    //{
    //    public ApprovedLoanState(Loan loan)
    //    {

    //    }
    //    public void Approve()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Pay()
    //    {
    //     //
    //    }

    //    public void Reject()
    //    {
    //       //
    //    }
    //}

    //public class PaidLoanState : ILoanState
    //{
    //    public void Approve()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Pay()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Reject()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public enum LoanState
    {
        Requested,
        Approved,
        Paid,
        Rejected
    }
}

