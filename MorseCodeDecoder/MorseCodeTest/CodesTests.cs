using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseCodeDecoder;
using System;
using System.Diagnostics;
using System.IO;

namespace MorseCodeTest
{
    [TestClass]
    public class CodesTests
    {
        
        // tests, if the program run too long
        [Timeout(100)]
        [TestMethod]
        public void TestRuntime()
        {
            FileTranslator translator = new FileTranslator("morse.txt", "text.txt");
            translator.ReadFile();
        }

        // tests, if there is no filename
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestWrongParameters()
        {
            FileTranslator translator = new FileTranslator(null, null);
            translator.ReadFile();

            if(translator.inputFile.Length > 0)
            {
                Console.WriteLine("Length of the input file: " + translator.inputFile.Length);
            }
        }

        // tests, if the morse code is correct
        [TestMethod]
        public void CorrectChars()
        {
            FileTranslator translator = new FileTranslator("morse.txt", "text.txt");
            translator.ReadFile();

            char[] test = translator.morseText.ToString().ToCharArray();

            for(int i = 0; i < test.Length; i++)
            {
                if(test[i] == ' ' || test[i] == '.' || test[i] == '-')
                {
                    Console.WriteLine("Correct chars");
                }
                else
                {
                    Assert.Fail("Wrong characters in the morse code!");
                }
            }

        }

        // tests the assignment
        [TestMethod]
        public void TestMorseCodeLetterToLetter()
        {
            FileTranslator translator = new FileTranslator("morse.txt", "text.txt");

            Assert.AreEqual('M', translator.LetterAllocation("--"));

        }

        // tests, if the there is something written in the output-file
        [TestMethod]
        public void TestWriting()
        {
            FileTranslator translator = new FileTranslator("morse.txt", "text.txt");
            translator.ReadFile();

            FileInfo info = new FileInfo("text.txt");
            long filesize = info.Length;

            if(filesize > 0)
            {
                Assert.IsFalse(false);
            }
            else
            {
                Assert.IsFalse(true);
            }

        }

    }
}
