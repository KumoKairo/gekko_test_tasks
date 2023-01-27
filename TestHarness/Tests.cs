using System;
using System.IO;
using NUnit.Framework;

namespace TestHarness
{
    [TestFixture]
    public class Tests
    {
        [TestCase("01")]
        [TestCase("02")]
        [TestCase("03")]
        [TestCase("04")]
        [TestCase("05")]
        [TestCase("06")]
        [TestCase("07")]
        [TestCase("08")]
        [TestCase("09")]
        [TestCase("10")]
        public void CheckTestD(string inputFilePath)
        {
            var inputFile = new StreamReader(File.OpenRead($"../../tests/{inputFilePath}"));
            var outputFile = new StreamReader(File.OpenRead($"../../tests/{inputFilePath}.a"));
            
            string ReadNextLine()
            {
                return inputFile.ReadLine();
            }

            void WriteLineStr(string line)
            {
                Assert.AreEqual(line, outputFile.ReadLine());
            }

            void WriteLine()
            {
                Assert.IsTrue(String.IsNullOrEmpty(outputFile.ReadLine()));
            }

            Program.TestD(ReadNextLine, WriteLineStr, WriteLine);
        }
    }
}