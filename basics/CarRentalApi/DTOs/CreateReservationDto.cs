namespace CarRentalApi.DTOs
{
    public class CreateReservationDto
    {
        public string CarId { get; set; }  // Araç ID'si
        public string CustomerId { get; set; }  // Müşteri ID'si
        public DateTime StartDate { get; set; }  // Başlangıç Tarihi
        public DateTime EndDate { get; set; }  // Bitiş Tarihi
    }
}
