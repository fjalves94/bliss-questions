using System.Threading.Tasks;
using SendGrid;

namespace Bliss.Questions.API.Interfaces
{
    public interface IShareService
    {
        Task<Response> Share(string content, string email);
    }
}