using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringCalculator
{
	[TestFixture]
	internal class Calculator_Tests
	{
		private Calculator calculator;

		[SetUp]
		public void SetUp()
		{
			calculator = new Calculator();
		}

		private static object[] TestData =
		{
			new object[] { "+ 1 1", 2 },
			new object[] { "- 1 3 4 6", -12 },
			new object[] { "* 5 8 7", 280 },
			new object[] { "/ 8 4", 2 }
		};

		[Test]
		[TestCaseSource("TestData")]
		public void Calculator_AllOperands_Test(string input, int result)
		{
			var _result = calculator.Calculate(input);

			Assert.AreEqual(result, _result);
		}
	}
}