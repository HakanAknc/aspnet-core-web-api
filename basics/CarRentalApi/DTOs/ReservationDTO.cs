namespace CarRentalApi.DTOs
{
    public class ReservationDTO
    {
        public string Id { get; set; }  // Rezervasyon ID'si
        public string CarId { get; set; }  // Araç ID'si
        public string CustomerId { get; set; }  // Müşteri ID'si
        public DateTime StartDate { get; set; }  // Başlangıç Tarihi
        public DateTime EndDate { get; set; }  // Bitiş Tarihi
        public decimal TotalPrice { get; set; }  // Toplam Fiyat
        public string Status { get; set; }  // Durum (Aktif, Tamamlandı, İptal Edildi vb.)
    }
}
