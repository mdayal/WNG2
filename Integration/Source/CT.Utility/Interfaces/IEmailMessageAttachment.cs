namespace CT.Utility.Interfaces
{
    public interface IEmailMessageAttachment
    {
        string ID { get; }
        string Name { get; }
        string MediaType { get; set; }
        byte[] Data { get; }
    }
}