using System.Threading.Tasks;

namespace AppCore.IServices
{
    public interface IServices<T>
    {
        Task<T> GetWather(string lat, string lon);
        Task<string> GetIcon();


        public Task<T> GetLocal_Location();

        public Task<string> GetIconLocal();

    }
}
