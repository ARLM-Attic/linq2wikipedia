using System;

namespace LinqToWikipedia
{
    class LinqToWikipediaException : System.Exception
    {
        public LinqToWikipediaException(string message) : base(message) { }
        public LinqToWikipediaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
