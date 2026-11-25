using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PetersBilbaseLib
{
	public class CarRepo : ICarRepo
	{
		private List<Car> _cars;
		private int _idOfCar;

		public CarRepo()
		{
			_cars = new List<Car>();
			_idOfCar = 1;
		}

		public CarRepo(List<Car> cars)
		{
			_cars = cars;
			_idOfCar = cars.Count + 1;
		}
		public List<Car> Cars
		{
			get { return _cars; }
			set { _cars = value; }
		}
		public int IdOfCar
		{
			get { return _idOfCar; }
			set { _idOfCar = value; }
		}

		#region Methods

		public Car Create(Car car)
		{
			car.Id = _idOfCar++;
			_cars.Add(car);
			return car;
		}

		public List<Car> ReadAll()
		{
			return new List<Car>(_cars);
		}

		public Car ReadById(int id)
		{

		Car? c = _cars.Find(car => car.Id == id);

		if (c == null)
		throw new KeyNotFoundException($"Car with Id {id} was not found.");

			return c;
			//foreach (Car car in _cars)
			//{
			//	if (car.Id == id)
			//	{
			//		return car;
			//	}
			//}
			//throw new KeyNotFoundException($"Car with Id {id} was not found.");
		}

		public Car Update(int id, Car updatedCar)
		{
			if (updatedCar == null) throw new ArgumentNullException(nameof(updatedCar));
			var v = _cars.Find(car => car.Id == id);
			//foreach (Car v in _cars)
			//{
			//	if (v.Id == id)
			//	{
			// preserve Id and update fields
			updatedCar.Id = id;
					v.Vendor = updatedCar.Vendor;
					v.Model = updatedCar.Model;
					v.Color = updatedCar.Color;
					v.KmDriven = updatedCar.KmDriven;
					v.EngineKind = updatedCar.EngineKind;
					v.EnginePower = updatedCar.EnginePower;
					v.Doors = updatedCar.Doors;
					v.Towbar = updatedCar.Towbar;
					v.Year = updatedCar.Year;
					return v;
				
			}
			//throw new KeyNotFoundException($"Car with Id {id} was not found.");
		

		public Car Delete(int id)
		{
		Car? c = _cars.Find(car => car.Id == id);
		_cars.Remove(c);
			return c;
			//foreach (Car car in _cars)
			//	{ 
			//		if (car.Id == id)
			//		{
			//			_cars.Remove(car);
			//			return car;
			//		}
			//	}
			//	throw new KeyNotFoundException($"Car with Id {id} was not found.");
		}

		public List<Car> SearchByVendor(string vendor)
		{
			List<Car> results = new List<Car>();
			foreach (Car v in _cars)
			{
				if (v.Vendor.Equals(vendor, StringComparison.OrdinalIgnoreCase))
				{
					results.Add(v);
				}
			}
			return results;
		}
		#endregion


	}
}
