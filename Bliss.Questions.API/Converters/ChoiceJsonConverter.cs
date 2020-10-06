using System;
using System.Collections.Generic;
using Bliss.Questions.API.Interfaces;
using Bliss.Questions.API.Models;
using Newtonsoft.Json;

namespace Bliss.Questions.API.Converters
{
    public class ChoiceJsonConverter : JsonConverter<IEnumerable<IChoice>>
    {
        public override IEnumerable<IChoice> ReadJson(JsonReader reader, Type objectType, IEnumerable<IChoice> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return (List<Choice>)serializer.Deserialize(reader, typeof(List<Choice>));
        }

        public override void WriteJson(JsonWriter writer, IEnumerable<IChoice> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(List<Choice>));
        }
    }
}