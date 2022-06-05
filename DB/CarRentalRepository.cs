using ForCar.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForCar.DB
{
    class CarRentalRepository
    {
        private CarRentalContext _context;

        public CarRentalRepository()
        {
            _context = new CarRentalContext();
        }

        public Car GetCars(int id)
        {
            return _context.Cars.SingleOrDefault(x => x.Id == id);
        }

        public Driver GetDrivers(int id)
        {
            return _context.Drivers.SingleOrDefault(x => x.Id == id);
        }

        public Rental GetRentals(int id)
        {
            return _context.Rentals.SingleOrDefault(x => x.Id == id);
        }

        public Car SearchIdCar(string make)
        {
            var searchCar = _context.Cars.FirstOrDefault(x => x.Make == make);
            return searchCar;
        }
        public Driver SearchIdDriver(string name)
        {
            var searchDriver = _context.Drivers.FirstOrDefault(x => x.Name == name);
            if (searchDriver == null)
            {
                Console.WriteLine("Nie ma takiego imienia. Podaj istniejące");
                name = Console.ReadLine();
                SearchIdDriver(name);
            }

            return searchDriver;
        }
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers.ToList();
        }
        public IEnumerable<Rental> GetRentals()
        {
            return _context.Rentals.ToList();
        }

        public void NewCar(string make, string model, string regnumb)
        {
            var newCar = new Car
            {
                Make = make,
                Model = model,
                RegistrationNumber = regnumb
            };
            AddCar(newCar);
        }
        public void NewDriver(string name, string surname, string email, string pnumb)
        {
            var newDriver = new Driver
            {
                Name = name,
                Surname = surname,
                Email = email,
                PhoneNumber = pnumb
            };
            AddDriver(newDriver);
        }

        public void NewRental(int carId, int driverId, DateTime rentDate, DateTime returnDate, string comments)
        {
            var newRental = new Rental
            {
                CarId = carId,
                DriverId = driverId,
                RentDate = rentDate,
                ReturnDate = returnDate,
                Comments = comments
            };
            AddRental(newRental);
        }

        public int AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car.Id;
        }

        public int AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return driver.Id;
        }

        public int AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            return rental.Id;
        }

        public void RemoveCar(int id)
        {
            _context.Cars.Remove(new Car { Id = id });
            _context.SaveChanges();
        }

        public void RemoveDriver(int id)
        {
            _context.Drivers.Remove(new Driver { Id = id });
            _context.SaveChanges();
        }
    }
}
