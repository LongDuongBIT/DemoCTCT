using System.Threading.Tasks;

namespace DemoCTCT.Services
{
    public interface IActivityServices
    {
        Task GetActivity(string mssv);
    }
}