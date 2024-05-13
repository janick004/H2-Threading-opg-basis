using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Threading_opg_0
{
	internal class Opgave2
	{
		public void Main()
		{
			ThreadTasks tp = new ThreadTasks();
			Thread thread1 = new Thread(new ThreadStart(tp.WriteEasily));
			Thread thread2 = new Thread(new ThreadStart(tp.WriteMoreThreads));
			thread1.Start();
			thread2.Start();
			Console.ReadLine();
		}
	}
	/// <summary>
	/// This class performs work on a separate thread than the main one
	/// </summary>
	class ThreadTasks
	{
		public void WriteEasily()
		{
			// Writes 5 lines of "C#-trådning er nemt" in the console
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("C#-trådning er nemt");
				Thread.Sleep(1000);
			}
		}

		public void WriteMoreThreads()
		{
			// Writes 5 lines of "Også med flere tråde …" in the console
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("Også med flere tråde …");
				Thread.Sleep(1000);
			}
		}
	}
}
