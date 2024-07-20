using System;

namespace Todo.Exceptions
{
    public class GravatarClientException : Exception
    {
        public GravatarClientException(string message) : base(message)
        {
        }

        public GravatarClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
