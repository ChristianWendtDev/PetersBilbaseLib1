namespace PetersBilbaseLib
{
	public class Car
	{
		public int Id { get; set; }
		public string Vendor { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }
		public int KmDriven { get; set; }
		public string EngineKind { get; set; }
		public int EnginePower { get; set; }
		public int Doors { get; set; }
		public bool Towbar { get; set; }
		public int Year { get; set; }

	

	public override string ToString()
		{
			return $"Id: {Id}, Vendor: {Vendor}, Model: {Model}, Color: {Color}, KmDriven: {KmDriven}, EngineKind: {EngineKind}, EnginePower: {EnginePower}, Doors: {Doors}, Towbar: {Towbar}, Year: {Year}";
		}
	} 
}
