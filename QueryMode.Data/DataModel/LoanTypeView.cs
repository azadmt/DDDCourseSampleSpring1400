using System;

namespace QueryModel.Data.DataModel
{
    public class LoanTypeView
    {
        public Guid Id { get; private set; }
        public string Title { get; }
        public int Code { get; }
        public int PayDuration { get; }
    }
}
