using System.Collections.Generic;

namespace CT.Utility.Interfaces
{
    public interface IEmailMessage
    {
        string Sender { get; }
        string[] Receivers { get; }
        string[] CarbonCopy { get; set; }
        string[] BlindCarbonCopy { get; set; }
        string Subject { get; set; }
        string SubjectEncoding { get; set; }
        bool IsBodyHtml { get; set; }
        string BodyEncoding { get; set; }
        string Body { get; set; }
        string Priority { get; set; }
        IList<IEmailMessageAttachment> EmailMessageAttachments { get; set; }
        bool HasSender { get; }
        bool HasReceiver { get; }
        bool HasCarbonCopy { get; }
        bool HasBlindCarbonCopy { get; }
        bool HasEmailMessageAttachment { get; }
        bool IsValidEmailMessage { get; }
    }
}