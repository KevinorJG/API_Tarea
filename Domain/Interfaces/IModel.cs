using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IModel<T>
    {
        Task<T> GetWather(string city);
        Task<string> GetIcon();
        public  Task<T> GetLocal_Location();
        public Task<string> GetIconLocal();

    }
}
