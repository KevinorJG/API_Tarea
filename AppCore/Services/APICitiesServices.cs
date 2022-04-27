using AppCore.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class APICitiesServices : IAPICitiesServices
    {

        private IAPICitiesServices clientServices;

        public APICitiesServices(IAPICitiesServices clientServices)
        {
            this.clientServices = clientServices;
        }

        public List<City> GetCities(byte[] byteArray)
        {
           return clientServices.GetCities(byteArray);
        }
    }
}
