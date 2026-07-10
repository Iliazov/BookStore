namespace BookStoreCRM.BLL.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string msg) : base(msg) { }
    }
}
