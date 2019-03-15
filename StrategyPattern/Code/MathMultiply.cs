using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Code
{
	public class MathMultiply : IMathOperator
	{
		public int Operation(int a, int b)
		{
			return a * b;
		}
	}
}
