using Lab_3.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    /// <summary>
    /// AlgorithmsMethods class.
    /// </summary>
    public static class AlgorithmsMethods
    {
        private const string CryptChoose = "1. Get key\n2. Encrypt\n3. Decrypt";
        private const string Choice = "Input your choise: ";
        private const string Key = "Input secure key: ";
        private const string P = "Input p part of key: ";
        private const string G = "Input g part of key: ";
        private const string Y = "Input y part of key: ";
        private const string InputPath = "Input path to input file: ";
        private const string OutputPath = "Input path to output file: ";

        /// <summary>
        /// AlGamal method.
        /// </summary>
        /// <returns></returns>
        public static bool AlGamal()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 3);

            switch (choose)
            {
                case 1:
                    var p = KeyManagment.GetSimpleP();
                    Console.WriteLine($"p = {p}");

                    var x = ConsoleValidation.ValidateX(Key, 1, p - 1);
                    var key = KeyManagment.GetPublicKey(p, x);

                    Console.WriteLine($"Public key: (p = {key.p}, g = {key.g}, y = {key.y})");
                    Console.WriteLine($"Private key: ({x})");

                    return true;

                    break;

                case 2:

                    Console.Write(InputPath);
                    var inputPath = Console.ReadLine();
                    Console.Write(OutputPath);
                    var outputPath = Console.ReadLine();

                    p = ConsoleValidation.ValidateInt(P, 0, int.MaxValue);
                    var g = ConsoleValidation.ValidateInt(G, 0, int.MaxValue);
                    var y = ConsoleValidation.ValidateInt(Y, 0, int.MaxValue);

                    return FileWorker.EncryptFile(inputPath, outputPath, (p, g, y));

                    break;

                case 3:

                    Console.Write(InputPath);
                    inputPath = Console.ReadLine();
                    Console.Write(OutputPath);
                    outputPath = Console.ReadLine();

                    p = ConsoleValidation.ValidateInt(P, 0, int.MaxValue);
                    x = ConsoleValidation.ValidateInt(Key, 0, int.MaxValue);

                    return FileWorker.DecryptFile(inputPath, outputPath, p, x);

                    break;

                default:
                    return false;
            }
        }
    }
}
