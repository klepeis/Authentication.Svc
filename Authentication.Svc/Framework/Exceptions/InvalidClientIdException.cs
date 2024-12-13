using System;

namespace Authentication.Svc.Framework.Exceptions
{
    public class InvalidClientIdException : Exception
    {
        public InvalidClientIdException() 
            : base("invalid_client")
        {
        }
    }
}
