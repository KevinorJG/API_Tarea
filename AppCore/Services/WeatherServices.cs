using AppCore.IServices;
using Domain.Interfaces;
using System.Threading.Tasks;
using Domain.Entities;

namespace AppCore.Services
{
    public class WeatherServices : IServices<API.Root>
    {
        protected IModel<API.Root> model;

        public WeatherServices(IModel<API.Root> model)
        {
            this.model = model;
        }


        public Task<string> GetIcon()
        {
            return model.GetIcon();
        }

        public Task<string> GetIconLocal()
        {
            return model.GetIconLocal();
        }

        public Task<API.Root> GetLocal_Location()
        {
            return model.GetLocal_Location();
        }

        public Task<API.Root> GetWather(string city)
        {
            return model.GetWather(city);
        }

    }
}
