using System.Collections.Generic;

namespace Domain.Entities
{
    public class API
    {


        public class coord
        {
            public decimal lon { get; set; }
            public decimal lat { get; set; }
        }

        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }

            public string icon { get; set; }
        }

        public class main
        {
            public string temp { get; set; }
            public string pressure { get; set; }
            public string humidity { get; set; }
            public string temp_min { get; set; }
            public string temp_max { get; set; }


        }
        public class wind
        {
            public string speed { get; set; }
            public string deg { get; set; }
        }

        public class clouds
        {
            public string all { get; set; }
        }

        public class sys
        {
            public string country { get; set; }
            public int sunrise { get; set; }

            
        }

        public class Root
        {
            public coord coordenadas { get; set; }
            public List<weather> weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }
            public sys sys { get; set; }

            public string name { get; set; }
        }

    }
}
