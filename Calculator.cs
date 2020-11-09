using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
	public class Calculator
	{
		private List<string> _availableOperators = new List<string>() { "+", "-", "*", "/" };

		public int Calculate(string numbers)
		{
			if (string.IsNullOrEmpty(numbers))
			{
				throw new FormatException("String null or empty.");
			}

			var split = numbers.Split(' ');

			if (split.Length < 3)
			{
				throw new FormatException("String contains less than 3 members.");
			}

			var operatorSign = split[0];

			if (!_availableOperators.Contains(operatorSign))
			{
				throw new FormatException("Invalid operator.");
			}

			var allNumbers = ExtractNumbers(split);

			return GetCalculatorOutput(allNumbers, operatorSign);
		}

		private int GetCalculatorOutput(List<int> numbers, string operatorSign)
		{
			var firstNumber = numbers[0];

			for (int i = 1; i < numbers.Count; i++)
			{
				switch (operatorSign)
				{
					case "+": firstNumber += numbers[i]; break;
					case "-": firstNumber -= numbers[i]; break;
					case "*": firstNumber *= numbers[i]; break;
					case "/": firstNumber /= numbers[i]; break;
				}
			}

			return firstNumber;
		}

		private List<int> ExtractNumbers(string[] numbers)
		{
			var allNumbers = new List<int>();
			int number;

			for (int i = 1; i < numbers.Length; i++)
			{
				if (!int.TryParse(numbers[i], out number))
				{
					throw new FormatException("Input was not a number.");
				}

				allNumbers.Add(number);
			}

			return allNumbers;
		}
	}
}