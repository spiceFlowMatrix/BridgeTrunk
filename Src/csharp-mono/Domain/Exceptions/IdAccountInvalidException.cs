using System;

namespace Bridge.Domain.Exceptions
{
    public class IdAccountInvalidException : Exception
    {
        public IdAccountInvalidException(string idAccount, Exception ex)
            : base($"ID Account \"{idAccount}\" is invalid.", ex)
        { }
    }
}