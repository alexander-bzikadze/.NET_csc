using System;
using System.Runtime.Serialization;

namespace MyNUnit.Framework
{
    public class Test : Attribute
    {
        public Type Expected { get; set; }
        public string Ignore { get; set; } = "";
    }

    public class Before : Attribute {}
    public class After : Attribute {}
    public class BeforeClass : Attribute {}
    public class AfterClass : Attribute {}
    
    [Serializable]
    public class AssertionException : Exception
    {
        public AssertionException()
        {
        }

        public AssertionException(string message) : base(message)
        {
        }

        public AssertionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AssertionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}