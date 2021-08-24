using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
    public abstract class DomianException : Exception
    {
        public abstract int Code { get; }

        public DomianException(string message) : base(message)
        {

        }
    }
}
