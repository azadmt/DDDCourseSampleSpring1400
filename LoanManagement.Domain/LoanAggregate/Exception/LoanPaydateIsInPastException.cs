using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Domain.LoanAggregate.Exception
{
    public class LoanPaydateIsInPastException : DomianException
    {
        public override int Code => 100;
        public LoanPaydateIsInPastException(string message) : base(message)
        {
        }
    }
}
