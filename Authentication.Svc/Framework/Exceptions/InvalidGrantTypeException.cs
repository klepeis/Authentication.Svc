using System;

namespace Authentication.Svc.Framework.Exceptions
{
    public class InvalidGrantTypeException : Exception
    {
        public InvalidGrantTypeException() 
            : base("Invalid grant type")
        {
        }
    }
}
