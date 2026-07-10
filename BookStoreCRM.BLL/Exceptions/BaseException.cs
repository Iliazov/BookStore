namespace BookStoreCRM.BLL.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string msg) : base(msg) { }
    }
}
