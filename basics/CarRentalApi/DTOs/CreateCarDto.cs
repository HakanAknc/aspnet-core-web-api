namespace CarRentalApi.DTOs
{
    public class CreateCarDto
    {
        public string Id { get; set; }  // Araç ID'si
        public string Brand { get; set; }  // Marka
        public string Model { get; set; }  // Model
        public int Year { get; set; }  // Yıl
        public decimal DailyPrice { get; set; }  // Günlük Fiyat
    }
}
