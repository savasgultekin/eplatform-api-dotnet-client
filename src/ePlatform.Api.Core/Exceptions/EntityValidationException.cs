using System;
using System.Collections.Generic;

namespace ePlatform.Api.Core
{
    public class EntityValidationException : Exception
    {
        public Dictionary<string, IEnumerable<string>> Details { get; }


        public EntityValidationException(Dictionary<string, IEnumerable<string>> details, string message) : base(message)
        {
            Details = details;
        }

        public EntityValidationException(Dictionary<string, IEnumerable<string>> details, string message, Exception innerException) : base(message, innerException)
        {
            Details = details;
        }
    }
}
