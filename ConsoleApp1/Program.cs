using PetersBilbaseLib;

// Create a car repository
CarRepo repo = new CarRepo();
// Create 10 cars
Car car1 = new Car { Vendor = "Toyota", Model = "Camry", Color = "Blue", KmDriven = 15000, EngineKind = "Gasoline", EnginePower = 200, Doors = 4, Towbar = false, Year = 2020 };
repo.Create(car1);
Car car2 = new Car { Vendor = "Honda", Model = "Civic", Color = "Red", KmDriven = 25000, EngineKind = "Gasoline", EnginePower = 180, Doors = 2, Towbar = false, Year = 2019 };
repo.Create(car2);
Car car3 = new Car { Vendor = "Ford", Model = "Mustang", Color = "Black", KmDriven = 5000, EngineKind = "Gasoline", EnginePower = 300, Doors = 2, Towbar = false, Year = 2023 };
repo.Create(car3);
Car car4 = new Car { Vendor = "BMW", Model = "X5", Color = "Silver", KmDriven = 35000, EngineKind = "Diesel", EnginePower = 250, Doors = 4, Towbar = true, Year = 2018 };
repo.Create(car4);
Car car5 = new Car { Vendor = "Mercedes-Benz", Model = "C-Class", Color = "White", KmDriven = 45000, EngineKind = "Diesel", EnginePower = 200, Doors = 4, Towbar = false, Year = 2017 };
repo.Create(car5);
Car car6 = new Car { Vendor = "Audi", Model = "A4", Color = "Gray", KmDriven = 55000, EngineKind = "Gasoline", EnginePower = 190, Doors = 4, Towbar = false, Year = 2016 };
repo.Create(car6);
Car car7 = new Car { Vendor = "Volkswagen", Model = "Golf", Color = "Green", KmDriven = 65000, EngineKind = "Gasoline", EnginePower = 150, Doors = 4, Towbar = false, Year = 2015 };
repo.Create(car7);
Car car8 = new Car { Vendor = "Volvo", Model = "XC90", Color = "Bronze", KmDriven = 75000, EngineKind = "Diesel", EnginePower = 235, Doors = 4, Towbar = true, Year = 2014 };
repo.Create(car8);
Car car9 = new Car { Vendor = "Tesla", Model = "Model 3", Color = "Pearl White", KmDriven = 8000, EngineKind = "Electric", EnginePower = 350, Doors = 4, Towbar = false, Year = 2022 };
repo.Create(car9);
Car car10 = new Car { Vendor = "Porsche", Model = "911", Color = "Yellow", KmDriven = 12000, EngineKind = "Gasoline", EnginePower = 380, Doors = 2, Towbar = false, Year = 2021 };
repo.Create(car10);

Func<Car,bool> filter = c => c.EngineKind == "Gasoline" && c.KmDriven < 20000;
Func<Car, bool> filter2 = c => c.Vendor.Contains("T") && c.Year >= 2020;
Func<Car, bool> filter3 = c => c.Towbar == true;
Car_service car_service = new Car_service(repo);
foreach (Car car in (car_service.Search(filter3)))
{
	Console.WriteLine(car);
}