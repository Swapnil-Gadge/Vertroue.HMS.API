namespace Vertroue.HMS.API.Application.Models.Mail
{
    public class Email
    {
        public List<string> To { get; set; }
        public string From { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
