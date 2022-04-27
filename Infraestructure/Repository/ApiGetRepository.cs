using Common;
using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class ApiGetRepository : IModel<API.Root>,IAPICities
    {
        protected string Url = String.Empty;
        protected string city = String.Empty;

        public async Task<string> GetIcon()
        {
            try
            {

                return await Task.FromResult($"{AppSettings.ApiIcons}{GetWather(city).Result.weather[0].icon}{".png"}");
            }
            catch (IOException)
            {

                throw new NullReferenceException("No se puedo obtener la información de los iconos");
            }
        }

        public async Task<API.Root> GetWather(string city)
        {
            try
            {
                this.city = city;
                using (WebClient web = new WebClient())
                {
                    Url = string.Format($"{AppSettings.ApiUrl}{city}&appid={ AppSettings.Token}&lang=es");
                    var Json = web.DownloadString(Url);
                    API.Root info = JsonConvert.DeserializeObject<API.Root>(Json);
                    return await Task.FromResult(info);
                }
            }
            catch (IOException)
            {

                throw new NullReferenceException("No se puedo obtener la información");
            }
        }

        public async Task<API.Root> GetLocal_Location()
        {
            RegionInfo Country = new RegionInfo("NI");
            return await GetWather(Country.DisplayName);
        }
        public async Task<string> GetIconLocal()
        {
            return await GetIcon();
        }

        public List<APICities> GetCities(byte[] byteArray)
        {
            string json = Encoding.UTF8.GetString(byteArray);
            return JsonConvert.DeserializeObject<List<APICities>>(json);
        }

        //public List<OpenWeatherCities> GetCities()
        //{
        //    //List<OpenWeatherCities> cities;
        //    //using (StreamReader file = File.OpenText(AppSettings.Cities))
        //    //{
        //    //    JsonSerializer serializer = new JsonSerializer();
        //    //    cities = (List<OpenWeatherCities>)serializer.Deserialize(file, typeof(List<OpenWeather>));
        //    //}
        //    //return cities;

        //    List<OpenWeatherCities> cities = JsonConvert.DeserializeObject<List<OpenWeatherCities>>(File.ReadAllText(AppSettings.Cities));
        //    return cities;
        //}
    }
}
