using System.ComponentModel.DataAnnotations;
using Bliss.Questions.API.Interfaces;
using Newtonsoft.Json;

namespace Bliss.Questions.API.Models
{
    public class Choice: IChoice
    {
        [Required]
        [JsonProperty("choice")]
        public string Text { get; set; }
        public int Votes { get; set; }
    }
}