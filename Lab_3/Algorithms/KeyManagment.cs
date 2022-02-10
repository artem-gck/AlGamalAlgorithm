using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Algorithms
{
	/// <summary>
	/// KeyManagment class.
	/// </summary>
	public static class KeyManagment
    {
        /// <summary>
        /// Gets the simple p.
        /// </summary>
        /// <returns></returns>
        public static int GetSimpleP()
		{
			var rand = new Random();

			var numberOfSimpleNumbers = rand.Next(300, 2000);
			var arrayOfSimpleNumbers = GetSimpleNumbers(257, numberOfSimpleNumbers);

			return arrayOfSimpleNumbers[rand.Next(0, arrayOfSimpleNumbers.Length)];
		}

        /// <summary>
        /// Gets the public key.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">1 < {nameof(x)} < p - 1.</exception>
        public static (int p, int g, int y) GetPublicKey(int p, int x)
        {
			var g = 0;
			var y = 0;

			x = x < p - 1 && x > 1 ? x : throw new ArgumentException($"1 < {nameof(x)} < p - 1.");

            while (y == 0)
            {
                g = Generate(p);
                y = PowMod(g, x, p);
            }

            return (p, g, y);
        }

        /// <summary>
        /// Gets the simple numbers.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        static int[] GetSimpleNumbers(int start, int n)
		{
			var output = new List<int>();

			for (int i = start; i <= n; i++)
				if (isSimple(i))
					output.Add(i);

			return output.ToArray();

			bool isSimple(int n)
			{
				for (var i = 2; i < (int)(n / 2); i++)
				{
					if (n % i == 0)
						return false;
				}

				return true;
			}
		}

        /// <summary>
        /// Pows the mod.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static int PowMod(int a, int b, int p)
		{
			int res = 1;

			while (b != 0)
				if ((b & 1) != 0)
				{
					res = (int)(res * a % p);
					--b;
				}
				else
				{
					a = (int)(a * a % p);
					b >>= 1;
				}

			return res;
		}

        /// <summary>
        /// Generates the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static int Generate(int p)
		{
			var fact = new List<int>();
			var phi = p - 1;
			var n = phi;

			for (var i = 2; i * i <= n; ++i)
				if (n % i == 0)
				{
					fact.Add(i);

					while (n % i == 0)
						n /= i;
				}
			if (n > 1)
				fact.Add(n);

			for (var res = 2; res <= p; ++res)
			{
				var ok = true;

				for (var i = 0; i < fact.Count && ok; ++i)
					ok &= PowMod(res, phi / fact[i], p) != 1;

				if (ok) 
					return res;
			}

			return -1;
		}
	}
}
