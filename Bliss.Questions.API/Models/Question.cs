using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bliss.Questions.API.Converters;
using Bliss.Questions.API.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Bliss.Questions.API.Models
{
    public class Question : IQuestion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [JsonProperty("question")]
        public string Text { get; set; }

        [Required]
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [Required]
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        [Required]
        [MinLength(2)]
        [JsonConverter(typeof(ChoiceJsonConverter))]
        public IEnumerable<IChoice> Choices { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }
    }
}