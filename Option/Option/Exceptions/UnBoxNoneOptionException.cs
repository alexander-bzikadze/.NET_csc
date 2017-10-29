using System;
using System.Runtime.Serialization;

namespace Option.Exceptions
{   
    [Serializable]
    public class UnBoxNoneOptionException : Exception
    {
        public UnBoxNoneOptionException() { }
        public UnBoxNoneOptionException(string message) : base(message) { }
        public UnBoxNoneOptionException(string message, Exception inner) : 
            base(message, inner) { }
        
        protected UnBoxNoneOptionException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}