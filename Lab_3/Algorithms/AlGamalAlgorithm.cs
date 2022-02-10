using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Algorithms
{
	/// <summary>
	/// AlGamalAlgorithm class.
	/// </summary>
	public static class AlGamalAlgorithm
    {
        /// <summary>
        /// Encrypts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static (int a, int b) Encrypt(int input, (int p, int g, int y) key)
		{
			var rand = new Random();

			var k = rand.Next() % (key.p - 2) + 1;

			var a = PowMod(key.g, k, key.p);
			var b = MulMod(PowMod(key.y, k, key.p), input, key.p);

			return (a, b);
        }

        /// <summary>
        /// Decrypts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="p">The p.</param>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public static int Decrypt((int a, int b) input, int p, int x)
			=> MulMod(input.b, PowMod(input.a, p - 1 - x, p), p);

        /// <summary>
        /// Pows the mod.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static int PowMod(int a, int b, int p)
		{
			var res = 1;

			while (b != 0)
				if ((b & 1) != 0)
				{
					res = res * a % p;
					--b;
				}
				else
				{
					a = a * a % p;
					b >>= 1;
				}

			return res;
		}

        /// <summary>
        /// Muls the mod.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        private static int MulMod(int a, int b, int n)
		{
			var sum = 0;

			for (int i = 0; i < b; i++)
			{
				sum += a;
				if (sum >= n)
				{
					sum -= n;
				}
			}
			return sum;
		}
	}
}
