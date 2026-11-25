using System.Diagnostics.SymbolStore;
using PetersBilbaseLib;

namespace TestPetersBilbaseLib
{
	public class UnitTest1
	{

		[Fact]
		public void TestCreateCar()
		{
			// arrange
			ICarRepo carRepo = new CarRepo();
			Car car = new Car
			{
				Vendor = "Toyota",
				Model = "Corolla",
				Color = "Red",
				KmDriven = 10000,
				EngineKind = "Petrol",
				EnginePower = 130,
				Doors = 4,
				Towbar = false,
				Year = 2020
			};

			int expectedNoOfCars = 1;
			int expectedIdOfCar = 1;
			// act
			Car newCar = carRepo.Create(car);
			// assert
			Assert.Equal(expectedNoOfCars, carRepo.ReadAll().Count);
			Assert.Equal(expectedIdOfCar, newCar.Id);
		}

		[Fact]
		public void TestReadAll()
		{
			ICarRepo carRepo = new CarRepo();
			Car car = new Car()
			{
				Vendor = "Kia",
				Model = "Ceed",
				Color = "Black",
				KmDriven = 15000,
				EngineKind = "Diesel",
				EnginePower = 140,
				Doors = 5,
				Towbar = true,
				Year = 2019,
			};
			Car car2 = new Car()
			{
				Vendor = "Honda",
				Model = "Civic",
				Color = "Blue",
				KmDriven = 20000,
				EngineKind = "Petrol",
				EnginePower = 160,
				Doors = 4,
				Towbar = false,
				Year = 2018,
			};
			int expectedNoOfCars = 1;

			carRepo.Create(car);
			carRepo.Create(car2);
			Assert.NotEqual(expectedNoOfCars, carRepo.ReadAll().Count); // note the NotEqual assertion, since we expect 2 cars in the repo, not 1



		}

		[Fact]
		public void TestReadById()
		{
			// arrange
			ICarRepo carRepo = new CarRepo();
			Car car = new Car
			{
				Vendor = "Ford",
				Model = "Puma",
				Color = "Red",
				KmDriven = 10500,
				EngineKind = "Petrol",
				EnginePower = 230,
				Doors = 4,
				Towbar = false,
				Year = 2020
			};
			carRepo.Create(car);
			int expectedIdToRead = 1;
			// act
			Car readCar = carRepo.ReadById(expectedIdToRead);
			// assert
			Assert.Equal(expectedIdToRead, readCar.Id);
		}


		[Fact]
		public void TestUpdateCar()
		{
			// arrange
			ICarRepo carRepo = new CarRepo();
			Car car = new Car
			{
				Vendor = "Ford",
				Model = "Puma",
				Color = "grey",
				KmDriven = 10500,
				EngineKind = "Petrol",
				EnginePower = 230,
				Doors = 4,
				Towbar = false,
				Year = 2020
			};
			carRepo.Create(car);
			int idToUpdate = 1;
			Car updatedCar = new Car
			{
				Vendor = "Ford",
				Model = "Puma",
				Color = "Blue",
				KmDriven = 12000,
				EngineKind = "Petrol",
				EnginePower = 230,
				Doors = 4,
				Towbar = true,
				Year = 2021
			};
			// act
			carRepo.Update(idToUpdate, updatedCar);
			Car readUpdatedCar = carRepo.ReadById(idToUpdate);
			// assert
			Assert.Equal("Blue", readUpdatedCar.Color);
			Assert.Equal(12000, readUpdatedCar.KmDriven);
			Assert.True(readUpdatedCar.Towbar);
			Assert.Equal(2021, readUpdatedCar.Year);
		}

		[Fact]
		public void TestDeleteCar()
		{
			// arrange
			ICarRepo carRepo = new CarRepo();
			Car car = new Car
			{
				Vendor = "Ford",
				Model = "Puma",
				Color = "grey",
				KmDriven = 10500,
				EngineKind = "Petrol",
				EnginePower = 230,
				Doors = 4,
				Towbar = false,
				Year = 2020
			};
			carRepo.Create(car);
			int idToDelete = 1;
			int expectedNoOfCarsAfterDelete = 0;
			// act
			carRepo.Delete(idToDelete);
			int actualNoOfCarsAfterDelete = carRepo.ReadAll().Count;
			// assert
			Assert.Equal(expectedNoOfCarsAfterDelete, actualNoOfCarsAfterDelete);
		}

		[Fact]
		public void TestNewestCar()
		{
			// arrange
			ICarRepo carRepo = new CarRepo();

			Car car1 = new Car { Vendor = "Toyota", Model = "Camry", Color = "Blue", KmDriven = 15000, EngineKind = "Gasoline", EnginePower = 200, Doors = 4, Towbar = false, Year = 2020 };
			carRepo.Create(car1);
			Car car2 = new Car { Vendor = "Honda", Model = "Civic", Color = "Red", KmDriven = 25000, EngineKind = "Gasoline", EnginePower = 180, Doors = 2, Towbar = false, Year = 2019 };
			carRepo.Create(car2);
			Car car3 = new Car { Vendor = "Ford", Model = "Mustang", Color = "Black", KmDriven = 5000, EngineKind = "Gasoline", EnginePower = 300, Doors = 2, Towbar = false, Year = 2023 };
			carRepo.Create(car3);

			int expNewestCarYear = 2023;
			Car_service car_service = new Car_service(carRepo);

			Car Newcar = car_service.NewestCar();

			Assert.Equal(expNewestCarYear, Newcar.Year);
			Assert.Equal(car3, Newcar);
		}

		[Fact]
		public void TestShortestDrivenCar()
		{
			// arrange
			ICarRepo carRepo = new CarRepo();

			Car car1 = new Car { Vendor = "Toyota", Model = "Camry", Color = "Blue", KmDriven = 15000, EngineKind = "Gasoline", EnginePower = 200, Doors = 4, Towbar = false, Year = 2020 };
			carRepo.Create(car1);
			Car car2 = new Car { Vendor = "Honda", Model = "Civic", Color = "Red", KmDriven = 25000, EngineKind = "Gasoline", EnginePower = 180, Doors = 2, Towbar = false, Year = 2019 };
			carRepo.Create(car2);
			Car car3 = new Car { Vendor = "Ford", Model = "Mustang", Color = "Black", KmDriven = 5000, EngineKind = "Gasoline", EnginePower = 300, Doors = 2, Towbar = false, Year = 2023 };
			carRepo.Create(car3);

			int expShortestDrivenCarKmDriven = 5000;
			Car_service car_service = new Car_service(carRepo);
			Car ShortestDrivenCar = car_service.shortesDriven();
			Assert.Equal(expShortestDrivenCarKmDriven, ShortestDrivenCar.KmDriven);	
		}


		[Fact]
		public void TestAverageDrivenCar()
		{
			// arrange
			ICarRepo carRepo = new CarRepo();
			Car car1 = new Car { Vendor = "Toyota", Model = "Camry", Color = "Blue", KmDriven = 15000, EngineKind = "Gasoline", EnginePower = 200, Doors = 4, Towbar = false, Year = 2020 };
			carRepo.Create(car1);
			Car car2 = new Car { Vendor = "Honda", Model = "Civic", Color = "Red", KmDriven = 25000, EngineKind = "Gasoline", EnginePower = 180, Doors = 2, Towbar = false, Year = 2019 };
			carRepo.Create(car2);
			Car car3 = new Car { Vendor = "Ford", Model = "Mustang", Color = "Black", KmDriven = 5000, EngineKind = "Gasoline", EnginePower = 300, Doors = 2, Towbar = false, Year = 2023 };
			carRepo.Create(car3);
			double expAverageDrivenCarKmDriven = 15000; //(15000 + 25000 + 5000) / 3.0;
			Car_service car_service = new Car_service(carRepo);

			double AverageDrivenCarKmDriven = car_service.AverageDriven();

			Assert.Equal(expAverageDrivenCarKmDriven, AverageDrivenCarKmDriven);
		}
	}
}
