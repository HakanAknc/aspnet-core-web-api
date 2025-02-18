namespace CarProject.DTOs
{
    public class CarDTO
    {
        public class GetCarDto
        {
            public string Id { get; set; } = string.Empty;
            public string Brand { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public int Year { get; set; }
            public string FuelType { get; set; } = string.Empty;
            public bool IsAvailable { get; set; }
            public decimal PricePerDay { get; set; }
            public bool IsActive { get; set; }
        }

        public class CreateCarDto
        {
            public string Brand { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public int Year { get; set; }
            public string FuelType { get; set; } = string.Empty;
            public bool IsAvailable { get; set; }
            public decimal PricePerDay { get; set; }
        }

        public class UpdateCarDto
        {
            public string Brand { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public int Year { get; set; }
            public string FuelType { get; set; } = string.Empty;
            public bool IsAvailable { get; set; }
            public decimal PricePerDay { get; set; }
        }
    }
}
