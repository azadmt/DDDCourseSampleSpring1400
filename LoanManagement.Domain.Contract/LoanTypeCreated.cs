using Framework.Core.Messageing;
using System;

namespace LoanManagement.Domain.Contract
{
    public class LoanTypeCreated : IEvent
    {
        public LoanTypeCreated(Guid id,string title,int code,int payDuration)
        {
            Id = id;
            Title = title;
            Code = code;
            PayDuration = payDuration;
        }

        public Guid Id { get; }
        public string Title { get; }
        public int Code { get; }
        public int PayDuration { get; }
    }
}
