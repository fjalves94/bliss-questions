using Bliss.Questions.API.Interfaces;

namespace Bliss.Questions.API.Models
{
    public class SendgridSettings : ISendgridSettings
    {
        public string ApiKey { get; set; }
    }
}