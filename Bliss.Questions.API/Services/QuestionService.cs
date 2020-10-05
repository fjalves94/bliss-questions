using System;
using System.Collections.Generic;
using Bliss.Questions.API.Interfaces;
using Bliss.Questions.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

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

        public void Edit(IQuestion question)
        {
        }

        public IQuestion GetOne(string id)
        {
            var query = MongoDB.Driver.Builders.Query.EQ("_id", new ObjectId(id));
            return _collection.FindOne(query);
        }

        public IEnumerable<IQuestion> Get(string filter, int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public void Vote(string questionId, string choice)
        {
            throw new NotImplementedException();
        }
    }
}