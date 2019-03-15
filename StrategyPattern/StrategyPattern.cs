using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Code;

namespace StrategyPattern
{
	// This is a super basic simple strategy pattern with a Switch statement
	class StrategyPattern
	{
		private static int Add(int a, int b) => a + b;

		private static int Subtract(int a, int b) => a - b;

		private static int Multiply(int a, int b) => a * b;

		private static int Divide(int a, int b) => a / b;

		static void DoTheSwitch()
		{
			string add = "+";
			string subtract = "-";
			string multiply = "*";
			string divide = "/";

			var numOne = 2;
			var numTwo = 3;

			int result;

			string userChoice = subtract;

			switch (userChoice)
			{
				case "+":
					result = Add(numOne, numTwo);
					Console.WriteLine(result);
					break;
				case "-":
					result = Subtract(numOne, numTwo);
					Console.WriteLine(result);
					break;
				case "*":
					result = Multiply(numOne, numTwo);
					Console.WriteLine(result);
					break;
				case "/":
					result = Divide(numOne, numTwo);
					Console.WriteLine(result);
					break;

			}

		}



		// This is the strategy pattern with a Dictionary
		static void UseTheDictionary()
		{
			// The Func passed into the dictionary has to have 3 "int" params, but only uses 2 - why???
			Dictionary<string, Func<int, int, int>> strategies = new Dictionary<string, Func<int, int, int>>() {
				{ "+", Add },
				{ "-", Subtract },
				{ "*", Multiply },
				{ "/", Divide }
			};

			string add = "+";
			string subtract = "-";
			string multiply = "*";
			string divide = "/";

			var numOne = 2;
			var numTwo = 3;

			string userChoice = add;


			Func<int, int, int> selectedStrategy = strategies[userChoice];
			int result = selectedStrategy(numOne, numTwo);

			Console.WriteLine(result);
		}


		// This implements Interfaces which are stored in the "Code" folder referenced above
		static void UseInterfaces()
		{
			string add = "+";
			string subtract = "-";
			string multiply = "*";
			string divide = "/";

			var numOne = 2;
			var numTwo = 3;

			string userChoice = add;

			Dictionary<string, IMathOperator> strategies = new Dictionary<string, IMathOperator>() {
				{ "+", new MathAdd() },
				{ "-", new MathSubtract() },
				{ "*", new MathMultiply() },
				{ "/", new MathDivide() }
			};

			IMathOperator selectedStrategy = strategies[userChoice];
			int result = selectedStrategy.Operation(numOne, numTwo);

			Console.WriteLine(result);
		}


		// Main method that kicks off the app - put different Strategy patterns in here to test
		static void Main(string[] args)
		{
			// First try DoTheSwitch()
			//DoTheSwitch();

			// Now try a Dictionary
			//UseTheDictionary();

			// Finally use an interface
			UseInterfaces();
			
		}
	}
}
