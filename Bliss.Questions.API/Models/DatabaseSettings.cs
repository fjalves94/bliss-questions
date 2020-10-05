using Bliss.Questions.API.Interfaces;

namespace Bliss.Questions.API.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}