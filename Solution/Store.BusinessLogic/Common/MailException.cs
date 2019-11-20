using System;
using System.Runtime.Serialization;

namespace PrintStore.BusinessLogic.Services
{
    [Serializable]
    internal class MailException : Exception
    {
        public MailException() {}

        public MailException(string message) : base(message) {}

        public MailException(string message, Exception innerException) : base(message, innerException){}

        protected MailException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}