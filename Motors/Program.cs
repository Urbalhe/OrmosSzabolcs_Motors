namespace Motors
{
	internal class Program
	{
		static void Main(string[] args)
		{
			

			Statisztika stat = new Statisztika();
			stat.ReadFromFile("motors.txt");

			Console.WriteLine($"A motorok árainak összege:   {stat.SumPrices()}Eur. ");
            Console.WriteLine();


            Console.WriteLine("Kérem adjon meg egy márkát: ");

			string brand = Console.ReadLine();

			if (stat.Contains(brand))
			{
				Console.WriteLine("Van ilyen motor. "); 
			}

			else
			{
				Console.WriteLine("Nincs ilyen motor. "); 
			}
            
			Console.WriteLine();


            Console.WriteLine($"A legöregebb motor: {stat.Oldest().Name} típusú motor. ");

			Console.WriteLine();
            
            Console.WriteLine($"Yamaha motorok árai összesen: {stat.SumBasedOnBrand("Yamaha","Motors.txt")}");

        }
	}
}
