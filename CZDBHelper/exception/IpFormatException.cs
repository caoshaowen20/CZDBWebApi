using System;

namespace CZDBHelper.exception
{
    public class IpFormatException : Exception
    {
        public IpFormatException(String message) : base(message)
        {
        }
    }
}