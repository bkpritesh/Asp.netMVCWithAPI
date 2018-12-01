namespace web.ApiHelper.Interface
{
    public interface IUserSession
    {
        string Username { get; }
        string BearerToken { get; }
    }
}
