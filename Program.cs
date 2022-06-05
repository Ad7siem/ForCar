using ForCar.DB;
using System;
using System.Linq;
using ForCar.DB.Models;

namespace ForCar
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new CarRentalRepository();
            bool start = true;

            while (start)
            {
                Console.WriteLine("Witam w wypożyczalni samochodów.\n" +
                    " - 1 - Mew Car/Driver/Rental\n" +
                    " - 2 - Display list of Car/Drivers/Rentals\n" +
                    " - 3 - Remove Car/Driver\n" +
                    " - 0 - Quit");
                var option = "";
                option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("- 1 - New Car\n- 2 - New Driver\n- 3 - New Rental\n- 0 - Back");
                    option = Console.ReadLine();
                    if (option == "1")
                    {
                        Console.WriteLine("Enter make of the car:");
                        string make = Console.ReadLine();
                        Console.WriteLine("Enter the car model:");
                        string model = Console.ReadLine();
                        Console.WriteLine("Enter the registration number of the car:");
                        string regnumb = Console.ReadLine();
                        repo.NewCar(make, model, regnumb);
                    }
                    else if (option == "2")
                    {
                        Console.WriteLine("Enter the driver's name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the driver's surname:");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Enter the driver's email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter the driver's phone number:");
                        string pnumb = Console.ReadLine();
                        repo.NewDriver(name, surname, email, pnumb);
                    }
                    else if (option == "3")
                    {
                        Console.WriteLine("Drivers name:");
                        string name = Console.ReadLine();
                        int nameId = repo.SearchIdDriver(name).Id;
                        Console.WriteLine("Car make:");
                        string make = Console.ReadLine();
                        int makeId = repo.SearchIdCar(make).Id;
                        var rentDate = DateTime.Now;
                        DateTime returnDate = new DateTime(2000, 1, 1, 0, 0, 0);
                        Console.WriteLine("Comment:");
                        string comments = Console.ReadLine();
                        repo.NewRental(nameId, makeId, rentDate, returnDate, comments);
                    }
                    else if (option == "0") { }
                }

                else if (option == "2")
                {
                    Console.WriteLine("- 1 - Display list of the cars\n- 2 - Display list of drivers\n- 3 - Display list of the rentals\n- 0 - Back");
                    option = Console.ReadLine();

                    if (option == "1")
                    {
                        var listCars = repo.GetCars().ToList();
                        foreach (var item in listCars)
                        {
                            Console.WriteLine($"ID: {item.Id}, Make: {item.Make}, Model: {item.Model}, Number registration: {item.RegistrationNumber}\n");

                        }
                    }
                    else if (option == "2")
                    {
                        var listDrivers = repo.GetDrivers().ToList();
                        foreach (var item in listDrivers)
                        {
                            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Email: {item.Email}, Number Phtone: {item.PhoneNumber}\n");
                        }
                    }
                    else if (option == "3")
                    {
                        var listRentals = repo.GetRentals().ToList();
                        foreach (var item in listRentals)
                        {
                            Console.WriteLine($"ID: {item.Id}, Car ID: {item.CarId}, Driver ID: {item.DriverId}, Date Rent: {item.RentDate}, Date Return: {item.ReturnDate}, Comment: {item.Comments}\n");
                        }
                    }
                    else if (option == "0") { }
                }
                else if (option == "3")
                {
                    Console.WriteLine("- 1 - Remove Car\n- 2 - Remove Driver\n- 0 - Back");
                    option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.WriteLine("Enter the car ID to removed");

                        var removeCar = Console.ReadLine();
                        repo.RemoveCar(Int32.Parse(removeCar));
                    }
                    else if (option == "2")
                    {
                        Console.WriteLine("Enter the driver ID to removed");

                        var removeDriver = Console.ReadLine();
                        repo.RemoveDriver(Int32.Parse(removeDriver));
                    }
                    else if (option == "0") { }
                }
                else if (option == "0")
                {
                    start = false;
                }
            }
        }
    }
}
