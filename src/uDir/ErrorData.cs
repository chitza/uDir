using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uDir
{
    /// <summary>
    /// Class that holds information about an error condition.
    /// </summary>
    public class ErrorData
    {
        public ErrorData(string message, Exception ex)
        {
            Message = message;
            Exception = ex;
        }

        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
