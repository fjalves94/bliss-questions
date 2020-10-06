using System.Collections.Generic;

namespace Bliss.Questions.API.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<IQuestion> Get(string filter, int limit, int offset);
        IQuestion GetOne(string id);
        IQuestion Create(IQuestion question);
        void Edit (string id, IQuestion question);
        void Vote (string id, string choice);
    }
}