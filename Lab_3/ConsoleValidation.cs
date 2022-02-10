using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_3
{
    /// <summary>
    /// ConsoleValidation class.
    /// </summary>
    public static class ConsoleValidation
    {
        private const string ErrorMessage = "x should be in range 1 < x < p - 1";

        /// <summary>
        /// Validates the x.
        /// </summary>
        /// <param name="inputMessege">The input messege.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        public static int ValidateX(string inputMessege, int minValue = 0, int maxValue = int.MaxValue)
        {
            Console.Write(inputMessege);
            var input = Console.ReadLine();

            if (Validate.IntValidateKey(input))
            {
                var output = int.Parse(input);

                if (!(output >= minValue && output <= maxValue))
                {
                    Console.WriteLine(ErrorMessage);

                    return ValidateX(inputMessege, minValue, maxValue);
                }

                return output;
            }
            else
                return ValidateX(inputMessege, minValue, maxValue);
        }

        /// <summary>
        /// Validates the int.
        /// </summary>
        /// <param name="inputMessege">The input messege.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        public static int ValidateInt(string inputMessege, int minValue = 0, int maxValue = int.MaxValue)
        {
            Console.Write(inputMessege);
            var input = Console.ReadLine();

            if (Validate.IntValidateKey(input))
            {
                var output = int.Parse(input);

                if (!(output >= minValue && output <= maxValue))
                    return ValidateInt(inputMessege, minValue, maxValue);

                return output;
            }
            else
                return ValidateInt(inputMessege, minValue, maxValue);
        }
    }
}
