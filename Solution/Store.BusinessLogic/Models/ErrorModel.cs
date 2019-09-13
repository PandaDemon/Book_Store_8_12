using System;

namespace Store.BusinessLogic.Models
{
    public class ErrorModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}