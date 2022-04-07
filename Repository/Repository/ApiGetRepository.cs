using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Repository.Repository
{
    public class ApiGetRepository : IModel<API.Root>
    {
        protected readonly string Key = "c6dafc6d4ae1a2b99efcf3e99a768d37";
        protected string Url = String.Empty;
        protected string city = String.Empty;

        public string GetIcon()
        {
            try
            {

                return "http://openweathermap.org/img/wn/" + GetWather(city).weather[0].icon + ".png";
            }
            catch (IOException)
            {

                throw;
            }
        }

        public API.Root GetWather(string city)
        {
            try
            {
                this.city = city;
                using (WebClient web = new WebClient())
                {
                    Url = string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + Key + "&lang=es");
                    var Json = web.DownloadString(Url);
                    API.Root info = JsonConvert.DeserializeObject<API.Root>(Json);
                    return info;
                }
            }
            catch (IOException)
            {

                throw;
            }
        }

    }
}
