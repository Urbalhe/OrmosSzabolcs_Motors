using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors
{
	internal class Statisztika
	{
		List<Motor> motors = [];

		public void ReadFromFile(string fileName)
		{
			StreamReader sr = new StreamReader(fileName);
			sr.ReadLine();

			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine() ?? "";


				string[] szavak = sor.Split(';');

				Motor ujmotor = new(szavak[0], szavak[1], Convert.ToInt16(szavak[2]), Convert.ToDouble(szavak[3]), Convert.ToDouble(szavak[4]));

				motors.Add(ujmotor);
			}

		}

		public int SumPrices()
		{
			double sum = 0;

            for (int i = 0; i < motors.Count; i++)
            {
                sum += motors[i].PriceInEur;
            }

			return (int)sum;
        }
		public bool Contains(string motorName)
		{
			bool isThere = false;

            for (int i = 0; i < motors.Count; i++)
            {
				if (motors[i].Brand == motorName) isThere = true;
            }

			return isThere;
        }

		public Motor Oldest()
		{
			Motor oldestMotor = motors[0];
            for (int i = 0; i < motors.Count; i++)
            {
				if (oldestMotor.ReleaseYear > motors[i].ReleaseYear) oldestMotor = motors[i];
            }

			return oldestMotor;
        }

		public int SumBasedOnBrand(string brandName, string fileName)
		{
			List<Motor> brandMotors = new List<Motor>();

			for (int i = 0; i < motors.Count; i++)
			{
				if (motors[i].Brand == brandName) brandMotors.Add(motors[i]);
			}

			motors = brandMotors;

			int sum = this.SumPrices();

			motors.Clear();
			this.ReadFromFile(fileName);

			return sum;
			

		}

		public void Sort()
		{
			for (int i =  motors.Count; i > 0; i--)
            {
                for (int j = 0; j < motors.Count - 1; j++)
                {
					if (motors[j].Performance > motors[j + 1].Performance)
					{
						Motor temp = motors[j];
						motors[j] = motors[j + 1];
						motors[j + 1] = temp;

						
					}
                }
            }
        }
	}
}
