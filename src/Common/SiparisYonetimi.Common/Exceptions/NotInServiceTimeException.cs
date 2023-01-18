using System;
using System.Runtime.Serialization;

namespace SiparisYonetimi.Common.Exceptions
{
    public class NotInServiceTimeException : Exception
    {
        public NotInServiceTimeException()
        {
        }

        public NotInServiceTimeException(string message) : base(message)
        {
        }

        public NotInServiceTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotInServiceTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
