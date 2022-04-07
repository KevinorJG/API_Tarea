using AppCore.IServices;
using Domain.Interfaces;
using static Domain.Entities.API;

namespace AppCore.Services
{
    public class WeatherServices : IServices<Root>
    {
        protected IModel<Root> model;

        public WeatherServices(IModel<Root> root)
        {
            this.model = root;
        }

        public string GetIcon()
        {
            return model.GetIcon();
        }

        public Root GetWather(string city)
        {
            return model.GetWather(city);
        }

    }
}
