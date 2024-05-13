using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Threading_opg_0
{
	internal class Opgave3
	{
		public void Main()
		{
			// Create an instance of TemperatureGenerator
			TemperatureGenerator temperatureGenerator = new TemperatureGenerator();
			temperatureGenerator.Start();
			Timer checkThreadTimer = new Timer(CheckThreadStatus, temperatureGenerator, TimeSpan.Zero, TimeSpan.FromSeconds(10));

			temperatureGenerator.Stop();
			checkThreadTimer.Dispose();


			// Waits for user input to exit the program
			Console.ReadLine();
		}
		static void CheckThreadStatus(object state)
		{
			TemperatureGenerator temperatureGenerator = (TemperatureGenerator)state;
			if (!temperatureGenerator.IsAlive)
			{
				// Display a message indicating the termination of the alarm thread
				Console.WriteLine("Alarm-tråd termineret!");
			}
		}
	}

	// Class responsible for generating temperature readings
	class TemperatureGenerator
	{
		private Thread? thread;
		private int alarmCount = 0;
		private bool isAlive = true;

		// Starts generating temperatures
		public void Start()
		{
			thread = new Thread(GenerateTemperature);
			thread.Start();
		}
		// Stops generating temperatures
		public void Stop()
		{
			thread.Join();
		}

		private void GenerateTemperature()
		{
			Random rnd = new Random();
			int alarmThreshold = 3;
			while (alarmCount < alarmThreshold)
			{
				int temperature = rnd.Next(-20, 121);
                Console.WriteLine($"Temperatur: {temperature} C");
				if (temperature < 0 || temperature > 100)
				{
                    Console.WriteLine(" - ULOVLIG TEMPERATUR");
					alarmCount++;
                }
				else
				{
                    Console.WriteLine(); // Empty line for readability
				}
				// Pause for 2 seconds
				Thread.Sleep(2000);
            }

			Console.WriteLine("Alarm-tråd termineret!");
			isAlive = false;
		}

		// Property to get the status of the thread
		public bool IsAlive
		{
			get { return isAlive; }
		}
	}
}
