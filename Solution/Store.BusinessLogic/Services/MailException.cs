using System;
using System.Runtime.Serialization;

namespace Store.BusinessLogic.Services
{
    [Serializable]
    internal class MailException
    {
        public MailException()
        {
        }
        public MailException(string message) : base(message)
        {
        }
        public MailException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected MailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
