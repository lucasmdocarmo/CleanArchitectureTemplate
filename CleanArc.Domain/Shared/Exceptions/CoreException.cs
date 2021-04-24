using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Shared.Exceptions
{
    [Serializable]
    public abstract class CoreException : Exception
    {
        public abstract string Key { get; }
        public abstract override string Message { get; }

        protected CoreException() : base()
        {
        }
        protected CoreException(string message) : base(message)
        {
        }

        protected CoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
