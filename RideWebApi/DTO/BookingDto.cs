namespace RideWebApi.DTO
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        //public DateTime startDate { get; set; }
        //  public DateTime endDate { get; set; } = DateTime.Now;
        public string car { get; set; }
        public string cartype { get; set; }
   
    }
}