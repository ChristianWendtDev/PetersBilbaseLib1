using System;
using System.Collections.Generic;
using System.Text;

namespace PetersBilbaseLib
{
	public class Car_service
	{
		private readonly ICarRepo _repo;
	

		public Car_service(CarRepo repo)
		{
			_repo = repo;
		}

		public Car_service(ICarRepo carRepo)
		{
			_repo = carRepo;
		}

		public List<Car> Search(Func<Car, bool> filter)
		{

		return (from car in _repo.ReadAll()
				where filter(car)
				select car).ToList();


			//List<Car> biler = new List<Car>();

			//foreach (var car in _repo.ReadAll())
			//{
			//	if (filter(car))
			//	{
			//		biler.Add(car);
			//	}
			//}
			//return biler;
		}

		public Car? NewestCar()
		{
			int newest = 1000;
			Car carFound = new Car();
			carFound.Year = newest;
			foreach (Car car in _repo.ReadAll())
			{
				if (car.Year > carFound.Year)
					carFound = car;
			}
			return carFound;
			//var cars = _repo.ReadAll();
			//if (cars == null || cars.Count == 0)
			//	return null;

			//Car newest = cars[0];
			//foreach (var car in cars)
			//{
			//	if (car.Year > newest.Year)
			//		newest = car;
			//}
			//return newest;
		}

		public Car shortesDriven()
		{
			Car carFound = _repo.ReadAll()[0];
			foreach (Car car in _repo.ReadAll())
			{
				if (car.KmDriven < carFound.KmDriven)
					carFound = car;
			}
			return carFound;
		}

		public int AverageDriven()
		{
		 int sum = 0;
		 foreach (Car car in _repo.ReadAll())
			{
				sum += car.KmDriven;
			}
			return sum / _repo.ReadAll().Count;

		}
	}
}
