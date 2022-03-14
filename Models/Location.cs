namespace TBS.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string ip { get; set; }

        public string country_code { get; set; }

        public string country_name { get; set; }

        public string region_code { get; set; }


        public string region_name { get; set; }
        public string city { get; set; }

        public int zip_code { get; set; }
        public string time_zone { get; set; }
        public float latitude { get; set; }

        public float longitude { get; set; }

        public int metro_code { get; set; }

        
    }
}
