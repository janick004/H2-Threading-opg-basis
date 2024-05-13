using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Threading_opg_0
{
	internal class Opgave1
	{
		public void Main()
		{
			ThreadProgram tp = new ThreadProgram();
			Thread thread = new Thread(new ThreadStart(tp.Worker));
			thread.Start();
			Console.ReadLine();
		}
	}

	class ThreadProgram
	{
		//This method performs work on a separate thread than the main one
		public void Worker()
		{
			// Writes 5 lines of "C#-trådning er nemt" in the console
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("C#-trådning er nemt");
			}
		}
	}


}
