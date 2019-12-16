using System;

namespace ePlatform.Api.Core
{
    public class ForbiddenExcepitons : ePlatformException
    {
        public ForbiddenExcepitons(string message) : base(message)
        {

        }

        public ForbiddenExcepitons(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
