namespace PetersBilbaseLib
{
	public interface ICarRepo
	{
		Car Create(Car car);
		Car Delete(int id);
		List<Car> ReadAll();
		Car ReadById(int id);
		Car Update(int id, Car updatedCar);
	}
}