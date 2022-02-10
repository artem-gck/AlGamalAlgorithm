using Lab_3.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    /// <summary>
    /// FileWorker class.
    /// </summary>
    public static class FileWorker
    {
        private const int SizeOfAlphabet = 26;
        private const char FirstLetterOfAlphabetSmall = 'a';
        private const char FirstLetterOfAlphabetBig = 'A';

        /// <summary>
        /// Encrypts the file.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="outputPath">The output path.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool EncryptFile(string inputPath, string outputPath, (int p, int g, int y) key)
        {
            var alphabetsSmall = Enumerable.Range(FirstLetterOfAlphabetSmall, SizeOfAlphabet).Select(num => (char)num);
            var alphabetsBig = Enumerable.Range(FirstLetterOfAlphabetBig, SizeOfAlphabet).Select(num => (char)num);
            var alphabets = alphabetsSmall.Concat(alphabetsBig).ToList();

            try
            {
                using var streamReader = new StreamReader(new FileStream(inputPath, FileMode.Open));
                using var streamWriter = new StreamWriter(new FileStream(outputPath, FileMode.Create));

                while (streamReader.Peek() != -1)
                {
                    var b = (char)streamReader.Read();
                    var index = alphabets.IndexOf(b);
                    var answer = AlGamalAlgorithm.Encrypt(index, key);
                    streamWriter.Write((char)answer.a);
                    streamWriter.Write((char)answer.b);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="outputPath">The output path.</param>
        /// <param name="p">The p.</param>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public static bool DecryptFile(string inputPath, string outputPath, int p, int x)
        {
            var alphabetsSmall = Enumerable.Range(FirstLetterOfAlphabetSmall, SizeOfAlphabet).Select(num => (char)num);
            var alphabetsBig = Enumerable.Range(FirstLetterOfAlphabetBig, SizeOfAlphabet).Select(num => (char)num);
            var alphabets = alphabetsSmall.Concat(alphabetsBig).ToList();

            try
            {
                using var streamReader = new StreamReader(new FileStream(inputPath, FileMode.Open));
                using var streamWriter = new StreamWriter(new FileStream(outputPath, FileMode.Create));

                while (streamReader.Peek() != -1)
                {
                    var a = streamReader.Read();
                    var b = streamReader.Read();
                    var answer = AlGamalAlgorithm.Decrypt((a, b), p, x);
                    streamWriter.Write(alphabets[answer]);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
