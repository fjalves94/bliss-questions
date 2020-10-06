using System.Collections.Generic;
using System.Linq;
using Bliss.Questions.API.Interfaces;
using Bliss.Questions.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Bliss.Questions.API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly MongoCollection<Question> _collection;

        public QuestionService(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var server = client.GetServer();
            var db = server.GetDatabase(_databaseSettings.DatabaseName);
            _collection = db.GetCollection<Question>("questions");
        }   

        public IQuestion Create(IQuestion question)
        {
            _collection.Save(question);
            return question;
        }

        public void Edit(string id, IQuestion question)
        {
            var query = Query.EQ("_id", new ObjectId(id));
            var update = Update<Question>
                .Set(q => q.Text, question.Text)
                .Set(q => q.ImageUrl, question.ImageUrl)
                .Set(q => q.ThumbUrl, question.ThumbUrl)
                .Set(q => q.Choices, question.Choices);
            _collection.Update(query, update);
        }

        public IQuestion GetOne(string id)
        {
            var query = Query.EQ("_id", new ObjectId(id));
            return _collection.FindOne(query);
        }

        public IEnumerable<IQuestion> Get(string filter, int limit, int offset)
        {
            if (filter == null) filter = "";
            var like = new BsonRegularExpression($"/{filter.Replace("?", "\\?")}/i");
            var query = Query.Or(
                Query.Matches("Text", like),
                Query.Matches("Choices.Text", like)
            );
            return _collection
                .Find(query)
                .SetLimit(limit)
                .SetSkip(offset)
                .ToList();
        }

        public void Vote(string id, string choice)
        {
            var query = Query.And(
                Query.EQ("_id", new ObjectId(id)),
                Query.EQ("Choices.Text", choice)
            );
            var update = Update.Inc("Choices.$.Votes", 1);
            _collection.Update(query, update);
        }
    }
}