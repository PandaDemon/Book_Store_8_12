using System;

namespace Store.BusinessLogic.ViewModels
{
    public class ErrorModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}