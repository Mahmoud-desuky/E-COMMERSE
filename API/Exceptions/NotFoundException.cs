using System;

namespace Back.API.Exceptions
{
    public class NotFoundException:Exception
    {
        public string MessageCode;
        public new string Message;

        public NotFoundException()
        {

        }
        public NotFoundException( string messageCode):base(messageCode)  
        {
            MessageCode = messageCode;
        }
        public NotFoundException( string message, string messageCode):base(message)  
        {
            Message = message;
            MessageCode = messageCode;
        }

    }
}