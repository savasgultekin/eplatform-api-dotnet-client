using System;

namespace ePlatform.Api.Core
{
    public class UnauthorizedExcepiton : Exception
    {
        public UnauthorizedExcepiton(string message) : base(message)
        {

        }

        public UnauthorizedExcepiton(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
