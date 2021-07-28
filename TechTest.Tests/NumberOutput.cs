using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TechTest.Tests
{
    public class NumberOutput
    {
        private readonly ITestOutputHelper _output;
        
        public NumberOutput(ITestOutputHelper output)
        {
            _output = output;    
        }

        [Theory]
        [InlineData(5,2,65,6,8,9,0,1)]
        public void SpitOutNumbers(params int[] numbers)
        {
            foreach (var number in numbers.ToList())
            {
                if (number == 0)
                    continue;

                if (number % 2 == 0)
                    _output.WriteLine($"{number} divisable by 2");

                if (number % 5 == 0)
                    _output.WriteLine($"{number} divisable by 5");
            }
        }
    }
}