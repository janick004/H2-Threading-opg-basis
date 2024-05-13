using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Threading_opg_0
{
	internal class Opgave0
	{
		/*
		 * This method performs work on a separate thread than the main one
		*/
		public void WorkThreadFunction()
		{
			// writes 5 lines of "Simple Thread" in the console
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("Simple Thread");
			}
		}
	}

	class threprog // "ThreadProgram"
	{

		public void Main()
		{
			Opgave0 pg = new Opgave0(); // Creates an object of the class
			Thread thread = new Thread(new ThreadStart(pg.WorkThreadFunction));
			thread.Start(); // starts the thread
			Console.Read(); // Prevents the program from stopping/closing
		}
	}
}
