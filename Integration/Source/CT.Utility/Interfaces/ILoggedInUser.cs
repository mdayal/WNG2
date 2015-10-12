namespace CT.Utility.Interfaces
{
    public interface ILoggedInUser
    {
        string UserName { get; }
        bool IsInRole(string roleName);
    }
}
