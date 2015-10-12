namespace CT.Utility.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(IEmailMessage message);
    }
}
