using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SiparisYonetimi.Common.Exceptions
{
    public class NotAvaibleCompanyException : Exception
    {
        public NotAvaibleCompanyException()
        {
        }

        public NotAvaibleCompanyException(string message) : base(message)
        {
        }

        public NotAvaibleCompanyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAvaibleCompanyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
