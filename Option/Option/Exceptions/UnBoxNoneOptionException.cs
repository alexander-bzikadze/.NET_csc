using System;

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
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}