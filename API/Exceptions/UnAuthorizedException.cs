namespace E_COMMERSE.API.Exceptions
{
    public class UnAuthorizedException : Exception
    {
         public UnAuthorizedException()
        {
        }
        public UnAuthorizedException(string message) : base(message)
        {
        }
    }
}
