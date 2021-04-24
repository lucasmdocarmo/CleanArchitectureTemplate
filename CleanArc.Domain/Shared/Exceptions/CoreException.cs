using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Shared.Exceptions
{
    [Serializable]
    public class CoreException : Exception
    {
        public override string Message { get; }

        public CoreException() : base()
        {
        }
        public CoreException(string message) : base(message)
        {
        }

        public CoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
