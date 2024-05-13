using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Threading_opg_0
{
	internal class Opgave4
	{
		public void Main()
		{
			Console.WriteLine("Press ENTER to start...");
			while (Console.ReadKey().Key != ConsoleKey.Enter) ; // Wait for ENTER key press


			// Create instances of the input and output classes
			Input inputHandler = new Input();
			Output outputHandler = new Output(inputHandler);

			// Create and start the threads
			Thread printerThread = new Thread(outputHandler.WriteKey);
			Thread readerThread = new Thread(inputHandler.Readkeys);

			printerThread.Start();
			readerThread.Start();

			// Wait for both threads to finish
			printerThread.Join();
			readerThread.Join();
		}
	}
	class Input
	{
		private char ch = '*';

		public void Readkeys()
		{
			while (true)
			{
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				ch = keyInfo.KeyChar;
			}
		}

		public char GetChar()
		{
			return ch;
		}
	}

	class Output
	{
		private Input inputHandler;

		public Output(Input inputHandler)
		{
			this.inputHandler = inputHandler;
		}

		public void WriteKey()
		{
			while (true)
			{
				char ch = inputHandler.GetChar();
				Console.Write(ch);
				Thread.Sleep(50); // delay to prevent high CPU usage			
			}
		}
	}
}