using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain {
    public class Error {
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public Error(string message,Exception exception) {
            Message = message;
            Exception = exception;
        }
    }
}
