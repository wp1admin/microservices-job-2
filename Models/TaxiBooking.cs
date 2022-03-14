namespace TBS.Models
{
    public class TaxiBooking
    {
        public long Id { get; set; }
     //   public DateOnly DateOnly { get; set; }

     //   public TimeOnly TimeOnly { get; set; }

        public DateTime DateTime { get; set; }

        public String? PickupPoint { get; set; }

        public String? Destination { get; set; }

        public float Current_Location_Latitude { get; set; }

        public float Current_Location_Longitude { get; set; }
    }
}
