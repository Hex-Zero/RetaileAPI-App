using RetailDesktopUI.Models;
using System.Threading.Tasks;

namespace RetailDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}