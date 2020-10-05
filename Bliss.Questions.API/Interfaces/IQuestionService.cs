using System.Collections.Generic;

namespace Bliss.Questions.API.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<IQuestion> Get(string filter, int limit, int offset);
        IQuestion GetOne(string id);
        IQuestion Create(IQuestion question);
        void Edit (IQuestion question);
        void Vote (string questionId, string choice);
    }
}