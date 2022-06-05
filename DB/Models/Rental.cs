using System;

namespace ForCar.DB.Models
{
    class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Comments { get; set; }

    }
}
